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
using XingCheng = XLabs.Sample.Model.XingCheng;

namespace XLabs.Sample.ViewModel
{
    public class XingChengViewModel : Forms.Mvvm.ViewModel
    {
        public ICommand NavigateToDetail { private set; get; }

        public ICommand NavigateToTrace { private set; get; }

        public XingChengViewModel(XingCheng item)
        {
            //	_dangerDrive = zhalanAlarm;

            xingchengid = item.xingchengid;
            starttime = item.starttime;
            licheng = item.licheng;
            extlicheng = "里程：" + item.licheng+"千米";
            chepaino = item.chepaino;
            xingshitime = item.xingshitime;
            extxingshitime = "行驶时间：" + item.xingshitime + "秒";
            createtime = item.createtime;
            

            this.NavigateToDetail = new Command(() => MessagingCenter.Send(this, ""));

            //this.NavigateToTrace = new Command(() => MessagingCenter.Send(this.xingchengid, ""));

        }

        public string xingchengid { get; set; }

        public string starttime { get; set; }

        public string licheng { get; set; }

        public string extlicheng { get; set; }

        public string xingshitime { get; set; }

        public string extxingshitime { get; set; }

        public string createtime { get; set; }

        public string chepaino { get; set; }
    }
}
