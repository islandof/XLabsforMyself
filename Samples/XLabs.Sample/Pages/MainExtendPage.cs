using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Forms.Mvvm;
using XLabs.Forms.Services;
using XLabs.Ioc;
using XLabs.Platform.Services;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Pages
{
    class MainExtendPage:ExtendedTabbedPage
    {
        public MainExtendPage()
        {
            //var mainTab = new ExtendedTabbedPage()
            //{
            //    Title = "Xamarin Forms Labs",
            //    SwipeEnabled = true,
            //    TintColor = Color.White,
            //    BarTintColor = Color.Blue,
            //    Badges = { "1", "2", "3" },
            //    TabBarBackgroundImage = "ToolbarGradient2.png",
            //    TabBarSelectedImage = "blackbackground.png",
            //};

            this.Children.Add(new MonitorCentre
            {
                Title = "监控中心",
                Icon = Device.OnPlatform("services1_32.png", "services1_32.png", "Images/services1_32.png")
            });
            this.Children.Add(new CarManage
            {
                Title = "车队管理",
                Icon = Device.OnPlatform("settings20_32.png", "settings20.png", "Images/settings20.png")
            });
            this.Children.Add(new WelcomePage
            {
                Title = "消息中心",
                Icon = Device.OnPlatform("pie30_32.png", "pie30_32.png", "Images/pie30_32.png")
            });
            this.Title = "TesCarMonitor";
            this.SwipeEnabled = true;
            this.TintColor = Color.White;
            this.BarTintColor = Color.White;
            this.Badges.Add(null);
            this.Badges.Add(null);
            this.Badges.Add("3");
            this.TabBarBackgroundImage = "ToolbarGradient2.png";
            this.TabBarSelectedImage = "blackbackground.png";
        }
    }
}
