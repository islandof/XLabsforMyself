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
    public class ZhalanAlarmListViewModel : Forms.Mvvm.ViewModel
    {
        private List<ZhalanAlarmViewModel> _zhalanAlarmList;
        private string _keyValues;

        public ZhalanAlarmListViewModel()
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

        private async Task<List<ZhalanAlarmViewModel>> GetData(string keyValues)
        {
            var _service = new ZhalanAlarmService();
            var result = await _service.GetZhalanAlarmList(keyValues);
            return result.Select(n => new ZhalanAlarmViewModel(n)).ToList();
            //return result;
        }


        public List<ZhalanAlarmViewModel> ZhalanAlarmList
        {
            get { return _zhalanAlarmList; }
            set { SetProperty(ref _zhalanAlarmList, value); }
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
