using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XLabs.Sample.Pages
{
    internal class MainExtendPage : ExtendedTabbedPage
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

            Children.Add(new MonitorCentre
            {
                Title = "监控中心",
                Icon = Device.OnPlatform("services1_32.png", "services1_32.png", "Images/services1_32.png")
            });
            Children.Add(new CarManage
            {
                Title = "车队管理",
                Icon = Device.OnPlatform("settings20_32.png", "settings20.png", "Images/settings20.png")
            });
            Children.Add(new WelcomePage
            {
                Title = "消息中心",
                Icon = Device.OnPlatform("pie30_32.png", "pie30_32.png", "Images/pie30_32.png")
            });
            Title = "TesCarMonitor";
            SwipeEnabled = true;
            TintColor = Color.White;
            BarTintColor = Color.White;
            Badges.Add(null);
            Badges.Add(null);
            Badges.Add("3");
            TabBarBackgroundImage = "ToolbarGradient2.png";
            TabBarSelectedImage = "blackbackground.png";
        }
    }
}