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
    public class QicheListViewModel : Forms.Mvvm.ViewModel
    {
        public ICommand SearchBarCommand { private set; get; }
        public ICommand NavigateToDetail { private set; get; }
        private List<QicheViewModel> _qicheList;
        private string _keyValues;

        public QicheListViewModel()
        {
            //TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
            //DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;

            Firstload();
            this.SearchBarCommand = new Command(async (nothing) =>
            {
                QicheList = await GetData(keyValues);

            });
            this.NavigateToDetail = new Command(async (nothing) =>
            {
                
            });
        }

        private async void Firstload()
        {
            QicheList = await GetData("");
        }

        private async Task<List<QicheViewModel>> GetData(string keyValues)
        {
            var _service = new QicheService();
            var result = await _service.GetData(keyValues);
            return result.Select(n => new QicheViewModel(n)).ToList();
            //return result;
        }


        public List<QicheViewModel> QicheList
        {
            get { return _qicheList; }
            set { SetProperty(ref _qicheList, value); }
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
