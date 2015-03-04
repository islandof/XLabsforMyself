using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Sample;
using XLabs.Forms.Mvvm;
using XLabs.Sample.Pages.Manage;
using Qiche = XLabs.Sample.Model.Qiche;

namespace XLabs.Sample.ViewModel
{
	public class QicheViewModel : Forms.Mvvm.ViewModel
	{
		public ICommand NavigateToDetail { private set; get; }

		public ICommand NavigateToTrace { private set; get; }

		public QicheViewModel (Qiche item)
		{
			//	_dangerDrive = zhalanAlarm;

			qicheid = item.qicheid;
			tboxid = item.tboxid;
			vin = item.vin;
			chepaino = item.chepaino;
			brandid = item.brandid;
			brandname = item.brandname;
			seriesid = item.seriesid;
			seriesname = item.seriesname;
			styleid = item.styleid;
			stylename = item.stylename;
			sijiid = item.sijiid;
			sijiname = item.sijiname;
			initavgpenyou = item.initavgpenyou;
			if (!string.IsNullOrEmpty (item.baoxianlimit)) {
				baoxianlimit = item.baoxianlimit.Replace ("T", " ").Substring (0, 10);    
			}            
			xingshizhenglimit = item.xingshizhenglimit;
			currentlocationx = item.currentlocationx;
			currentlocationy = item.currentlocationy;
			currentspeed = item.currentspeed;
			currentdirect = item.currentdirect;
			if (!string.IsNullOrEmpty (item.createtime)) {
				createtime = item.createtime.Replace ("T", " ");
			}            
			ownercompanyid = item.ownercompanyid;
			ownercompanyname = item.ownercompanyname;
			if (!string.IsNullOrEmpty (item.lastactiontime)) {
				lastactiontime = item.lastactiontime.Replace ("T", " ");
			}

			this.NavigateToDetail = new Command (() => MessagingCenter.Send (this, ""));

			this.NavigateToTrace =
                new Command (() => MessagingCenter.Send (this, "XingChengTrace"));

		}

		public string qicheid { get; set; }

		public string tboxid { get; set; }

		public string vin { get; set; }

		public string chepaino { get; set; }

		public string brandid { get; set; }

		public string brandname { get; set; }

		public string seriesid { get; set; }

		public string seriesname { get; set; }

		public string styleid { get; set; }

		public string stylename { get; set; }

		public string sijiid { get; set; }

		public string sijiname { get; set; }

		public string initavgpenyou { get; set; }

		public string baoxianlimit { get; set; }

		public string xingshizhenglimit { get; set; }

		public string currentlocationx { get; set; }

		public string currentlocationy { get; set; }

		public string currentspeed { get; set; }

		public string currentdirect { get; set; }

		public string createtime { get; set; }

		public string ownercompanyid { get; set; }

		public string ownercompanyname { get; set; }

		public string lastactiontime { get; set; }
	}
}
