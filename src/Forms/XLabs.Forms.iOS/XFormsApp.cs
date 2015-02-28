using Xamarin.Forms;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Geolocation;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Services.Email;
using XLabs.Platform.Device;
using XLabs.Platform.Services.IO;

namespace XLabs.Forms
{
    using System;

    using Foundation;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;

    using XLabs.Platform.Mvvm;

    /// <summary>
    /// Class XFormsApplicationDelegate.
    /// </summary>
    public class XFormsApplicationDelegate : FormsApplicationDelegate
    {
        /// <summary>
        /// Gets or sets the finished launching event.
        /// </summary>
        /// <value>The finished launching event.</value>
        public EventHandler<EventArgs> FinishedLaunchingEvent { get; set; }

        /// <summary>
        /// Gets or sets the will terminate event.
        /// </summary>
        /// <value>The will terminate event.</value>
        public EventHandler<EventArgs> WillTerminateEvent { get; set; }

        /// <summary>
        /// Gets or sets the on activated event.
        /// </summary>
        /// <value>The on activated event.</value>
        public EventHandler<EventArgs> OnActivatedEvent { get; set; }

        /// <summary>
        /// Gets or sets the did enter background event.
        /// </summary>
        /// <value>The did enter background event.</value>
        public EventHandler<EventArgs> DidEnterBackgroundEvent { get; set; }

        /// <summary>
        /// Gets or sets the will enter foreground event.
        /// </summary>
        /// <value>The will enter foreground event.</value>
        public EventHandler<EventArgs> WillEnterForegroundEvent { get; set; }

        /// <summary>
        /// Finished the launching.
        /// </summary>
        /// <param name="application">The application.</param>
        /// <remarks>Deprecated function</remarks>
        public override void FinishedLaunching(UIApplication application)
        {
            var handler = FinishedLaunchingEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            base.FinishedLaunching(application);
        }

        /// <summary>
        /// Finished the launching.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var handler = FinishedLaunchingEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// Wills the terminate.
        /// </summary>
        /// <param name="application">The application.</param>
        public override void WillTerminate(UIApplication application)
        {
            var handler = WillTerminateEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            base.WillTerminate(application);
        }

        /// <summary>
        /// Called when [activated].
        /// </summary>
        /// <param name="application">The application.</param>
        public override void OnActivated(UIApplication application)
        {
            var handler = OnActivatedEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            base.OnActivated(application);
        }

        /// <summary>
        /// Dids the enter background.
        /// </summary>
        /// <param name="application">The application.</param>
        public override void DidEnterBackground(UIApplication application)
        {
            var handler = DidEnterBackgroundEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            base.DidEnterBackground(application);
        }

        /// <summary>
        /// Wills the enter foreground.
        /// </summary>
        /// <param name="application">The application.</param>
        public override void WillEnterForeground(UIApplication application)
        {
            var handler = WillEnterForegroundEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            base.WillEnterForeground(application);
        }
    }

    /// <summary>
    /// Class XFormsAppiOS.
    /// </summary>
    public class XFormsAppiOS : XFormsApp<XFormsApplicationDelegate>
    {
        public static void Init() { } /* allow to add assembly without extras */

        public XFormsAppiOS() { }

        public XFormsAppiOS(XFormsApplicationDelegate appDelegate) : base(appDelegate) { }

        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="app">The application.</param>
		/// <param name="initServices">Should initialize services.</param>
		protected override void OnInit(XFormsApplicationDelegate app, bool initServices = true)
        {
            AppContext.FinishedLaunchingEvent += (o, e) => { OnStartup(); };
            AppContext.WillTerminateEvent += (o, e) => { OnClosing(); };
            AppContext.DidEnterBackgroundEvent += (o, e) => { OnSuspended(); };
            AppContext.WillEnterForegroundEvent += (o, e) => { OnResumed(); };
            AppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			if (initServices) {
				DependencyService.Register<TextToSpeechService> ();
				DependencyService.Register<Geolocator> ();
				DependencyService.Register<MediaPicker> ();
				DependencyService.Register<SoundService> ();
				DependencyService.Register<SoundService> ();
				DependencyService.Register<EmailService> ();
				DependencyService.Register<FileManager> ();
				DependencyService.Register<AppleDevice> ();
			}
            
			base.OnInit(app);
        }
    }
}