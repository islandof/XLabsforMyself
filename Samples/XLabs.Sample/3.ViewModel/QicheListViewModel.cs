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
	public class QicheListViewModel : Forms.Mvvm.ViewModel
	{
		public ICommand SearchBarCommand { private set; get; }

		private List<QicheViewModel> _qicheList;
		private string _keyValues;

		public QicheListViewModel ()
		{
			//TaskDangerDriveList = new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""));
			//DangerDriveList = (new NotifyTaskCompletion<List<DangerDriveViewModel>> (GetDangerDriveList (""))).Result;

			Firstload ();
			this.SearchBarCommand = new Command (async (nothing) => {
				QicheList = await GetData (keyValues);

			});
			MessagingCenter.Subscribe<QicheViewModel> (this, "", NavigateToDetail);

			MessagingCenter.Subscribe<string> (this, "", NavigateToTrace);
		}

		private async void NavigateToDetail (QicheViewModel item)
		{
			await Navigation.PushAsync (new QichePage { Title = item.chepaino + "的详细信息", BindingContext = item });
		}

		private async void NavigateToTrace (string item)
		{
			await Navigation.PushAsync (new QichePage (), true);
			//await Navigation.PushAsync(new Trace {Title = "轨迹查询",BindingContext = item});
			//await Navigation.PushAsync(new QichePage { Title = item.chepaino + "的详细信息", BindingContext = item });
		}

		private async void Firstload ()
		{
			QicheList = await GetData ("");
		}

		private async Task<List<QicheViewModel>> GetData (string keyValues)
		{
			var _service = new QicheService ();
			var result = await _service.GetData (keyValues);
			return result.Select (n => new QicheViewModel (n)).ToList ();
			//return result;
		}


		public List<QicheViewModel> QicheList {
			get { return _qicheList; }
			set { SetProperty (ref _qicheList, value); }
		}

		public string keyValues {
			get {
				return _keyValues;
			}
			set {
				SetProperty (ref _keyValues, value);
			}
		}
	}
}
