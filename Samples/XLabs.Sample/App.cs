﻿using XLabs.Caching;
using XLabs.Forms.Services;
using XLabs.Platform.Services;
using XLabs.Sample.Pages;
using XLabs.Sample.Pages.Manage;
using XLabs.Sample.Pages.Monitor;
using XLabs.Sample._4.Pages.Manage;

namespace XLabs.Sample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    using XLabs.Forms.Controls;
    using XLabs.Forms.Mvvm;
    using XLabs.Ioc;
    using XLabs.Platform.Device;
    using XLabs.Platform.Mvvm;
    using XLabs.Sample.Pages.Controls;
    using XLabs.Sample.Pages.Controls.Charts;
    using XLabs.Sample.Pages.Controls.DynamicList;
    using XLabs.Sample.Pages.Mvvm;
    using XLabs.Sample.Pages.Services;
    using XLabs.Sample.ViewModel;

    /// <summary>
    /// Class App.
    /// </summary>
    public class App : Application
    {
        private readonly ISimpleCache _cacheService;

        public App ()
        {
            Init();
            _cacheService = Resolver.Resolve<ISimpleCache>();
            var keyValue = _cacheService.Get<string>("USER_ID");
  			MainPage = keyValue!=null ? new NavigationPage(new MainExtendPage()) : new NavigationPage((Page)ViewFactory.CreatePage<LoginViewModel,Page>());

            //MainPage = GetMainPage ();
        }
        /// <summary>
        /// Initializes the application.
        /// </summary>
        public static void Init()
        {
            // Register our views with our view models
            ViewFactory.Register<MvvmSamplePage, MvvmSampleViewModel>();
            ViewFactory.Register<NewPageView, NewPageViewModel>();
            ViewFactory.Register<GeolocatorPage, GeolocatorViewModel>();
            ViewFactory.Register<CameraPage, CameraViewModel>();
            ViewFactory.Register<CacheServicePage, CacheServiceViewModel>();
            ViewFactory.Register<SoundPage, SoundServiceViewModel>();
            ViewFactory.Register<RepeaterViewPage, RepeaterViewViewModel>();
            ViewFactory.Register<WaveRecorderPage, WaveRecorderViewModel>();
            ViewFactory.Register<LoginPage, LoginViewModel>();
            ViewFactory.Register<DangerDriveList, DangerDriveListViewModel>();
            ViewFactory.Register<ZhalanAlarmList, ZhalanAlarmListViewModel>();
            ViewFactory.Register<QicheList,QicheListViewModel>();
            ViewFactory.Register<SijiList,SijiListViewModel>();

            var app = Resolver.Resolve<IXFormsApp>();
            if (app == null)
            {
                return;
            }

            app.Closing += (o, e) => Debug.WriteLine("Application Closing");
            app.Error += (o, e) => Debug.WriteLine("Application Error");
            app.Initialize += (o, e) => Debug.WriteLine("Application Initialized");
            app.Resumed += (o, e) => Debug.WriteLine("Application Resumed");
            app.Rotation += (o, e) => Debug.WriteLine("Application Rotated");
            app.Startup += (o, e) => Debug.WriteLine("Application Startup");
            app.Suspended += (o, e) => Debug.WriteLine("Application Suspended");
        }

        /// <summary>
        /// for wp
        /// </summary>
        /// <returns>page</returns>
        public static Page GetMainPage()
        {
            return new NavigationPage((Page)ViewFactory.CreatePage<LoginViewModel,Page>());
        }

        #region 无用

        ///// <summary>
        ///// Gets the main page.
        ///// </summary>
        ///// <returns>The Main Page.</returns>
        //public static Page GetMainPage()
        //{
                        
        //    var mainTab = new ExtendedTabbedPage()
        //    {
        //        Title = "Xamarin Forms Labs",
        //        SwipeEnabled = true,
        //        TintColor = Color.White,
        //        BarTintColor = Color.Blue,
        //        Badges = { "1", "2", "3" },
        //        TabBarBackgroundImage = "ToolbarGradient2.png",
        //        TabBarSelectedImage = "blackbackground.png",
        //    };

        //    var mainPage = new NavigationPage(mainTab);

        //    Resolver.Resolve<IDependencyContainer>()
        //        .Register<INavigationService>(t => new NavigationService(mainPage.Navigation));

        //    mainTab.CurrentPageChanged += () => Debug.WriteLine("ExtendedTabbedPage CurrentPageChanged {0}", mainTab.CurrentPage.Title);

        //    var controls = GetControlsPage(mainPage);
        //    var services = GetServicesPage(mainPage);
        //    var charts = GetChartingPage(mainPage);

        //    var mvvm = ViewFactory.CreatePage<MvvmSampleViewModel, Page>();

        //    mainTab.Children.Add(controls);
        //    mainTab.Children.Add(services);
        //    mainTab.Children.Add(charts);
        //    mainTab.Children.Add(mvvm as Page);

        //    //var mainPage = new NavigationPage((Page)ViewFactory.CreatePage<LoginViewModel, Page>());
        //    return mainPage;
        //}

        ///// <summary>
        ///// Gets the services page.
        ///// </summary>
        ///// <param name="mainPage">The main page.</param>
        ///// <returns>Content Page.</returns>
        //private static ContentPage GetServicesPage(VisualElement mainPage)
        //{
        //    var listItems = new List<string>()
        //    {
        //        "TextToSpeech",
        //        "DeviceExtended",
        //        "PhoneService",
        //        "GeoLocator",
        //        "Camera",
        //        "Accelerometer",
        //        "Display",
        //        "Cache",
        //        "Sound",
        //        "FontManager",
        //        "NFC",
        //        "Email",
        //        "SecureStorage",
        //        //"WaveRecorder",
        //        //"Bluetooth",
        //    };

        //    var lstServices = new ListView
        //    {
        //        ItemsSource = listItems
        //    };

        //    lstServices.ItemSelected += async (sender, e) =>
        //    {
        //        switch (e.SelectedItem.ToString().ToLower())
        //        {
        //            case "texttospeech":
        //                await mainPage.Navigation.PushAsync(new TextToSpeechPage());
        //                break;
        //            case "deviceextended":
        //                await mainPage.Navigation.PushAsync(new ExtendedDeviceInfoPage(Resolver.Resolve<IDevice>()));
        //                break;
        //            case "phoneservice":
        //                await mainPage.Navigation.PushAsync(new PhoneServicePage());
        //                break;
        //            case "geolocator":
        //                await mainPage.Navigation.PushAsync(ViewFactory.CreatePage<GeolocatorViewModel, Page>() as Page);
        //                break;
        //            case "camera":
        //                await mainPage.Navigation.PushAsync(ViewFactory.CreatePage<CameraViewModel, Page>() as Page);
        //                break;
        //            case "accelerometer":
        //                await mainPage.Navigation.PushAsync(new AcceleratorSensorPage());
        //                break;
        //            case "display":
        //                await mainPage.Navigation.PushAsync(new AbsoluteLayoutWithDisplayInfoPage(Resolver.Resolve<IDisplay>()));
        //                break;
        //            case "cache":
        //                await mainPage.Navigation.PushAsync(ViewFactory.CreatePage<CacheServiceViewModel, Page>() as Page);
        //                break;
        //            case "sound":
        //                await mainPage.Navigation.PushAsync(ViewFactory.CreatePage<SoundServiceViewModel, Page>() as Page);
        //                break;
        //            //case "bluetooth":
        //            //    await mainPage.Navigation.PushAsync(new BluetoothPage());
        //            //    break;
        //            case "fontmanager":
        //                await mainPage.Navigation.PushAsync(new FontManagerPage(Resolver.Resolve<IDisplay>()));
        //                break;
        //            case "nfc":
        //                await mainPage.Navigation.PushAsync(new NfcDevicePage());
        //                break;
        //            case "waverecorder":
        //                await mainPage.Navigation.PushAsync(ViewFactory.CreatePage<WaveRecorderViewModel, Page>() as Page);
        //                break;
        //            case "email":
        //                await mainPage.Navigation.PushAsync(new EmailPage());
        //                break;
        //            case "securestorage":
        //                await mainPage.Navigation.PushAsync(new SecureStoragePage());
        //                break;
        //        }
        //    };

        //    var services = new ContentPage
        //    {
        //        Title = "Services",
        //        Icon = Device.OnPlatform("services1_32.png", "services1_32.png", "Images/services1_32.png"),
        //        Content = lstServices,
        //    };

        //    return services;
        //}

        ///// <summary>
        ///// Gets the controls page.
        ///// </summary>
        ///// <param name="mainPage">The main page.</param>
        ///// <returns>Content Page.</returns>
        //private static ContentPage GetControlsPage(VisualElement mainPage)
        //{
        //    var listItems = new SortedDictionary<string, Type>
        //    {
        //        {"AutocompleteView",  typeof(AutoCompletePage)},
        //        {"ButtonGroup", typeof(ButtonGroupPage)},
        //        {"Calendar", typeof(CalendarPage)},
        //        {"CameraView", typeof(CameraViewPage)},
        //        {"CheckBox", typeof(CheckBoxPage)},
        //        {"CircleImage", typeof(CircleImagePage)},
        //        {"DynamicListView", typeof(DynamicListView)},
        //        {"DragPage", typeof(DragPage)},
        //        {"ExtendedCell", typeof(ExtendedCellPage)},
        //        {"ExtendedEntry", typeof(ExtendedEntryPage)},
        //        {"ExtendedLabel", typeof(ExtendedLabelPage)},
        //        {"ExtendedScrollView", typeof(ExtendedScrollViewPage)},
        //        {"ExtendedSlider", typeof(ExtendedSliderPage)},
        //        {"GridView", typeof(GridViewPage)},
        //        {"HybridWebView", typeof(CanvasWebHybrid)},
        //        {"WebHybridTestPage", typeof(WebHybridTestPage)},
        //        {"ImageButton", typeof(ButtonPage)},
        //        {"ImageGallery", typeof(ImageGalleryPage)},
        //        {"Popup", typeof(PopupPage)},
        //        {"RadioButton",typeof(RadioButtonPage)},
        //        {"RepeaterView", typeof(RepeaterViewPage)},
        //        {"Segment", typeof(SegmentPage)},
        //        {"Separator", typeof(SeparatorPage)},
        //        {"WebImage", typeof(WebImagePage)},
        //    };

        //    // This is actually a lot of work just to enable something
        //    // for iOS only, but oh well.
        //    if (Device.OS == TargetPlatform.iOS)
        //    {
        //        listItems.Add("SegmentedControlView", typeof(SegmentedControlViewPage));
        //    }

        //    var controls = new ContentPage
        //    {
        //        Title = "Controls",
        //        Icon = Device.OnPlatform("settings20_32.png", "settings20.png", "Images/settings20.png"),
        //        Content = BuildListView(mainPage, listItems),
        //    };

        //    return controls;
        //}

        ///// <summary>
        ///// Gets the charting page.
        ///// </summary>
        ///// <param name="mainPage">The main page.</param>
        ///// <returns>Content Page.</returns>
        //private static ContentPage GetChartingPage(VisualElement mainPage)
        //{
        //    var listItems = new SortedDictionary<string, Type>
        //    {
        //         {"Bar", typeof(BarChartPage)},
        //         {"Line", typeof(LineChartPage)},
        //         {"Combination", typeof(CombinationPage)},
        //         {"Pie", typeof(PieChartPage)},
        //         {"Databound combination", typeof(BoundChartPage)},
        //    };

        //    var controls = new ContentPage
        //    {
        //        Title = "Charts",
        //        Icon = Device.OnPlatform("pie30_32.png", "pie30_32.png", "Images/pie30_32.png"),
        //        Content = BuildListView(mainPage, listItems),
        //    };

        //    return controls;
        //}

        ///// <summary>
        ///// Build a ListView associated with a SortedDictionary as the DataSource
        ///// </summary>
        ///// <param name="mainPage">Parent page for the page containing the list view</param>
        ///// <param name="listItems">List of items to display</param>
        ///// <returns></returns>
        //private static ListView BuildListView(VisualElement mainPage, SortedDictionary<string, Type> listItems)
        //{
        //    var listView = new ListView
        //    {
        //        ItemsSource = listItems,
        //        ItemTemplate = new DataTemplate(typeof(TextCell)),
        //    };

        //    listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Key");

        //    listView.ItemSelected += async (sender, e) =>
        //    {
        //        Type result = null;

        //        // This is actually some type of bug with Xamarin.
        //        // On iOS the SortedDiectionary entries are DictionaryEntries
        //        // on WP, they are KeyValuePairs.
        //        // Using the wrong type causes a casting exception.
        //        switch (Device.OS)
        //        {
        //            case TargetPlatform.Android:
        //            case TargetPlatform.iOS:
        //                var item = (DictionaryEntry) e.SelectedItem;
        //                result = (Type)item.Value;
        //                break;
        //            case TargetPlatform.WinPhone:
        //                result = ((KeyValuePair<string, Type>)e.SelectedItem).Value;
        //                break;
        //        }

        //        await ShowPage(mainPage, result);
        //    };

        //    return listView;
        //}

        ///// <summary>
        ///// Shows a page asynchronously by locating the default constructor, creating the page,
        ///// the pushing it onto the navigation stack.
        ///// </summary>
        ///// <param name="parentPage">Parent Page</param>
        ///// <param name="pageType">Type of page to show</param>
        ///// <returns></returns>
        //private static async Task ShowPage(VisualElement parentPage, Type pageType)
        //{
        //    // Get all the constructors of the page type.
        //    var constructors = pageType.GetTypeInfo().DeclaredConstructors;

        //    foreach (
        //        var page in
        //            from constructor in constructors
        //            where constructor.GetParameters().Length == 0
        //            select (Page)constructor.Invoke(null))
        //    {
        //        await parentPage.Navigation.PushAsync(page);

        //        break;
        //    }
        //}

        #endregion 
    }
}

