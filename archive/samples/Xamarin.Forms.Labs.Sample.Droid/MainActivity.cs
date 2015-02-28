﻿// ***********************************************************************
// Assembly         : Xamarin.Forms.Labs.Sample.Droid
// Author           : Shawn Anderson
// Created          : 06-16-2014
//
// Last Modified By : Sami Kallio
// Last Modified On : 09-01-2014
// ***********************************************************************
// <copyright file="MainActivity.cs" company="">
//     Copyright (c) 2014 . All rights reserved.
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Labs.Droid;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Services;
using System.IO;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Caching;
using XLabs.Caching.SQLite;

namespace Xamarin.Forms.Labs.Sample.Droid
{
    /// <summary>
    /// Class MainActivity.
    /// </summary>
    [Activity(Label = "Xamarin.Forms.Labs.Sample.Droid", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : XFormsApplicationDroid
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!Resolver.IsSet)
            {
                this.SetIoc();
            }
            else
            {
                var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
                app.AppContext = this;
            }

            Xamarin.Forms.Forms.Init(this, bundle);

            App.Init();

            this.SetPage(App.GetMainPage());
        }

        /// <summary>
        /// Sets the IoC.
        /// </summary>
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppDroid();

            app.Init(this);

            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xforms.db");

            resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                //.Register<IJsonSerializer, Services.Serialization.JsonNET.JsonSerializer>()
                .Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer>()
                .Register<IDependencyContainer>(resolverContainer)
                .Register<IXFormsApp>(app)
                .Register<ISimpleCache>(
                    t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
                        new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));


            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}


