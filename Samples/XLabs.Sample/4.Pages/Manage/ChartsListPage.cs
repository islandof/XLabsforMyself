using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Sample.Pages.Controls.Charts;
using XLabs.Sample.Pages.Mvvm;

namespace XLabs.Sample.Pages.Manage
{
    class ChartsListPage:ContentPage
    {
        public ChartsListPage ()
        {
            var listItems = new SortedDictionary<string, Type>
            {
                 {"柱状图", typeof(BarChartPage)},
                 {"线柱图", typeof(LineChartPage)},
                 {"复合图表", typeof(CombinationPage)},
                 {"饼状图", typeof(PieChartPage)},
                 {"动态复合图表", typeof(BoundChartPage)},
                 {"可手动调整的图表", typeof(CanvasWebHybrid)}
            };
            
            this.Title = "图表";
            this.Icon = Device.OnPlatform("pie30_32.png", "pie30_32.png", "Images/pie30_32.png");
            this.Content = BuildListView(this, listItems);
        }

        /// <summary>
        /// Build a ListView associated with a SortedDictionary as the DataSource
        /// </summary>
        /// <param name="mainPage">Parent page for the page containing the list view</param>
        /// <param name="listItems">List of items to display</param>
        /// <returns></returns>
        private static ListView BuildListView(VisualElement mainPage, SortedDictionary<string, Type> listItems)
        {
            var listView = new ListView
            {
                ItemsSource = listItems,
                ItemTemplate = new DataTemplate(typeof(TextCell)),
            };

            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Key");

            listView.ItemSelected += async (sender, e) =>
            {
                Type result = null;

                // This is actually some type of bug with Xamarin.
                // On iOS the SortedDiectionary entries are DictionaryEntries
                // on WP, they are KeyValuePairs.
                // Using the wrong type causes a casting exception.
                switch (Device.OS)
                {
                    case TargetPlatform.Android:
                    case TargetPlatform.iOS:
                        var item = (DictionaryEntry)e.SelectedItem;
                        result = (Type)item.Value;
                        break;
                    case TargetPlatform.WinPhone:
                        result = ((KeyValuePair<string, Type>)e.SelectedItem).Value;
                        break;
                }

                await ShowPage(mainPage, result);
            };

            return listView;
        }

        /// <summary>
        /// Shows a page asynchronously by locating the default constructor, creating the page,
        /// the pushing it onto the navigation stack.
        /// </summary>
        /// <param name="parentPage">Parent Page</param>
        /// <param name="pageType">Type of page to show</param>
        /// <returns></returns>
        private static async Task ShowPage(VisualElement parentPage, Type pageType)
        {
            // Get all the constructors of the page type.
            var constructors = pageType.GetTypeInfo().DeclaredConstructors;

            foreach (
                var page in
                    from constructor in constructors
                    where constructor.GetParameters().Length == 0
                    select (Page)constructor.Invoke(null))
            {
                await parentPage.Navigation.PushAsync(page);

                break;
            }
        }
    }
}
