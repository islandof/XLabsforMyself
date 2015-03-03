using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XLabs.Sample.Pages.Monitor
{
    public partial class Trace : ContentPage
    {
        public Trace(string id)
        {
            InitializeComponent();
            Init(id);

        }

        private void Init(string id)
        {
            Webview.Source = "http://cloud.tescar.cn/vehicle/MobileCarTrace?xingchengid=" + id;
        }
    }
}
