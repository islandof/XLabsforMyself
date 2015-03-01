using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Sample.ViewModel;

namespace XLabs.Sample.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<LoginViewModel, string>(this, "Alert", (sender, arg) =>
            {
                DisplayAlert("错误信息", arg, "OK");
            });


        }

        private void VisualElement_OnFocused(object sender, FocusEventArgs e)
        {
            Username.Text = "admin";
            Password.Text = "123";
        }
    }
}
