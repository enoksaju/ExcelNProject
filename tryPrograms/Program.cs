using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryPrograms
{
    class Program
    {
        protected static  DataGridView dataGridView1;
        static void Main( string[] args )
        {

            //dataGridView1 = new DataGridView();

            //dataGridView1.Columns.Add( "column1", "Column1" );
            //dataGridView1.Columns.Add( "column2", "Column2" );
            //dataGridView1.Columns.Add( "column3", "Column3" );

            //dataGridView1.Rows.Add( "1", "1", 2 );
            //dataGridView1.Rows.Add( "2", "1", null );
            //dataGridView1.Rows.Add( "3", "1", 3 );
            //dataGridView1.Rows.Add( "4", "1", 5 );
            //dataGridView1.Rows.Add( "5", "1", 7 );
            //dataGridView1.Rows.Add( "6", "1", null );
            //dataGridView1.Rows.Add( "7", "1", 6);


            //Console.WriteLine("Result= {0}", Sum());

            //Console.ReadLine();

            var frm = new Form1();
            frm.ShowDialog();
        }
        public static int Sum()
        {

            int sum=0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

                int? value= dataGridView1.Rows[i].Cells[2].Value as int?;

                if (value != null) {

                    sum += value.Value;
                }

            }

            return sum;

        }
    }
}
