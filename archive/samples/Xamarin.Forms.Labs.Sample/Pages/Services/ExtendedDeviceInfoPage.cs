﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Forms.Labs.Sample
{
    public class ExtendedDeviceInfoPage : ContentPage
    {
        public ExtendedDeviceInfoPage(IDevice device)
        {
            this.Title ="Extended Device Info";
            if (device == null)
            {
                this.Content = new Label()
                {
                    TextColor = Color.Red,
                    Text = "IDevice has not been configured with the dependency service."
                };
                return;
            }

            var scroll = new ScrollView();
            var stack = new StackLayout();

            #region Display information
            var display = device.Display;
            var displayFrame = new Frame();
            if (display != null)
            {
                displayFrame.Content = new StackLayout()
                            {
                                Children =
                                {
                                    new Label() { Text = display.ToString() },
                                    new Label() { Text = string.Format("Screen width is\t {0:0.0} inches.", display.ScreenWidthInches()) },
                                    new Label() { Text = string.Format("Screen height is\t {0:0.0} inches.", display.ScreenHeightInches()) },
                                    new Label() { Text = string.Format("Screen diagonal size is\t {0:0.0} inches.", display.ScreenSizeInches()) }
                                }
                            };
            }
            else
            {
                displayFrame.Content = new Label() { TextColor = Color.Red, Text = "Device does not contain display information." };
            }

            stack.Children.Add(displayFrame); 
            #endregion

            #region Battery information
            var battery = device.Battery;
            var batteryFrame = new Frame();
            if (battery != null)
            {
                var level = new Label();
                var charger = new Label();

                var levelAction = new Action(() => level.Text = string.Format("Battery level is {0}%.", battery.Level));
                var chargerAction = new Action(() => charger.Text = string.Format("Charger is {0}.", battery.Charging ? "Connected" : "Disconnected"));

                levelAction.Invoke();
                chargerAction.Invoke();

                batteryFrame.Content = new StackLayout()
                {
                    Children = { level, charger }
                };

                battery.OnLevelChange += (s, e) => Device.BeginInvokeOnMainThread(levelAction);

                battery.OnChargerStatusChanged += (s, e) => Device.BeginInvokeOnMainThread(chargerAction);
            }
            else
            {
                batteryFrame.Content = new Label() { TextColor = Color.Red, Text = "Device does not contain battery information." };
            }

            stack.Children.Add(batteryFrame); 
            #endregion

            #region Device Info



            var idLabel = new Label() { Text = "Device Id:" };

            var idText = new Label();

            stack.Children.Add(new Frame()
            {
                Content = new StackLayout()
                {
                    Children = { idLabel, idText }
                }
            });

            try
            {
                idText.Text = device.Id;
            }
            catch (Exception ex)
            {
                idText.Text = ex.Message;
            }

            #endregion

            scroll.Content = stack;

            this.Content = scroll;
        }
    }
}
