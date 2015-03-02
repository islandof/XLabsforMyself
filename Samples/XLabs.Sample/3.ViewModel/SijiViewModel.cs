﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
    public class SijiViewModel : Forms.Mvvm.ViewModel
    {

        public SijiViewModel(Siji item)
        {
            //	_dangerDrive = zhalanAlarm;
            sijiid = item.sijiid;
            sijiname = item.sijiname;
            lianxidianhua = item.lianxidianhua;
            jiashizhengriqi = item.jiashizhengriqi;
            createtime = item.createtime;
            companyid = item.companyid;
            ownercompanyid = item.ownercompanyid;
            ownercompanyname = item.ownercompanyname;
            
        }

        public string sijiid { get; set; }

        public string sijiname { get; set; }

        public string lianxidianhua { get; set; }

        public string jiashizhengriqi { get; set; }

        public string createtime { get; set; }

        public string companyid { get; set; }

        public string ownercompanyid { get; set; }

        public string ownercompanyname { get; set; }
    }
}
