using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
    public class DangerDriveViewModel : Forms.Mvvm.ViewModel
    {
        public DangerDriveViewModel(DangerDrive dangerDrive)
        {
            ownercompanyname = dangerDrive.ownercompanyname;
            chepaino = dangerDrive.chepaino;
            Ala10 = dangerDrive.Ala10;
            Ala11 = dangerDrive.Ala11;
            Ala12 = dangerDrive.Ala12;
            Ala13 = dangerDrive.Ala13;
            Ala14 = dangerDrive.Ala14;
            Ala15 = dangerDrive.Ala15;
            Ala16 = dangerDrive.Ala16;
            Ala17 = dangerDrive.Ala17;
            Ala18 = dangerDrive.Ala18;
            Ala19 = dangerDrive.Ala19;
            Ala20 = dangerDrive.Ala20;

            Ala21 = dangerDrive.Ala21;

            Ala30 = dangerDrive.Ala30;
            Ala31 = dangerDrive.Ala31;
            Ala32 = dangerDrive.Ala32;
            Ala33 = dangerDrive.Ala33;
            Ala34 = dangerDrive.Ala34;
            Ala35 = dangerDrive.Ala35;
        }

        public string ownercompanyname { get; set; }

        public string chepaino { get; set; }

        public string Ala10 { get; set; }

        public string Ala11 { get; set; }

        public string Ala12 { get; set; }

        public string Ala13 { get; set; }

        public string Ala14 { get; set; }

        public string Ala15 { get; set; }

        public string Ala16 { get; set; }

        public string Ala17 { get; set; }

        public string Ala18 { get; set; }

        public string Ala19 { get; set; }

        public string Ala20 { get; set; }

        public string Ala21 { get; set; }

        public string Ala30 { get; set; }

        public string Ala31 { get; set; }

        public string Ala32 { get; set; }

        public string Ala33 { get; set; }

        public string Ala34 { get; set; }

        public string Ala35 { get; set; }

    }
}
