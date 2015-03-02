using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
    public class QicheViewModel : Forms.Mvvm.ViewModel
    {

        public QicheViewModel(Qiche item)
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
            baoxianlimit = item.baoxianlimit;
            xingshizhenglimit = item.xingshizhenglimit;
            currentlocationx = item.currentlocationx;
            currentlocationy = item.currentlocationy;
            currentspeed = item.currentspeed;
            currentdirect = item.currentdirect;
            createtime = item.createtime;
            ownercompanyid = item.ownercompanyid;
            ownercompanyname = item.ownercompanyname;
            lastactiontime = item.lastactiontime;
            
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
