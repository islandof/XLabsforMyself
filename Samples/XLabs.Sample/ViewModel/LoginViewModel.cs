using System;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Caching;
using XLabs.Ioc;
using XLabs.Sample.Pages;
using XLabs.Sample.Services;

namespace XLabs.Sample.ViewModel
{
    public class LoginViewModel : Forms.Mvvm.ViewModel
    {
        //private readonly IAppNavigation _navigationService;
        private ContentPage _page;
        private readonly ISimpleCache _cacheService;

        public LoginViewModel()
        {
            _cacheService = Resolver.Resolve<ISimpleCache>();
            var _loginService = new LoginService();
            LoginCommand = new Command(async nothing =>
            {
                var result = await _loginService.LoginAsync(Username, Password);
                if (result.USER_ID > 0)
                {
                    //Application.Current.Properties["USER_ID"] = result.USER_ID;
                    if (_cacheService == null)
                    {
                        throw new ArgumentNullException(
                            "_cacheService",
                            new Exception("Native SimpleCache implementation wasn't found."));
                    }
                    _cacheService.Remove("USER_ID");
                    _cacheService.Add("USER_ID", result.USER_ID);

                    await Navigation.PushAsync(new MainExtendPage());
                    //await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    //MessagingCenter.Send(this, "Hi");
                    MessagingCenter.Send(this, "Alert", "输入的用户名或密码错误");


                    //await Navigation.DisplayAlert("错误", "输入的用户名或密码错误！", "确定");
                }
            });
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_NAME_EN { get; set; }
        public string USER_PWD { get; set; }
        public int? DEPT_ID { get; set; }
        public string DEPT_NAME { get; set; }
        public int? ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string USER_EMAIL { get; set; }
        public int? companyid { get; set; }
        public string companyname { get; set; }
        //public ICommand LoginCommand { get { return new SimpleCommand(Login); } }
        public ICommand LoginCommand { private set; get; }
    }
}