using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Pages
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            BindingContext = ViewModelLocator.Main;

            var label3 = new ExtendedLabel
            {
                Text = "粤B28263保险即将到期：粤B28263保险将在2月15号到期，请及时到续约，推荐到平安保险，购险有优惠，网址www.pingan.com",
                TextColor = Device.OnPlatform(Color.Black, Color.White, Color.White),
                IsUnderline = false,
                IsStrikeThrough = true,
                FontSize = 12
            };

            var label4 = new ExtendedLabel
            {
                IsDropShadow = true,
                Text = "粤B14152闯红灯违章：粤B14152在桂庙路口闯红灯违章被拍下，扣6分，罚款500元，请及时处理，可以到这边委托办理www.xxx.com",
                TextColor = Color.Red,
                FontSize = 12
            };

            var label5 = new Label
            {
                Text = "腾兴车联合作4S店送大礼（优惠）：截止至3月24号，到指定的4S店做汽车保养，可以免费赠送洗车及车内除尘等服务，还享9折优惠，详情请看xxxxxx",
                FontSize = 12
            };


            stkRoot.Children.Add(label4);
            stkRoot.Children.Add(label3);
            stkRoot.Children.Add(label5);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new XLabsExtendPage());
        }
    }
}
