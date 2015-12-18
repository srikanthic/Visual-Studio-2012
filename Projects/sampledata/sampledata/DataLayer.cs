using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Collections;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Threading;


namespace sampledata
{
    class DataLayer
    { 
        SQLiteConnection  mDBcon = new SQLiteConnection(@"Data Source=C:\Users\EMPLOYEE-05\Documents\Visual Studio 2012\Projects\sampledata\sampledata\bin\DebugDemoT16.db"); 
        SQLiteDataAdapter datadapter;        
        SQLiteCommand cmd;
        DataSet dataset = new DataSet();
        IDbTransaction trans;       
        Random randmnum = new Random();
       
        public void CreateFile()
        {

            if (!File.Exists(@"C:\Users\EMPLOYEE-05\Documents\Visual Studio 2012\Projects\sampledata\sampledata\bin\Debug\DemoT16.db"))
            {
                cmd = new SQLiteCommand(mDBcon);
                mDBcon.Open();
                cmd.CommandText = "CREATE TABLE sample(ID INTEGER PRIMARY KEY AUTOINCREMENT ,A REAL,B REAL,C REAL,D REAL,E REAL,F REAL,G REAL,H REAL,I REAL,J VARCHAR(25),K TEXT(25))";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE TABLE if not exists  FloatArray(SID INTEGER,A BLOB)";
                cmd.ExecuteNonQuery();
                mDBcon.Close();
                cmd = new SQLiteCommand(mDBcon);
             
            }

        
        
        }
          public DataSet DisplayData( )
        {
            CreateFile();
            mDBcon.Open();
            DataSet dataset = new DataSet();
             cmd = new  SQLiteCommand(mDBcon);          
            cmd.CommandText = "select * from sample";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(dataset, "sample");
            mDBcon.Close();
            return dataset;  
 
        }
        public DataSet InsertData(DataTransmitter DT)
        {
          try
            {
               
                mDBcon.Open();
                trans = mDBcon.BeginTransaction();            
                SQLiteCommand cmd = new SQLiteCommand(mDBcon);
                SQLiteParameter A = new SQLiteParameter("@A");
                cmd.Parameters.Add(A);
                SQLiteParameter B = new SQLiteParameter("@B");
                cmd.Parameters.Add(B);
                SQLiteParameter C = new SQLiteParameter("@C");
                cmd.Parameters.Add(C);
                SQLiteParameter D = new SQLiteParameter("@D");
                cmd.Parameters.Add(D);
                SQLiteParameter E = new SQLiteParameter("@E");
                cmd.Parameters.Add(E);
                SQLiteParameter F = new SQLiteParameter("@F");
                cmd.Parameters.Add(F);
                SQLiteParameter G = new SQLiteParameter("@G");
                cmd.Parameters.Add(G);
                SQLiteParameter H = new SQLiteParameter("@H");
                cmd.Parameters.Add(H);
                SQLiteParameter I = new SQLiteParameter("@I");
                cmd.Parameters.Add(I);
                SQLiteParameter J = new SQLiteParameter("@J");
                cmd.Parameters.Add(J);
                SQLiteParameter K = new SQLiteParameter("@K");
                cmd.Parameters.Add(K);
                cmd.CommandText = "insert into sample(A ,B,C,D,E,F,G,H,I,J,K) VALUES(@A ,@B,@C,@D,@E,@F,@G,@H,@I,@J,@K)";// + +"," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + "," + randmnum.Next() + ")"; 
                SQLiteCommand cmdsSubinsert = new SQLiteCommand(mDBcon);
                cmdsSubinsert.CommandText = "insert into FloatArray(SID,A) VALUES(@SID,@S)";
                SQLiteParameter S = new SQLiteParameter("@S");
                cmdsSubinsert.Parameters.Add(S);
                SQLiteParameter SID = new SQLiteParameter("@SID");
                cmdsSubinsert.Parameters.Add(SID);
                for (int i = 0; i <DT.Rows; i++)
                {
                    A.Value = randmnum.Next(0, 5000);
                    B.Value = randmnum.Next(0, 5000);
                    C.Value = randmnum.Next(0, 5000);
                    D.Value = randmnum.Next(0, 5000);
                    E.Value = randmnum.Next(0, 5000);
                    F.Value = randmnum.Next(0, 5000);
                    G.Value = randmnum.Next(0, 5000);
                    H.Value = randmnum.Next(0, 5000);
                    I.Value = randmnum.Next(0, 5000);
                    J.Value = "Camo";
                    K.Value = DateTime.Now.Ticks;
                    cmd.ExecuteNonQuery();
                    float[] array = new float[1000];
                    for (int k = 0; k < 1000; k++)
                    {
                        array[k] = randmnum.Next(0, 5000);

                    }
                    Byte[] byteArray;
                    byteArray = new byte[array.Length * 4];
                    Buffer.BlockCopy(array, 0, byteArray, 0, byteArray.Length);
                    S.Value = byteArray;
                    SID.Value = i;
                    cmdsSubinsert.ExecuteNonQuery();
                }
                trans.Commit();
                mDBcon.Close();
                dataset = DisplayData();              

            }
          catch
          {

          }
          return dataset;

        }

        internal DataSet SelectedColumnsDisplay(DataTransmitter DT)
        {
            cmd = new SQLiteCommand(mDBcon);
            DataSet  ds = new DataSet();
            mDBcon.Open();            
            cmd.CommandText = "select  " + DT.SelectedColumns + "  from sample where  " +DT.SelectedColumn   + "  between " +DT.FromValue  + " and " + DT.ToValue+" ";
            datadapter = new SQLiteDataAdapter(cmd);
             datadapter.Fill(ds, "sample");
             mDBcon.Close();
             return ds;
        }


        internal DataTable  DisplatFloatArrayTable()
        {
            try
            {
                cmd = new SQLiteCommand(mDBcon);
                mDBcon.Open();
                cmd.CommandText = "select A from FloatArray";
                datadapter = new SQLiteDataAdapter(cmd);
                datadapter.Fill(dataset, "FloatArray");
                mDBcon.Close();
                DataTable BlobTable = new DataTable();
                DataColumn dtColumn;
                DataRow dtRow;
                // Create id Column
                dtColumn = new DataColumn();
                dtColumn.ColumnName = "ID";
                dtColumn.Caption = "ID";
                BlobTable.Columns.Add(dtColumn);
                dtColumn = new DataColumn();
                dtColumn.ColumnName = "RowNo";
                dtColumn.Caption = "RowNo";
                BlobTable.Columns.Add(dtColumn);


                // Create Address column.
                dtColumn = new DataColumn();
                dtColumn.ColumnName = "BlobData";
                dtColumn.Caption = "BlobData";
                BlobTable.Columns.Add(dtColumn);



                for (int i = 1; i < dataset.Tables[0].Rows.Count; i++)
                {

                    byte[] Bytearray_size = (byte[])dataset.Tables[0].Rows[i][0] ;
                    if (Bytearray_size == null)
                        return null;
                    float[] floatArray = new float[Bytearray_size.Length / 4];
                    Buffer.BlockCopy(Bytearray_size, 0, floatArray, 0, Bytearray_size.Length);


                    for (int j = 0; j < floatArray.Length; j++)
                    {

                        dtRow = BlobTable.NewRow();
                        dtRow["ID"] = i;
                        dtRow["RowNo"] = j + 1;
                        dtRow["BlobData"] = floatArray[j];
                        BlobTable.Rows.Add(dtRow);
                    }

                }
                return BlobTable;
            }
            catch { throw; }
            
            
        }



        internal DataSet SelectedDatesDisplay(DataTransmitter DT)
        {
            cmd = new SQLiteCommand(mDBcon);
            DataSet ds = new DataSet();
            mDBcon.Open();
            cmd.CommandText = "select  *  from sample where  K  between " + DT.FromDate + " and " + DT.ToDate+ " ";
            datadapter = new SQLiteDataAdapter(cmd);
            datadapter.Fill(ds, "sample");
            mDBcon.Close();
            return ds;
        }


        
        internal DataSet DeleteData(DataTransmitter DT)
        {

            cmd = new SQLiteCommand(mDBcon);
            DataSet ds = new DataSet();
            mDBcon.Open();
            cmd.CommandText = "delete  from sample where ID=" + DT.RowDelete+" ";
            cmd.ExecuteNonQuery();        
           
            mDBcon.Close();
            ds = DisplayData();
            return ds;

            
        }

        internal DataSet UpdateData(DataTransmitter DT)
        {
            cmd = new SQLiteCommand(mDBcon);
            DataSet ds = new DataSet();
            mDBcon.Open();
            cmd.CommandText = "Update   sample set A="+DT.A+",B="+DT.B+",C="+DT.C+",D="+DT.D+",E="+DT.E+",F="+DT.F+",G="+DT.G+",H="+DT.H+",I="+DT.I+",J='"+DT.J+"',K="+DT.K+"  where ID=" + DT.RowDelete + " ";
            cmd.ExecuteNonQuery();
            mDBcon.Close();
            ds = DisplayData();
            return ds;

            //throw new NotImplementedException();
        }
    }
}
