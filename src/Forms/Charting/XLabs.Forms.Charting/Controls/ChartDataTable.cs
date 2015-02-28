using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Labs.Charting.Controls
{
    public class ChartDataTable
    {
        public List<ChartColumn> Columns { get; set; }
        public List<object[]> Rows { get; set; }
        public ChartDataTable()
        {
            Columns = new List<ChartColumn>();
            Rows = new List<object[]>();
        }

        public ChartDataTable(List<List<object>> listSource)
        {
            Columns = new List<ChartColumn>();
            Rows = new List<object[]>();
            for (int i = 0; i < listSource.Count; i++)
            {
                addColumn(listSource[i].ToArray(), i, listSource.Count);
            }
        }

        public ChartDataTable(object[][] arraySource)
        {
            Columns = new List<ChartColumn>();
            Rows = new List<object[]>();
            for (int i = 0; i < arraySource.Length; i++)
            {
                addColumn(arraySource[i], i, arraySource.Length);
            }
        }

        private void addColumn(object[] array, int columnNumber, int numberOfColumns)
        {
            ChartColumn column = new ChartColumn(array[0].ToString());
            for (int i = 1; i < array.Length; i++)
            {
                if (Rows.Count >= i)
                {
                    Rows[i-1][columnNumber] = array[i];
                }
                else
                {
                    Rows[i - 1] = new object[numberOfColumns];
                }
            }
        }
    }
}
