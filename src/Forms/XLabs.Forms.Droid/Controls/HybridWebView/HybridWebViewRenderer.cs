﻿using XLabs.Forms.Controls;

[assembly: Xamarin.Forms.ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]

namespace XLabs.Forms.Controls
{
    using System;

    using Android.Views;
    using Android.Webkit;

    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Class HybridWebViewRenderer.
    /// </summary>
    public partial class HybridWebViewRenderer : ViewRenderer<HybridWebView, HybridWebViewRenderer.NativeWebView>
    {
        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged (e);

            if (this.Control == null)
            {
                var webView = new NativeWebView(this);

                webView.Settings.JavaScriptEnabled = true;

                webView.SetWebViewClient(new Client(this));
                webView.SetWebChromeClient(new ChromeClient(this));

                webView.AddJavascriptInterface(new Xamarin(this), "Xamarin");

                this.SetNativeControl(webView);
            }

            this.Unbind(e.OldElement);

            this.Bind();
        }

        /// <summary>
        /// Gets the desired size of the view.
        /// </summary>
        /// <param name="widthConstraint">Width constraint.</param>
        /// <param name="heightConstraint">Height constraint.</param>
        /// <returns>The desired size.</returns>
        /// <remarks>We need to override this method and set the request height to 0. Otherwise on view refresh
        /// we will get incorrect view height and might lose the ability to scroll the webview
        /// completely.</remarks>
        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
//            var sizeRequest = base.GetDesiredSize(widthConstraint, heightConstraint);
//            sizeRequest.Request = new Size(sizeRequest.Request.Width, 0);
//            return sizeRequest;

            return new SizeRequest(Size.Zero, Size.Zero);
        }

        private void OnPageFinished()
        {
            this.InjectNativeFunctionScript();

            if (this.Element != null)
            {
                this.Element.OnLoadFinished(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Injects the specified script.
        /// </summary>
        /// <param name="script">The script.</param>
        partial void Inject(string script)
        {
            this.Control.LoadUrl(string.Format("javascript: {0}", script));
        }



        /// <summary>
        /// Loads the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        partial void Load(Uri uri)
        {
            if (uri != null)
            {
                this.Control.LoadUrl(uri.AbsoluteUri);
                //this.InjectNativeFunctionScript();
            }
        }

        /// <summary>
        /// Loads from content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="contentFullName">Full name of the content.</param>
        partial void LoadFromContent(object sender, string contentFullName)
        {
            this.Element.Uri = new Uri("file:///android_asset/" + contentFullName);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="contentFullName">Full name of the content.</param>
        partial void LoadContent(object sender, string contentFullName)
        {
            this.Control.LoadDataWithBaseURL("file:///android_asset/", contentFullName, "text/html", "UTF-8", null);
            // we can't really set the URI and fire up native function injection so the workaround is to do it here
            //this.InjectNativeFunctionScript();
        }

        /// <summary>
        /// Loads from string.
        /// </summary>
        /// <param name="html">The HTML.</param>
        partial void LoadFromString(string html)
        {
            this.Control.LoadData(html, "text/html", "UTF-8");
            //this.InjectNativeFunctionScript();
        }

        /// <summary>
        /// Class Client.
        /// </summary>
        private class Client : WebViewClient
        {
            /// <summary>
            /// The web hybrid
            /// </summary>
            private readonly HybridWebViewRenderer webHybrid;

            /// <summary>
            /// Initializes a new instance of the <see cref="Client"/> class.
            /// </summary>
            /// <param name="webHybrid">The web hybrid.</param>
            public Client(HybridWebViewRenderer webHybrid)
            {
                this.webHybrid = webHybrid;
            }

            /// <summary>
            /// Notify the host application that a page has finished loading.
            /// </summary>
            /// <param name="view">The WebView that is initiating the callback.</param>
            /// <param name="url">The url of the page.</param>
            /// <since version="Added in API level 1" />
            /// <remarks><para tool="javadoc-to-mdoc">Notify the host application that a page has finished loading. This method
            /// is called only for main frame. When onPageFinished() is called, the
            /// rendering picture may not be updated yet. To get the notification for the
            /// new Picture, use <c><see cref="M:Android.Webkit.WebView.IPictureListener.OnNewPicture(Android.Webkit.WebView, Android.Graphics.Picture)" /></c>.</para>
            /// <para tool="javadoc-to-mdoc">
            ///   <format type="text/html">
            ///     <a href="http://developer.android.com/reference/android/webkit/WebViewClient.html#onPageFinished(android.webkit.WebView, java.lang.String)" target="_blank">[Android Documentation]</a>
            ///   </format>
            /// </para></remarks>
            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                base.OnPageFinished(view, url);

                if (this.webHybrid != null)
                {
                    this.webHybrid.OnPageFinished();
                }
            }

            /// <summary>
            /// Give the host application a chance to take over the control when a new
            /// url is about to be loaded in the current WebView.
            /// </summary>
            /// <param name="view">The WebView that is initiating the callback.</param>
            /// <param name="url">The url to be loaded.</param>
            /// <returns>To be added.</returns>
            /// <since version="Added in API level 1" />
            /// <remarks><para tool="javadoc-to-mdoc">Give the host application a chance to take over the control when a new
            /// url is about to be loaded in the current WebView. If WebViewClient is not
            /// provided, by default WebView will ask Activity Manager to choose the
            /// proper handler for the url. If WebViewClient is provided, return true
            /// means the host application handles the url, while return false means the
            /// current WebView handles the url.
            /// This method is not called for requests using the POST "method".</para>
            /// <para tool="javadoc-to-mdoc">
            ///   <format type="text/html">
            ///     <a href="http://developer.android.com/reference/android/webkit/WebViewClient.html#shouldOverrideUrlLoading(android.webkit.WebView, java.lang.String)" target="_blank">[Android Documentation]</a>
            ///   </format>
            /// </para></remarks>
            public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
            {
                if (this.webHybrid == null)
                {
                    return base.ShouldOverrideUrlLoading(view, url);
                }

                if (!this.webHybrid.CheckRequest(url))
                {
                    this.webHybrid.Element.OnNavigating(new Uri(url));
                    return base.ShouldOverrideUrlLoading(view, url);
                }

                return true;
            }
        }

        /// <summary>
        /// Java callback class for JavaScript.
        /// </summary>
        public class Xamarin : Java.Lang.Object
        {
            /// <summary>
            /// The web hybrid
            /// </summary>
            private readonly HybridWebViewRenderer webHybrid;

            /// <summary>
            /// Initializes a new instance of the <see cref="Xamarin"/> class.
            /// </summary>
            /// <param name="webHybrid">The web hybrid.</param>
            public Xamarin(HybridWebViewRenderer webHybrid)
            {
                this.webHybrid = webHybrid;
            }

            /// <summary>
            /// Calls the specified function.
            /// </summary>
            /// <param name="function">The function.</param>
            /// <param name="data">The data.</param>
            [JavascriptInterface]
            [Java.Interop.Export("call")]
            public void Call(string function, string data)
            {
                this.webHybrid.TryInvoke(function, data);
            }
        }

        /// <summary>
        /// Class ChromeClient.
        /// </summary>
        private class ChromeClient : WebChromeClient 
        {
            /// <summary>
            /// The web hybrid
            /// </summary>
            private readonly HybridWebViewRenderer webHybrid;

            /// <summary>
            /// Initializes a new instance of the <see cref="ChromeClient"/> class.
            /// </summary>
            /// <param name="webHybrid">The web hybrid.</param>
            internal ChromeClient(HybridWebViewRenderer webHybrid)
            {
                this.webHybrid = webHybrid;
            }

//            public override void OnProgressChanged(Android.Webkit.WebView view, int newProgress)
//            {
//                base.OnProgressChanged(view, newProgress);
//
//                if (newProgress >= 100)
//                {
//                    this.webHybrid.Element.OnLoadFinished(this, EventArgs.Empty);
//                }
//            }

            /// <summary>
            /// Tell the client to display a javascript alert dialog.
            /// </summary>
            /// <param name="view">The WebView that initiated the callback.</param>
            /// <param name="url">The url of the page requesting the dialog.</param>
            /// <param name="message">Message to be displayed in the window.</param>
            /// <param name="result">A JsResult to confirm that the user hit enter.</param>
            /// <returns>To be added.</returns>
            /// <since version="Added in API level 1" />
            /// <remarks><para tool="javadoc-to-mdoc">Tell the client to display a javascript alert dialog.  If the client
            /// returns true, WebView will assume that the client will handle the
            /// dialog.  If the client returns false, it will continue execution.</para>
            /// <para tool="javadoc-to-mdoc">
            ///   <format type="text/html">
            ///     <a href="http://developer.android.com/reference/android/webkit/WebChromeClient.html#onJsAlert(android.webkit.WebView, java.lang.String, java.lang.String, android.webkit.JsResult)" target="_blank">[Android Documentation]</a>
            ///   </format>
            /// </para></remarks>
            public override bool OnJsAlert(Android.Webkit.WebView view, string url, string message, JsResult result)
            {
                // the built-in alert is pretty ugly, you could do something different here if you wanted to
                return base.OnJsAlert(view, url, message, result);
            }

            /// <summary>
            /// Overrides the geolocation prompt and accepts the permission.
            /// </summary>
            /// <param name="origin">Origin of the prompt.</param>
            /// <param name="callback">Permission callback.</param>
            /// <remarks>Always grant permission since the app itself requires location
            /// permission and the user has therefore already granted it.</remarks>
            public override void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
            {
                callback.Invoke(origin, true, false);
            }
        }

        /// <summary>
        /// Class NativeWebView.
        /// </summary>
        public class NativeWebView : Android.Webkit.WebView
        {
            /// <summary>
            /// The listener
            /// </summary>
            private readonly MyGestureListener _listener;
            /// <summary>
            /// The detector
            /// </summary>
            private readonly GestureDetector _detector;

            /// <summary>
            /// Initializes a new instance of the <see cref="NativeWebView"/> class.
            /// </summary>
            /// <param name="renderer">The renderer.</param>
            public NativeWebView(HybridWebViewRenderer renderer) : base(renderer.Context)
            {
                this._listener = new MyGestureListener(renderer);
                this._detector = new GestureDetector(this.Context, this._listener);
            }

            /// <summary>
            /// Implement this method to handle touch screen motion events.
            /// </summary>
            /// <param name="e">The motion event.</param>
            /// <returns>To be added.</returns>
            /// <since version="Added in API level 1" />
            /// <remarks><para tool="javadoc-to-mdoc">Implement this method to handle touch screen motion events.</para>
            /// <para tool="javadoc-to-mdoc">
            ///   <format type="text/html">
            ///     <a href="http://developer.android.com/reference/android/view/View.html#onTouchEvent(android.view.MotionEvent)" target="_blank">[Android Documentation]</a>
            ///   </format>
            /// </para></remarks>
            public override bool OnTouchEvent(MotionEvent e)
            {
                this._detector.OnTouchEvent(e);
                return base.OnTouchEvent(e);
            }

            /// <summary>
            /// Class MyGestureListener.
            /// </summary>
            private class MyGestureListener : GestureDetector.SimpleOnGestureListener
            {
                /// <summary>
                /// The swip e_ mi n_ distance
                /// </summary>
                private const int SWIPE_MIN_DISTANCE = 120;
                /// <summary>
                /// The swip e_ ma x_ of f_ path
                /// </summary>
                private const int SWIPE_MAX_OFF_PATH = 200;
                /// <summary>
                /// The swip e_ threshol d_ velocity
                /// </summary>
                private const int SWIPE_THRESHOLD_VELOCITY = 200;

                /// <summary>
                /// The web hybrid
                /// </summary>
                private readonly WeakReference<HybridWebViewRenderer> _webHybrid;

                /// <summary>
                /// Initializes a new instance of the <see cref="MyGestureListener"/> class.
                /// </summary>
                /// <param name="renderer">The renderer.</param>
                public MyGestureListener(HybridWebViewRenderer renderer)
                {
                    this._webHybrid = new WeakReference<HybridWebViewRenderer>(renderer);
                }

//                public override void OnLongPress(MotionEvent e)
//                {
//                    Console.WriteLine("OnLongPress");
//                    base.OnLongPress(e);
//                }
//
//                public override bool OnDoubleTap(MotionEvent e)
//                {
//                    Console.WriteLine("OnDoubleTap");
//                    return base.OnDoubleTap(e);
//                }
//
//                public override bool OnDoubleTapEvent(MotionEvent e)
//                {
//                    Console.WriteLine("OnDoubleTapEvent");
//                    return base.OnDoubleTapEvent(e);
//                }
//
//                public override bool OnSingleTapUp(MotionEvent e)
//                {
//                    Console.WriteLine("OnSingleTapUp");
//                    return base.OnSingleTapUp(e);
//                }
//
//                public override bool OnDown(MotionEvent e)
//                {
//                    Console.WriteLine("OnDown");
//                    return base.OnDown(e);
//                }

                /// <summary>
                /// Called when [fling].
                /// </summary>
                /// <param name="e1">The e1.</param>
                /// <param name="e2">The e2.</param>
                /// <param name="velocityX">The velocity x.</param>
                /// <param name="velocityY">The velocity y.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
                {
                    HybridWebViewRenderer hybrid;

                    if (this._webHybrid.TryGetTarget(out hybrid) && Math.Abs(velocityX) > SWIPE_THRESHOLD_VELOCITY)
                    {
                        if(e1.GetX() - e2.GetX() > SWIPE_MIN_DISTANCE) 
                        {
                            hybrid.Element.OnLeftSwipe(this, EventArgs.Empty);
                        }  
                        else if (e2.GetX() - e1.GetX() > SWIPE_MIN_DISTANCE) 
                        {
                            hybrid.Element.OnRightSwipe(this, EventArgs.Empty);
                        }
                    }

                    return base.OnFling(e1, e2, velocityX, velocityY);
                }

//                public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
//                {
//                    Console.WriteLine("OnScroll");
//                    return base.OnScroll(e1, e2, distanceX, distanceY);
//                }
//
//                public override void OnShowPress(MotionEvent e)
//                {
//                    Console.WriteLine("OnShowPress");
//                    base.OnShowPress(e);
//                }
//
//                public override bool OnSingleTapConfirmed(MotionEvent e)
//                {
//                    Console.WriteLine("OnSingleTapConfirmed");
//                    return base.OnSingleTapConfirmed(e);
//                }

            }
        }
    }
}

