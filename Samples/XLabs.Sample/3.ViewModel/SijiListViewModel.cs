using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;
using XLabs.Sample.Services;

namespace XLabs.Sample.ViewModel
{
    public class SijiListViewModel : Forms.Mvvm.ViewModel
    {
        private List<SijiViewModel> _sijiList;
        private string _keyValues;

        public SijiListViewModel()
        {
            //TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
            //DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;

            Firstload();
            this.SearchBarCommand = new Command(async (nothing) =>
            {
                ZhalanAlarmList = await GetData(keyValues);

            });
        }

        private async void Firstload()
        {
            ZhalanAlarmList = await GetData("");
        }

        private async Task<List<SijiViewModel>> GetData(string keyValues)
        {
            var _service = new SijiService();
            var result = await _service.GetData(keyValues);
            return result.Select(n => new SijiViewModel(n)).ToList();
            //return result;
        }


        public List<SijiViewModel> ZhalanAlarmList
        {
            get { return _sijiList; }
            set { SetProperty(ref _sijiList, value); }
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

        public ICommand SearchBarCommand { private set; get; }
    }
}
