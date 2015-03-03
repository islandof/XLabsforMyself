using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Sample;
using XLabs.Forms.Mvvm;
using XLabs.Sample.Model;
using XLabs.Sample.Pages.Manage;
using XLabs.Sample.Services;
using XLabs.Sample.Pages.Monitor;

namespace XLabs.Sample.ViewModel
{
    public class XingChengListViewModel : Forms.Mvvm.ViewModel
    {
        public ICommand SearchBarCommand { private set; get; }
        
        private List<XingChengViewModel> _xingChengList;
        private string _keyValues;

        public XingChengListViewModel(string id)
        {
            //TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
            //DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;

            Firstload(id);
            //this.SearchBarCommand = new Command(async (nothing) =>
            //{
            //    XingChengList = await GetData(keyValues);

            //});
            

            //MessagingCenter.Subscribe<string>(this, "", NavigateToTrace);
        }

        private async void NavigateToDetail(XingChengViewModel item)
        {
            this.keyValues = item.xingchengid;
            await Navigation.PushAsync(new Trace {Title = "轨迹查询"});
            //await Navigation.PushAsync(new XingChengPage { Title = item.chepaino + "的详细信息", BindingContext = item });
        }

        private async void NavigateToTrace(string item)
        {
            //await Navigation.PushAsync(new XingChengPage());
            //await Navigation.PushAsync(new Trace {Title = "轨迹查询",BindingContext = item});
            //await Navigation.PushAsync(new XingChengPage { Title = item.chepaino + "的详细信息", BindingContext = item });
        }

        private async void Firstload(string item)
        {
            XingChengList = await GetData(item);
        }

        private async Task<List<XingChengViewModel>> GetData(string keyValues)
        {
            var _service = new XingChengService();
            var result = await _service.GetData(keyValues);
            return result.Select(n => new XingChengViewModel(n)).ToList();
            //return result;
        }


        public List<XingChengViewModel> XingChengList
        {
            get { return _xingChengList; }
            set { SetProperty(ref _xingChengList, value); }
        }

        public string keyValues
        {
            get
            {
                return _keyValues;
            }
            set
            {
                SetProperty(ref _keyValues, value);
            }
        }        
    }
}
