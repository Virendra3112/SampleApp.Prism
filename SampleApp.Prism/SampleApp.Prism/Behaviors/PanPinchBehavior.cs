using System;
using Xamarin.Forms;

namespace SampleApp.Prism.Behaviors
{
    public class PanPinchBehavior : Behavior<View>
    {
        private double _currentScale = 1, _startScale = 1, _xOffset, _yOffset;

        private PinchGestureRecognizer _pinchGestureRecognizer;

        private PanGestureRecognizer _panGestureRecognizer;

        private ContentView _parent;

        private View _associatedObject;

        private void AssociatedObjectBindingContextChanged(object sender, EventArgs e)
        {
            _parent = _associatedObject.Parent as ContentView;
            _parent?.GestureRecognizers.Remove(_panGestureRecognizer);
            _parent?.GestureRecognizers.Add(_panGestureRecognizer);
            _parent?.GestureRecognizers.Remove(_pinchGestureRecognizer);
            _parent?.GestureRecognizers.Add(_pinchGestureRecognizer);
        }

        private void CleanupEvents()
        {
            _pinchGestureRecognizer.PinchUpdated -= OnPinchUpdated;
            _panGestureRecognizer.PanUpdated -= OnPanUpdated;
            _associatedObject.BindingContextChanged -= AssociatedObjectBindingContextChanged;
        }


        private void InitializeEvents()
        {
            CleanupEvents();
            _pinchGestureRecognizer.PinchUpdated += OnPinchUpdated;
            _panGestureRecognizer.PanUpdated += OnPanUpdated;
            _associatedObject.BindingContextChanged += AssociatedObjectBindingContextChanged;
        }


        private void InitialiseRecognizers()
        {
            _pinchGestureRecognizer = new PinchGestureRecognizer();
            _panGestureRecognizer = new PanGestureRecognizer();
        }


        protected override void OnAttachedTo(View associatedObject)
        {
            InitialiseRecognizers();
            _associatedObject = associatedObject;
            InitializeEvents();

            base.OnAttachedTo(associatedObject);
        }


        protected override void OnDetachingFrom(View associatedObject)
        {
            CleanupEvents();

            _parent = null;
            _pinchGestureRecognizer = null;
            _panGestureRecognizer = null;
            _associatedObject = null;

            base.OnDetachingFrom(associatedObject);
        }


        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (_parent == null)
            {
                return;
            }

            if (!IsTranslateEnabled)
            {
                return;
            }

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    _parent.Content.TranslationX = _xOffset + e.TotalX;
                    _parent.Content.TranslationY = _yOffset + e.TotalY;
                    break;

                case GestureStatus.Completed:
                    _xOffset = _parent.Content.TranslationX;
                    _yOffset = _parent.Content.TranslationY;
                    break;
            }
        }


        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (_parent == null)
            {
                return;
            }

            if (!IsScaleEnabled)
            {
                return;
            }

            switch (e.Status)
            {
                case GestureStatus.Started:
                    _startScale = _parent.Content.Scale;
                    _parent.Content.AnchorX = 0;
                    _parent.Content.AnchorY = 0;

                    break;

                case GestureStatus.Running:
                    _currentScale += (e.Scale - 1) * _startScale;
                    _currentScale = Math.Max(1, _currentScale);

                    var renderedX = _parent.Content.X + _xOffset;
                    var deltaX = renderedX / _parent.Width;
                    var deltaWidth = _parent.Width / (_parent.Content.Width * _startScale);
                    var originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                    var renderedY = _parent.Content.Y + _yOffset;
                    var deltaY = renderedY / _parent.Height;
                    var deltaHeight = _parent.Height / (_parent.Content.Height * _startScale);
                    var originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                    var targetX = _xOffset - (originX * _parent.Content.Width) * (_currentScale - _startScale);
                    var targetY = _yOffset - (originY * _parent.Content.Height) * (_currentScale - _startScale);

                    _parent.Content.TranslationX = targetX.Clamp(-_parent.Content.Width * (_currentScale - 1), 0);
                    _parent.Content.TranslationY = targetY.Clamp(-_parent.Content.Height * (_currentScale - 1), 0);

                    _parent.Content.Scale = _currentScale;

                    break;

                case GestureStatus.Completed:
                    _xOffset = _parent.Content.TranslationX;
                    _yOffset = _parent.Content.TranslationY;

                    break;
            }
        }


        public void OnAppearing()
        {
            AssociatedObjectBindingContextChanged(_associatedObject, null);
        }


        public static readonly BindableProperty IsScaleEnabledProperty =
            BindableProperty.Create<PanPinchBehavior, bool>(w => w.IsScaleEnabled, default(bool));


        public bool IsScaleEnabled
        {
            get { return (bool)GetValue(IsScaleEnabledProperty); }
            set { SetValue(IsScaleEnabledProperty, value); }
        }




        public static readonly BindableProperty IsTranslateEnabledProperty =
            BindableProperty.Create<PanPinchBehavior, bool>(w => w.IsTranslateEnabled, default(bool));

        public bool IsTranslateEnabled
        {
            get { return (bool)GetValue(IsTranslateEnabledProperty); }
            set { SetValue(IsTranslateEnabledProperty, value); }
        }

    }

    public static class DoubleExtensions
    {
        public static double Clamp(this double self, double min, double max)
        {
            return Math.Min(max, Math.Max(self, min));
        }
    }
}
