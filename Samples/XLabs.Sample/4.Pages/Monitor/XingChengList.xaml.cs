using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Pages.Monitor
{
    public partial class XingChengList : ContentPage
    {
        public XingChengList()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            MessagingCenter.Subscribe<XingChengViewModel>(this, "", NavigateToDetail);
        }

        private async void NavigateToDetail(XingChengViewModel item)
        {
            await Navigation.PushAsync(new Trace { Title = "轨迹查询" });
            //await Navigation.PushAsync(new XingChengPage { Title = item.chepaino + "的详细信息", BindingContext = item });
        }
    }
}
