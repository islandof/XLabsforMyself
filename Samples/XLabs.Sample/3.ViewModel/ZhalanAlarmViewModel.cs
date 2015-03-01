using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
    public class ZhalanAlarmViewModel : Forms.Mvvm.ViewModel
    {

        public ZhalanAlarmViewModel(ZhalanAlarm zhalanAlarm)
        {
            //	_dangerDrive = zhalanAlarm;

            alarmid = zhalanAlarm.alarmid;
            tboxid = zhalanAlarm.tboxid;
            qicheid = zhalanAlarm.qicheid;
            xingchengid = zhalanAlarm.xingchengid;
            zhalanid = zhalanAlarm.zhalanid;
            zhalantype = zhalanAlarm.zhalantype;
            zhalanname = zhalanAlarm.zhalanname;
            condition = zhalanAlarm.condition;
            dthappen = zhalanAlarm.dthappen;
            hasalarm = zhalanAlarm.hasalarm;
            createtime = zhalanAlarm.createtime;
            ownercompanyname = zhalanAlarm.ownercompanyname;
            chepaino = zhalanAlarm.chepaino;
            ownercompanyid = zhalanAlarm.ownercompanyid;
            companyid = zhalanAlarm.companyid;

        }

        public string alarmid { get; set; }

        public string tboxid { get; set; }

        public string qicheid { get; set; }

        public string xingchengid { get; set; }

        public string zhalanid { get; set; }

        public string zhalantype { get; set; }

        public string zhalanname { get; set; }

        public string condition { get; set; }

        public string dthappen { get; set; }

        public string hasalarm { get; set; }

        public string createtime { get; set; }

        public string chepaino { get; set; }

        public string ownercompanyid { get; set; }

        public string ownercompanyname { get; set; }

        public string companyid { get; set; }
    }
}
