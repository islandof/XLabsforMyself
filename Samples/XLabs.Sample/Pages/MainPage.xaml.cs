using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace XLabs.Sample.Pages
{
    public partial class MainPage : ExtendedTabbedPage
    {
        List<string> badges;

        public MainPage()
        {
            Init();
            InitializeComponent();
        }
        
        private void Init()
        {            
            badges.Add("0");
            badges.Add("0");
            badges.Add("3");

            EtTabbedPage.Badges = badges;
        }
    }
}
