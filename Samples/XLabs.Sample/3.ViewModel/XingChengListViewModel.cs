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
        private string _chepaino;

        public XingChengListViewModel(string id,string chepaino)
        {
            //TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
            //DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;
            chepaino = chepaino;
            Firstload(id);
            //this.SearchBarCommand = new Command(async (nothing) =>
            //{
            //    XingChengList = await GetData(keyValues);

            //});
            

            //MessagingCenter.Subscribe<string>(this, "", NavigateToTrace);
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

        public string chepaino
        {
            get
            {
                return _chepaino;
            }
            set
            {
                SetProperty(ref _chepaino, value);
            }
        }
    }
}
