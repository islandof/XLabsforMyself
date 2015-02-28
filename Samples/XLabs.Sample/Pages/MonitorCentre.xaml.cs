using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace XLabs.Sample.Pages
{
    public partial class MonitorCentre : ContentPage
    {
        public MonitorCentre()
        {
            InitializeComponent();
        }

        private void Danger_OnClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(ViewFactory.CreatePage<DangerDriveListViewModel>());
        }

        private void Alert_OnClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(ViewFactory.CreatePage<ZhalanAlarmListViewModel>());
        }

        private void Locate_OnClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync (new DangerDriveSinglePage ());
        }
    }
}
