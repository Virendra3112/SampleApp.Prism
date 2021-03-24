//using System;
//using System.IO;
//using SkiaSharp;
//using SkiaSharp.Views.Forms;
//using SKSvg = SkiaSharp.Extended.Svg.SKSvg;
//using Xamarin.Forms;
//using Xamarin.Forms.Internals;
//using System.Threading.Tasks;

//namespace SampleApp.Prism.CustomControls
//{
//    public class CustomPanPinchSVG : ContentView
//    {
//        private readonly SKCanvasView _canvasView = new SKCanvasView();

//        private SKPicture _svgPicture;

//        private float _scale = 1f;
//        private SKMatrix _canvasTranslateMatrix;

//        private float _x;
//        private float _y;

//        private float _xGestureStart;
//        private float _yGestureStart;

//        private double currentScale;

//        private double startScale;

//        public static readonly BindableProperty ResourceIdProperty = BindableProperty.Create(
//            nameof(ResourceId), typeof(string), typeof(CustomSVGControl), default(string), propertyChanged: RedrawCanvas);

//        public string ResourceId
//        {
//            get => (string)GetValue(ResourceIdProperty);
//            set => SetValue(ResourceIdProperty, value);
//        }
//        public CustomPanPinchSVG()
//        {
//            Padding = new Thickness(0);
//            Content = _canvasView;
//            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
//            InitializeGestures();
//        }

//        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
//        {
//            SKCanvas canvas = args.Surface.Canvas;
//            canvas.Clear();

//            if (string.IsNullOrEmpty(ResourceId))
//                return;

//            if (_svgPicture == null)
//                return;

//            SKImageInfo info = args.Info;
//            canvas.Translate(info.Width / 2f, info.Height / 2f);

//            SKRect bounds = _svgPicture.CullRect;
//            float ratio = bounds.Width > bounds.Height
//                ? info.Height / bounds.Height
//                : info.Width / bounds.Width;

//            canvas.Scale(ratio);
//            canvas.Translate(-bounds.MidX, -bounds.MidY);
//            _canvasTranslateMatrix = canvas.TotalMatrix;
//            canvas.Scale(_scale);

//            float scaledX = _x / canvas.TotalMatrix.ScaleX;
//            float scaledY = _y / canvas.TotalMatrix.ScaleY;

//            SKMatrix pictureTranslation = SKMatrix.MakeTranslation(scaledX, scaledY);
//            canvas.DrawPicture(_svgPicture, ref pictureTranslation);
//        }
//        private void InitializeGestures()
//        {
//            //PanGestureRecognizer panGestureRecognizer = new PanGestureRecognizer();
//            //panGestureRecognizer.PanUpdated += MovePicture;

//            PinchGestureRecognizer pinchgesturerecognizer = new PinchGestureRecognizer();
//            pinchgesturerecognizer.PinchUpdated += OnPinchUpdated;

//            //TapGestureRecognizer doubleTapGestureRecognizer = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
//            //doubleTapGestureRecognizer.Tapped += ZoomToFit;

//            //_canvasView.GestureRecognizers.Add(panGestureRecognizer);
//            //_canvasView.GestureRecognizers.Add(pinchGestureRecognizer);
//            //_canvasView.GestureRecognizers.Add(doubleTapGestureRecognizer);
//        }

//        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
//        {
//            var s = (ContentView)sender;

//            if (e.Status == GestureStatus.Started)
//            {
//                // Store the current scale factor applied to the wrapped user interface element,
//                // and zero the components for the center point of the translate transform.
//                _scale = (float)s.Content.Scale;

//                s.Content.AnchorX = 0;
//                s.Content.AnchorY = 0;
//            }
//            if (e.Status == GestureStatus.Running)
//            {

//                // Calculate the scale factor to be applied.
//                currentScale += (e.Scale - 1) * startScale;
//                currentScale = System.Math.Max(1, currentScale);
//                currentScale = System.Math.Min(currentScale, 5);

//                //scaleLabel.Text = "Scale: " + currentScale.ToString ();

//                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
//                // so get the X pixel coordinate.
//                double renderedX = s.Content.X + _x;
//                double deltaX = renderedX / App.ScreenWidth;
//                double deltaWidth = App.ScreenWidth / (s.Content.Width * startScale);
//                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

//                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
//                // so get the Y pixel coordinate.
//                double renderedY = s.Content.Y + _y;

//                double deltaY = renderedY / App.ScreenHeight;
//                double deltaHeight = App.ScreenHeight / (s.Content.Height * startScale);
//                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

//                // Calculate the transformed element pixel coordinates.
//                double targetX = _x - (originX * s.Content.Width) * (currentScale - startScale);
//                double targetY = _y - (originY * s.Content.Height) * (currentScale - startScale);

//                // Apply translation based on the change in origin.
//                var transX = targetX.Clamp(-s.Content.Width * (currentScale - 1), 0);
//                var transY = targetY.Clamp(-s.Content.Height * (currentScale - 1), 0);


//                s.Content.TranslateTo(transX, transY, 0, Easing.Linear);
//                // Apply scale factor.
//                s.Content.Scale = currentScale;
//            }
//        }


//        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
//        {
//            var interactiveSvg = bindable as CustomPanPinchSVG;
//            interactiveSvg?.LoadSvgPictureAsync();
//            interactiveSvg?._canvasView.InvalidateSurface();
//        }

//        private async Task LoadSvgPictureAsync()
//        {
//            try
//            {
//                using (Stream stream = GetType().Assembly.GetManifestResourceStream(ResourceId))
//                {
//                    if (ResourceId.Contains("http"))
//                    {
//                        // download the bytes
//                        var httpClient = new System.Net.Http.HttpClient();
//                        var bytes = await httpClient.GetByteArrayAsync(ResourceId);

//                        // wrap the bytes in a stream
//                        var _stream = new MemoryStream(bytes);

//                        SKSvg _svg = new SKSvg();
//                        _svg.Load(_stream);

//                        _svgPicture = _svg.Picture;
//                    }

//                    else
//                    {
//                        SKSvg svg = new SKSvg();
//                        svg.Load(stream);
//                        _svgPicture = svg.Picture;
//                    }
//                }

//                UpdateImageProperties(0, 0, 1);
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        private void UpdateImageProperties(float x, float y, float? newScale = null)
//        {
//            _x = x;
//            _y = y;
//            _scale = newScale ?? _scale;
//            _canvasView.InvalidateSurface();
//        }


//    }
//}
