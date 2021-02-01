using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SampleApp.Prism.Helpers
{
    public class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;

        private const bool DefaultIsLoggedIn = false;

        public static bool IsLoggedIn
        {
            get => Settings.GetValueOrDefault(nameof(IsLoggedIn), DefaultIsLoggedIn);
            set => Settings.AddOrUpdateValue(nameof(IsLoggedIn), value);
        }


        private const bool DefaultIsFingerprintSet = false;

        public static bool IsFingerprintSet
        {
            get => Settings.GetValueOrDefault(nameof(IsFingerprintSet), DefaultIsFingerprintSet);
            set => Settings.AddOrUpdateValue(nameof(IsFingerprintSet), value);
        }

        private const string DefaultUserEmail = "";

        public static string UserEmail
        {
            get => Settings.GetValueOrDefault(nameof(UserEmail), DefaultUserEmail);
            set => Settings.AddOrUpdateValue(nameof(UserEmail), value);
        }

    }
}