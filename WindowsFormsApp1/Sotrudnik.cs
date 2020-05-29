using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;//  
using Excel = Microsoft.Office.Interop.Excel;//
using System.Drawing.Printing;//

namespace WindowsFormsApp1
{
    public partial class Sotrudnik : Form
    {
        public List<Drivers_class> drivers = new List<Drivers_class>();
        public List<Cars_class> Cars_Classes = new List<Cars_class>();
        ClassDataBase db = new ClassDataBase();
        public Sotrudnik()
        {
            InitializeComponent();
        }
        public int ind = 0;
       

        void LoadDataFromDB()
            
        {if (ind == 0)
            {
                drivers.Clear();
                string s = @"SELECT * FROM sotrudnik;";
                db.Execute<Drivers_class>("Taxi_DB.db", s, ref drivers);
                for (int i = 0; i < drivers.Count; i++)
                {
                   
                    dataGridView1.Rows.Add(drivers[i].Nomer_taxometra, drivers[i].Name, drivers[i].Familia, drivers[i].Pasport, drivers[i].Adress, drivers[i].Telephone, drivers[i].Date_year, drivers[i].Whoes_avto, drivers[i].Stach_robot, drivers[i].Salary_day, drivers[i].Busy);
                }
                ind++;
                //button1.Enabled = true;
            }
        }




        private void Button1_Click(object sender, EventArgs e)
        {
           
            Driver newDriver = new Driver();
            newDriver.ShowDialog();
            dataGridView1.Rows.Clear();
            ind = 0;
            chek();
            LoadDataFromDB();

        }

        private void chek()
        {
            label3.Text = "";
            drivers.Clear();
            string s = @"SELECT * FROM sotrudnik;";
            db.Execute<Drivers_class>("Taxi_DB.db", s, ref drivers);
            for (int i = 0; i < drivers.Count; i++)
            {
                label3.Text = drivers[i].Nomer_taxometra;
            }
                if (label3.Text=="")
            {
                button2.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
                button5.Enabled = true;
                button2.Enabled = true;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            delete();
            dataGridView1.Rows.Clear();
            ind = 0;
            LoadDataFromDB();
            chek();
        }
private void delete()
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            textBox3.Text = s;
            string a = @"SELECT * FROM car WHERE nomer_taxometra ='"+textBox3.Text+"';";
            db.Execute<Cars_class>("Taxi_DB.db", a, ref Cars_Classes);

            for (int i = 0; i < Cars_Classes.Count; i++)
                textBox4.Text = Cars_Classes[i].Busy.ToString();

            if (textBox4.Text== "0")
            {
               
                drivers.Clear();              
       
                string aaa = @"DELETE FROM sotrudnik WHERE nomer_taxometra = '" + textBox3.Text + "';";
                string aa = @"DELETE FROM car WHERE nomer_taxometra = '" + textBox3.Text + "';";
                db.Execute<Drivers_class>("Taxi_DB.db", aaa, ref drivers);
                db.Execute<Drivers_class>("Taxi_DB.db", aa, ref drivers);
            }
            else
            {

                MessageBox.Show("В данный момент нельзя его удалить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
     

        }
        void SaveTable1(DataGridView What_Save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "DB_Sotrudnik.xlsx";

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

        private void Button5_Click(object sender, EventArgs e)
        {
            SaveTable1(dataGridView1);
        }
        private string text = "";
        void PrintpageHandler  (object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(text, new Font("Arial", 14), Brushes.Black, 0, 0);
        }

        private void Sotrudnik_Load(object sender, EventArgs e)
        {
           LoadDataFromDB();
            chek();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SearchDataFromDB1();
        }
        void SearchDataFromDB1()
        {
            drivers.Clear();
            string r = "";
            if (comboBox1.Text == "№Таксометра")
                r = @"SELECT * FROM sotrudnik where nomer_taxometra ='" + textBox1.Text + "';";
            else
                if (comboBox1.Text == "Имя")
                r = @"SELECT * FROM sotrudnik where name='" + textBox1.Text + "';";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drivers.Clear();
                LoadDataFromDB(); dataGridView1.Rows.Clear();
            }
            db.Execute<Drivers_class>("Taxi_DB.db", r, ref drivers);
            for (int i = 0; i < drivers.Count; i++)
            {
                dataGridView1.Rows.Add(drivers[i].Nomer_taxometra, drivers[i].Name, drivers[i].Familia, drivers[i].Pasport, drivers[i].Adress, drivers[i].Telephone, drivers[i].Date_year, drivers[i].Whoes_avto, drivers[i].Stach_robot, drivers[i].Salary_day, drivers[i].Busy);

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
                        Cars_Classes.Clear();
            ind = 0;
            LoadDataFromDB();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void GroupBox3_Enter_1(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click_1(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            drivers.Clear();
            string sa = dataGridView1.CurrentCell.Value.ToString();
            textBox6.Text = sa;
            string za = @"SELECT * FROM sotrudnik where nomer_taxometra ='"+textBox6.Text+"' and busy = 0;";
            db.Execute<Drivers_class>("Taxi_DB.db", za, ref drivers);
            for (int i = 0; i < drivers.Count; i++)
            {
                textBox5.Text = drivers[i].Nomer_taxometra;
            }
            if (textBox5.Text!="")
            {
                textBox5.Text = "";
                drivers.Clear();
                string z = @"SELECT * FROM sotrudnik where busy=0 LIMIT 1;";
                db.Execute<Drivers_class>("Taxi_DB.db", z, ref drivers);
                for (int i = 0; i < drivers.Count; i++)
                {
                    textBox5.Text = drivers[i].Nomer_taxometra;
                }
                string s = dataGridView1.CurrentCell.Value.ToString();
                textBox6.Text = s;

                DriverReg f = new DriverReg(this.textBox6.Text);
                f.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("В данный момент Водитель на выезде!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.Rows.Clear();
            ind = 0;
            LoadDataFromDB();
            chek();
        
        }

        private void Sotrudnik_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
