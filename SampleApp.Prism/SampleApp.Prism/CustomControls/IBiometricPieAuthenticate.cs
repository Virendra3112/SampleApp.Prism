namespace SampleApp.Prism.CustomControls
{
    public interface IBiometricPieAuthenticate
    {
        void RegisterOrAuthenticate();

        bool CheckSDKGreater29();
    }
}
