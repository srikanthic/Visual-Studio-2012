using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sampledata
{
    class DataTransmitter
    {
        int rows = 0;
        int fromValue = 0;
        int toValue = 0;
        string selectedValue="";
        string selectedcolumns = "";
        string selectedcolumn = "";
        long fromdate = 0;
        long todate = 0;
      //  int rowDelete=-1;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }


        public int FromValue
        {
            get { return fromValue; }
            set { fromValue = value; }
        }

        public int ToValue
        {
            get { return toValue; }
            set { toValue = value; }
        }


        public string SelectedValue
        {
            get { return selectedValue; }
            set { selectedValue = value; }
        }

        public string SelectedColumns
        {
            get { return selectedcolumns; }
            set { selectedcolumns = value; }
        }


        public string SelectedColumn
        {
            get { return selectedcolumn; }
            set { selectedcolumn = value; }
        }

        public long FromDate
        {
            get { return fromdate ; }
            set { fromdate = value; } 
        }

        public long ToDate
        {
            get { return todate ; }
            set { todate = value; }
        }

        public int RowDelete{get;set;}
        public long A { get; set; }
        public long B { get; set; }
        public long C { get; set; }
        public long D { get; set; }
        public long E { get; set; }
        public long F { get; set; }
        public long G { get; set; }
        public long H { get; set; }
        public long I { get; set; }
       
        public string J { get; set; }
        public long K { get; set; }



        
    }
}
