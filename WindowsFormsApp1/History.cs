using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;//  для excel
using Excel = Microsoft.Office.Interop.Excel;//для excel
using System.Drawing.Printing;//
namespace WindowsFormsApp1
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }
        public List<Clients_class> Clients_Classes = new List<Clients_class>();
        ClassDataBase db = new ClassDataBase();
        private void History_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        void LoadDataFromDB()
        {
            {
                string s = @"SELECT * FROM client where busy=0 ;";
                db.Execute<Clients_class>("Taxi_DB.db", s, ref Clients_Classes);

                for (int i = 0; i < Clients_Classes.Count; i++)
                {
                    dataGridView1.Rows.Add(Clients_Classes[i].Telephone, Clients_Classes[i].From_where, Clients_Classes[i].Otkuda, Clients_Classes[i].Time_time, Clients_Classes[i].Data_time, Clients_Classes[i].Name_avto, Clients_Classes[i].Long_route, Clients_Classes[i].Price, Clients_Classes[i].Color_car, Clients_Classes[i].Nomer_taxometra);


                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void SplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveTable1(dataGridView1);
        }
        void SaveTable1(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "DB_History_Clients.xlsx";

            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < What_Save.RowCount + 1; i++)
            {
                for (int j = 1; j < What_Save.ColumnCount + 1; j++)
                {
                    worksheet.Rows[i].Columns[j] = What_Save.Rows[i - 1].Cells[j - 1].Value;
                }

            }

            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SearchDataFromDB1();
        }
        void SearchDataFromDB1()
        {
            Clients_Classes.Clear();
            string r = "";
            if (comboBox1.Text == "№Таксометра")
                r = @"SELECT * FROM client where nomer_taxometra ='" + textBox1.Text + "' AND busy = 0;";
            else
                if (comboBox1.Text == "Дата")
                r = @"SELECT * FROM client where data_time='" + textBox1.Text + "'AND busy =0;";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clients_Classes.Clear();
                LoadDataFromDB(); dataGridView1.Rows.Clear();
            }
            db.Execute<Clients_class>("Taxi_DB.db", r, ref Clients_Classes);
            for (int i = 0; i < Clients_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Clients_Classes[i].Telephone, Clients_Classes[i].From_where, Clients_Classes[i].Otkuda, Clients_Classes[i].Time_time, Clients_Classes[i].Data_time, Clients_Classes[i].Name_avto, Clients_Classes[i].Long_route, Clients_Classes[i].Price, Clients_Classes[i].Color_car, Clients_Classes[i].Nomer_taxometra);

           }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Text = "";
            comboBox1.Text = "Выберите";
            dataGridView1.Rows.Clear();
           
            Clients_Classes.Clear();
            LoadDataFromDB();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[9], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
        }

        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    }
}
