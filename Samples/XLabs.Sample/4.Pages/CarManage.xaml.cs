using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using XLabs.Sample.Pages.Manage;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Pages
{
    public partial class CarManage : ContentPage
    {
        public CarManage()
        {
            InitializeComponent();
        }

        private void Charts_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChartsListPage());
        }

        private void Vehicle_OnClicked(object sender, EventArgs e)
        {         
            Navigation.PushAsync((Page)ViewFactory.CreatePage<QicheListViewModel, Page>());
        }

        private void Driver_OnClicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync((Page)ViewFactory.CreatePage<SijiListViewModel, Page>());
        }

        private void Tobefinish_OnClicked(object sender, EventArgs e)
        {            
            Navigation.PushAsync(new TobeFinish());
        }


    }
}
