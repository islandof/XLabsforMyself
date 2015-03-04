using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Sample;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
	public class SijiViewModel : Forms.Mvvm.ViewModel
	{
		private readonly IDevice _device;

		public ICommand NavigateToDetail { private set; get; }

		public ICommand CallCommand { private set; get; }

		public SijiViewModel (Siji item)
		{
			//	_dangerDrive = zhalanAlarm;
			_device = Resolver.Resolve<IDevice> ();
			sijiid = item.sijiid;
			sijiname = item.sijiname;
			lianxidianhua = item.lianxidianhua;
			if (!string.IsNullOrEmpty (item.jiashizhengriqi)) {
				jiashizhengriqi = item.jiashizhengriqi.Replace ("T", " ").Substring (0, 10);
				;
			}
			if (!string.IsNullOrEmpty (item.createtime)) {
				createtime = item.createtime.Replace ("T", " ");
			}
			companyid = item.companyid;
			ownercompanyid = item.ownercompanyid;
			ownercompanyname = item.ownercompanyname;

			extdetail = item.ownercompanyname + " " + item.lianxidianhua;
			this.NavigateToDetail = new Command (() => MessagingCenter.Send (this, ""));

			this.CallCommand = new Command (
				() => _device.PhoneService.DialNumber (lianxidianhua),
				() => _device.PhoneService != null);

		}

		public string sijiid { get; set; }

		public string sijiname { get; set; }

		public string lianxidianhua { get; set; }

		public string jiashizhengriqi { get; set; }

		public string createtime { get; set; }

		public string companyid { get; set; }

		public string ownercompanyid { get; set; }

		public string ownercompanyname { get; set; }

		public string extdetail { get; set; }
	}
}
