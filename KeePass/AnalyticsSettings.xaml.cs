using System;
using System.Windows.Navigation;
using KeePass.Analytics;
using KeePass.Utils;

namespace KeePass
{
    public partial class AnalyticsSettings
    {
        public AnalyticsSettings()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(
            bool cancelled, NavigationEventArgs e)
        {
            if (cancelled)
                return;

            lblDevice.Text = DeviceData.GetDeviceId();
        }

        private void cmdAllow_Click(object sender, EventArgs e)
        {
            AppSettings.Instance
                .AllowAnalytics = true;

            AnalyticsTracker.Collect();
            NavigationService.GoBack();
        }

        private void cmdDisable_Click(object sender, EventArgs e)
        {
            AppSettings.Instance
                .AllowAnalytics = false;

            AnalyticsTracker.Disable();
            NavigationService.GoBack();
        }
    }
}