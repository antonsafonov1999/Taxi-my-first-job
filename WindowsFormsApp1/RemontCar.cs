using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;// это и ниже для excel
using Excel = Microsoft.Office.Interop.Excel;//
using System.Drawing.Printing;//
namespace WindowsFormsApp1
{
    public partial class RemontCar : Form
    {
        public RemontCar()
        {
            InitializeComponent();
        }


        public List<Drivers_class> drivers = new List<Drivers_class>();
        public List<Cars_class> Cars_Classes = new List<Cars_class>();
        ClassDataBase db = new ClassDataBase();




        private void Button3_Click(object sender, EventArgs e)
        {                     
           remontCar();
              MessageBox.Show("Машины исправлены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.Rows.Clear();
            Cars_Classes.Clear();
            LoadDataFromDB();
        }

        private void remontCar()
        {
           

            string s = @"SELECT * FROM car WHERE id > 6 and busy = 0;";
            db.Execute<Cars_class>("Taxi_DB.db", s, ref Cars_Classes);
          
            for (int i = 0; i < Cars_Classes.Count; i++)
            {
                textBox3.Text = Cars_Classes[i].Remont;
                textBox4.Text = Cars_Classes[i].Salary_day;
            
              string  o =textBox3.Text;
               int l =Convert.ToInt32(  textBox4.Text);
                if (Convert.ToInt32(o)<Convert.ToInt32(l))
                {
                  l = Convert.ToInt32( l) - Convert.ToInt32( o);
                 //   l =Convert.ToInt32( textBox4.Text);
                    string ss = @"UPDATE sotrudnik SET salary_day  = '" + l + "' WHERE nomer_taxometra = '" + Cars_Classes[i].Nomer_taxometra + "'; "; //Запрос на заполнении зарплаты 
                    string cs = @"UPDATE car SET salary_day  = '" + l+ "' WHERE nomer_taxometra = '" + Cars_Classes[i].Nomer_taxometra + "'; "; //Запрос на заполнении зарплаты 
                    string cr = @"UPDATE car SET remont  = '" + 0 + "' WHERE nomer_taxometra = '" + Cars_Classes[i].Nomer_taxometra + "'; ";//Запрос на заполнении ремонта
                    string sr = @"UPDATE sotrudnik SET remont  = '" + 0 + "' WHERE nomer_taxometra = '" + Cars_Classes[i].Nomer_taxometra + "'; ";//Запрос на заполнении ремонта     
                    int t = db.ExecuteNonQuery("Taxi_DB.db", ss);
                    int t2 = db.ExecuteNonQuery("Taxi_DB.db", cs);
                    int t3 = db.ExecuteNonQuery("Taxi_DB.db", cr);
                    int t4 = db.ExecuteNonQuery("Taxi_DB.db", sr);
                   
                }
               
            }
          
        }

        void SaveTable(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "BD_Remont_Car.xlsx";

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
        private void Button1_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RemontCar_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }


        void LoadDataFromDB()
        {
            string s = @"SELECT * FROM car WHERE id > 6 and busy = 0;";
           db.Execute<Cars_class>("Taxi_DB.db", s, ref Cars_Classes);

            for (int i = 0; i < Cars_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Cars_Classes[i].Nomer_taxometra,Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto,Cars_Classes[i].Strahovka_ot,Cars_Classes[i].Strahovka_do,Cars_Classes[i].Salary_day, Cars_Classes[i].Remont);
            }
          
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            text = "Строка 1\n\n";
            text += "Строка 2\nСтрока";

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintpageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)

            {
                printDialog.Document.Print();

            }
        }
        private string text = "";
        void PrintpageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SearchDataFromDB1();
        }
        void SearchDataFromDB1()
        {
            Cars_Classes.Clear();
            string r = "";
            if (comboBox1.Text == "№Таксометра")
                r = @"SELECT * FROM car where nomer_taxometra ='" + textBox1.Text + "' AND busy = 0;";
            else
                if (comboBox1.Text == "Имя машины")
                r = @"SELECT * FROM car where name_avto ='" + textBox1.Text + "'  AND busy = 0;";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cars_Classes.Clear();
                LoadDataFromDB();
                dataGridView1.Rows.Clear();
            }
            db.Execute<Cars_class>("Taxi_DB.db", r, ref Cars_Classes);
            for (int i = 0; i < Cars_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Cars_Classes[i].Nomer_taxometra, Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto, Cars_Classes[i].Strahovka_ot, Cars_Classes[i].Strahovka_do, Cars_Classes[i].Salary_day, Cars_Classes[i].Remont);

            }

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            textBox1.Text = "";
            comboBox1.Text = "Выберите";
            dataGridView1.Rows.Clear();
                     Cars_Classes.Clear();
            LoadDataFromDB();
        }

      

        private void RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[5], ListSortDirection.Ascending);
        }

        private void RemontCar_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
