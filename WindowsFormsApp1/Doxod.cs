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
    public partial class Doxod : Form
    {
        public Doxod()
        {
            InitializeComponent();
        }
        public List<Drivers_class> drivers = new List<Drivers_class>();
        ClassDataBase db = new ClassDataBase();

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Doxod_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

       private void LoadDataFromDB()
        { 
     
                string s = @"SELECT * FROM sotrudnik;";
                db.Execute<Drivers_class>("Taxi_DB.db", s, ref drivers);
                for (int i = 0; i < drivers.Count; i++)
                {
                    dataGridView1.Rows.Add(drivers[i].Nomer_taxometra, drivers[i].Name, drivers[i].Familia,  drivers[i].Adress, drivers[i].Telephone,  drivers[i].Whoes_avto, drivers[i].Stach_robot, drivers[i].Salary_day);
                
            }
        }






        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("История удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        void SaveTable(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Save_BAza.xlsx";

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

        private void Button2_Click_1(object sender, EventArgs e)
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

        private void Button5_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            SearchDataFromDB1();
        }

        void SearchDataFromDB1()
        {
            drivers.Clear();
            string r = "";
            if (comboBox1.Text == "№Таксометра")
                r = @"SELECT * FROM sotrudnik where nomer_taxometra ='" + textBox1.Text + "' AND busy = 0;";
            else
                if (comboBox1.Text == "Имя")
                r = @"SELECT * FROM sotrudnik where name='" + textBox1.Text + "' AND busy = 0;";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка, MessageBoxButtons.OK, MessageBoxIcon.Information");
                drivers.Clear();
                LoadDataFromDB(); dataGridView1.Rows.Clear();
            }
            db.Execute<Drivers_class>("Taxi_DB.db", r, ref drivers);
            for (int i = 0; i < drivers.Count; i++)
            {
                dataGridView1.Rows.Add(drivers[i].Nomer_taxometra, drivers[i].Name, drivers[i].Familia, drivers[i].Adress, drivers[i].Telephone, drivers[i].Whoes_avto, drivers[i].Stach_robot, drivers[i].Salary_day);

            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Text = "";
            comboBox1.Text = "Выберите";
            dataGridView1.Rows.Clear();          
            drivers.Clear();
            LoadDataFromDB();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[7], ListSortDirection.Ascending);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Doxod_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
