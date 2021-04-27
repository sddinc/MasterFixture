using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;



namespace MasterFixture
{
    class connection
    {
        public static string dbconnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\admin\\source\\repos\\MasterFixture\\MasterFixture\\fixtureDB.mdb";
        public static OleDbConnection con = new OleDbConnection(dbconnect);
        public static void DB() 
        {
            try 
            { con.Open(); } 
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
