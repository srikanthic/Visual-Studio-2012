using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Threading;

using System.Xml.Serialization;


namespace sampledata
{
    public partial class DisplayData : Form
    {
      
        DataSet dataset;//=new DataSet();     
        StringBuilder str = new StringBuilder();
        Random randmnum = new Random();
        DataTransmitter DataTransmit = new DataTransmitter();
        BusinesLayer BLayer = new BusinesLayer();
     
       
        public DisplayData()
        {
            //Thread select = new Thread(btnSubmit_Click());
            InitializeComponent();
        }

        private void DisplayData_Load(object sender, EventArgs e)
        {
       
            try
            {
                
             dataset= BLayer.DisplayData();
                  for (int i = 0; i < dataset.Tables[0].Columns.Count; i++)
                {
                    cmbColumns.Items.Add(dataset.Tables[0].Columns[i].ToString());
                    checkListbox.Items.Add(dataset.Tables[0].Columns[i].ToString());
                    
                }
                      cmbColumns.SelectedIndex = 1;           
            }
            catch
            {
                throw ;
            }

        }     
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
          
            DataTransmit.Rows = int.Parse(txtRows.Text);
            dataset=BLayer.InsertData(DataTransmit);            
            dataGrid.DataSource = dataset.Tables["sample"];            
            }
            catch
            {
                throw;
            }
        }
             

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {  CheckedListBox.CheckedItemCollection objCheckedItem = checkListbox.CheckedItems;
                if (objCheckedItem.Count > 0)
                {
                     for (int iCount = 0; iCount < objCheckedItem.Count; ++iCount)
                    {
                        str.Append(" , " + objCheckedItem[iCount]);
                    }
                    str.Remove(0, 2).ToString();
                }
                DataTransmit.FromValue = int.Parse(txtFrom.Text.ToString());
                DataTransmit.ToValue= int.Parse(txtTo.Text.ToString());
                DataTransmit.SelectedColumns = str.ToString();
                DataTransmit.SelectedColumn = cmbColumns.SelectedItem.ToString();
                dataset = BLayer.SelectedColumnsDisplay(DataTransmit);
                dataGridSearchResults.DataSource = dataset.Tables["sample"];

            }
            catch 
            {
            }
        }
             

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dataset = BLayer.DisplayData();
                dataGrid.DataSource = dataset.Tables["sample"];              
            }
            catch 
            {
            }
        }

        private void _Click(object sender, EventArgs e)
        {
          
        }

        private void SearchOnDates_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dFrom = dateTimeFrom.Value;
                DateTime dTo = dateTimeTo.Value;
                DataTransmit.FromDate = dFrom.Ticks;
                DataTransmit.ToDate = dTo.Ticks;
                dataset = BLayer.SelectedDatesDisplay(DataTransmit);
                dataGridSearchResults.DataSource = dataset.Tables["sample"];
            }
            catch
            {
                throw;
            }

        }

        private void btnBlobData_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable BlobTable = BLayer.DisplatFloatArrayTable();                
                 
                dataGridSearchResults.DataSource = BlobTable;
            }
            catch
            {
                throw;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTransmit.RowDelete = int.Parse(dataGrid.CurrentRow.Cells[0].Value.ToString()); 
                dataset = BLayer.DeleteData(DataTransmit);
               // dataGrid.DataSource = "";
                dataGrid.DataSource = dataset.Tables["sample"];
            }
            catch
            {
                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                DataTransmit.RowDelete = int.Parse(dataGrid.CurrentRow.Cells[0].Value.ToString());
               
                dataset = BLayer.UpdateData(DataTransmit);
                //dataGrid.DataSource = "";
                dataGrid.DataSource = dataset.Tables["sample"];
            }
            catch
            {
                throw;
            }



        }

   

        private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            DataTransmit.A = long.Parse(dataGrid.CurrentRow.Cells[1].Value.ToString());
            DataTransmit.B = long.Parse(dataGrid.CurrentRow.Cells[2].Value.ToString());
            DataTransmit.C = long.Parse(dataGrid.CurrentRow.Cells[3].Value.ToString());
            DataTransmit.D = long.Parse(dataGrid.CurrentRow.Cells[4].Value.ToString());
            DataTransmit.E = long.Parse(dataGrid.CurrentRow.Cells[5].Value.ToString());
            DataTransmit.F = long.Parse(dataGrid.CurrentRow.Cells[6].Value.ToString());
            DataTransmit.G = long.Parse(dataGrid.CurrentRow.Cells[7].Value.ToString());
            DataTransmit.H = long.Parse(dataGrid.CurrentRow.Cells[8].Value.ToString());
            DataTransmit.I = long.Parse(dataGrid.CurrentRow.Cells[9].Value.ToString());
            DataTransmit.J = dataGrid.CurrentRow.Cells[10].Value.ToString();
            DataTransmit.K = long.Parse(dataGrid.CurrentRow.Cells[11].Value.ToString());

        }

     
         
     
    }
}