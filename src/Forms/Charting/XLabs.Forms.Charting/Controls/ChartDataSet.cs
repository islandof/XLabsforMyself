using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Labs.Charting.Controls
{
    public class ChartDataSet
    {
        public List<ChartDataTable> Tables { get; set; }

        public ChartDataSet()
        {
            Tables = new List<ChartDataTable>();
        }
    }
}
