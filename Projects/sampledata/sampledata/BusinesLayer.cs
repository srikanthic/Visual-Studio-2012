using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace sampledata
{
    class BusinesLayer
    {
        DataLayer DL = new DataLayer();
   
       
        public DataSet DisplayData()
        {
            return ( DL.DisplayData());
        }
          

        public DataSet InsertData(DataTransmitter DT)
        {
            return ( DL.InsertData(DT));            
        }

        public DataSet SelectedColumnsDisplay(DataTransmitter DT)
        {
          return( DL.SelectedColumnsDisplay(DT));
            
        }

        internal DataTable  DisplatFloatArrayTable()
        {
            return ( DL.DisplatFloatArrayTable());
           
        }

        internal DataSet SelectedDatesDisplay(DataTransmitter DT)
        {
            return (DL.SelectedDatesDisplay(DT));
          
        }

        internal DataSet DeleteData(DataTransmitter DT)
        {
            return (DL.DeleteData(DT));
        }


        internal DataSet UpdateData(DataTransmitter DT)
        {
            return (DL.UpdateData(DT));
            //throw new NotImplementedException();
        }
    }
}
