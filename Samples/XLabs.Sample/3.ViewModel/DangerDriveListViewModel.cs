using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Services;

namespace XLabs.Sample.ViewModel
{
    public class DangerDriveListViewModel : Forms.Mvvm.ViewModel
    {
        private List<DangerDriveViewModel> _dangerDriveList;
        private string _keyValues;

        public DangerDriveListViewModel()
        {
            //TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
            //DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;

            Firstload();
            this.SearchBarCommand = new Command(async (nothing) =>
            {
                DangerDriveList = await GetData(keyValues);

            });
        }

        private async void Firstload()
        {
            DangerDriveList = await GetData("");
        }

        private async Task<List<DangerDriveViewModel>> GetData(string keyValues)
        {
            var _dangerDriveService = new DanDriveService();
            var result = await _dangerDriveService.GetDangerDriveList(keyValues);
            return result.Select(n => new DangerDriveViewModel(n)).ToList();
            //return result;
        }
        

        public List<DangerDriveViewModel> DangerDriveList
        {
            get { return _dangerDriveList; }
            set { SetProperty(ref _dangerDriveList, value); }
        }

        public string keyValues { 
            get
            {
                return _keyValues;
            }
            set
            {
                SetProperty(ref _keyValues,value);
            }
        }

        public ICommand SearchBarCommand { private set; get; }
    }
}
