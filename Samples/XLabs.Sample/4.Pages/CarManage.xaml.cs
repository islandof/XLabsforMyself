using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Sample.Pages.Manage;

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
    }
}
