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
    public partial class LookCar : Form
    {
        public LookCar()
        {
            InitializeComponent();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LookCar_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }



        public List<Drivers_class> drivers = new List<Drivers_class>();
        public List<Cars_class> Cars_Classes = new List<Cars_class>();
        ClassDataBase db = new ClassDataBase();

        void LoadDataFromDB()
        {
            {
                // вывод свободных машин
                string s = @"SELECT * FROM car WHERE busy = 0 ;";
                db.Execute<Cars_class>("Taxi_DB.db", s, ref Cars_Classes);

                for (int i = 0; i < Cars_Classes.Count; i++)
                {
                    dataGridView1.Rows.Add(Cars_Classes[i].Nomer_taxometra, Cars_Classes[i].Whoes_avto, Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto, Cars_Classes[i].Color_avto, Cars_Classes[i].Type_avto, Cars_Classes[i].Strahovka_ot, Cars_Classes[i].Strahovka_do);

                }
            }
            {
                //вывод всех машин
                string s1 = @"SELECT * FROM car  WHERE busy AND id>6 ";
                db.Execute<Cars_class>("Taxi_DB.db", s1, ref Cars_Classes);
                for (int i = 0; i < Cars_Classes.Count; i++)
                {
                    dataGridView2.Rows.Add(Cars_Classes[i].Nomer_taxometra, Cars_Classes[i].Whoes_avto, Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto, Cars_Classes[i].Color_avto, Cars_Classes[i].Type_avto, Cars_Classes[i].Strahovka_ot, Cars_Classes[i].Strahovka_do, Cars_Classes[i].Busy);

                }
            }
        }



        void SaveTable1(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "DB_Free_Car.xlsx";

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



        void SaveTable2(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "DB_car.xlsx";

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

            SaveTable1(dataGridView1);
        }

        private void Button6_Click(object sender, EventArgs e)
        {

            SaveTable2(dataGridView1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            text = "Строка 1\n\n";
            text += "Строка 2\nСтрока";

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintpageHandler1;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)

            {
                printDialog.Document.Print();

            }
        }

        private string text1 = "";
        void PrintpageHandler1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(text1, new Font("Arial", 14), Brushes.Black, 0, 0);
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

        private void DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
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
                r = @"SELECT * FROM car where nomer_taxometra='" + textBox1.Text + "';";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cars_Classes.Clear();
                LoadDataFromDB(); dataGridView1.Rows.Clear();
            }
            db.Execute<Cars_class>("Taxi_DB.db", r, ref Cars_Classes);
            for (int i = 0; i < Cars_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Cars_Classes[i].Nomer_taxometra, Cars_Classes[i].Whoes_avto, Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto, Cars_Classes[i].Color_avto, Cars_Classes[i].Type_avto, Cars_Classes[i].Strahovka_ot, Cars_Classes[i].Strahovka_do);

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Text = "";
            comboBox1.Text = "Выберите";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            Cars_Classes.Clear();
            LoadDataFromDB();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
           
            dataGridView2.Rows.Clear();
            SearchDataFromDB2();
        }

        void SearchDataFromDB2()
        {
            Cars_Classes.Clear();
            string r = "";
            if (comboBox2.Text == "№Таксометра")
                r = @"SELECT * FROM car where nomer_taxometra ='" + textBox2.Text + "';";
            else
                if (comboBox2.Text == "Имя машины")
                r = @"SELECT * FROM car where nomer_taxometra='" + textBox2.Text + "';";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cars_Classes.Clear();
                LoadDataFromDB(); dataGridView2.Rows.Clear();
            }
            db.Execute<Cars_class>("Taxi_DB.db", r, ref Cars_Classes);
            for (int i = 0; i < Cars_Classes.Count; i++)
            {
                dataGridView2.Rows.Add(Cars_Classes[i].Nomer_taxometra, Cars_Classes[i].Whoes_avto, Cars_Classes[i].Gos_name, Cars_Classes[i].Name_avto, Cars_Classes[i].Color_avto, Cars_Classes[i].Type_avto, Cars_Classes[i].Strahovka_ot, Cars_Classes[i].Strahovka_do);

            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            textBox2.Text = "";
            comboBox2.Text = "Выберите";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            Cars_Classes.Clear();
            LoadDataFromDB();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
        }

    
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[7], ListSortDirection.Ascending);
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {

            dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {

            dataGridView2.Sort(dataGridView2.Columns[6], ListSortDirection.Ascending);
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

            dataGridView2.Sort(dataGridView2.Columns[7], ListSortDirection.Ascending);
        }

        private void GroupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void LookCar_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }
    }
}
