﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Sample.Pages.Monitor;
using XLabs.Sample.ViewModel;

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
            Navigation.PushAsync((Page)ViewFactory.CreatePage<DangerDriveListViewModel,Page>());
            //new NavigationPage((Page) ViewFactory.CreatePage<DangerDriveListViewModel, Page>());
        }

        private void Alert_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync((Page)ViewFactory.CreatePage<ZhalanAlarmListViewModel, Page>());            
        }

        private void Locate_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync (new LocalsPage());
        }

        private void Trace_OnClicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync((Page)ViewFactory.CreatePage<TraceListViewModel, Page>());            
        }

        private void Tobefinish_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TobeFinish());
        }
    }
}
