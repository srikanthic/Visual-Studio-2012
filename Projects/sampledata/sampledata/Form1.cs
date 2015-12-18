using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sampledata
{
    public partial class frmMain : Form
    {

        StringBuilder s = new StringBuilder();
        public frmMain()
        {
        
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            //foreach (object itemChecked in checkedListBox1.CheckedItems)
            //{
            //    MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
            //               "\", is checked. Checked state is: " +
            //               checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");

            //}
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection objCheckedItem = checkedListBox1.CheckedItems;
            if (objCheckedItem.Count > 0)
            {
               // s.Clear();               
                for (int iCount = 0; iCount < objCheckedItem.Count; ++iCount)
                {
                  
                    s.Append(" , "+objCheckedItem[iCount]);
                }
                MessageBox.Show(s.Remove(0,2).ToString());
            }
            
            //foreach (int indexChecked in checkedListBox1.CheckedIndices)
            //{
                //// The indexChecked variable contains the index of the item.
                //MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
                //                checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");

        //          foreach(object itemChecked in checkedListBox1.CheckedItems) {

        //// Use the IndexOf method to get the index of an item.
        //MessageBox.Show("Item with title: \"" + itemChecked.ToString() + 
        //                "\", is checked. Checked state is: " + 
        //                checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");


            //}
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                s.Append(itemChecked.ToString());
               

            }
          
        }
    }
}

