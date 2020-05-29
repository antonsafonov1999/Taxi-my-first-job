using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        public List<Clients_class> Clients_Classes = new List<Clients_class>();
        ClassDataBase db = new ClassDataBase();
        private void Client_Load(object sender, EventArgs e)
        {
            LoadDataFromDB();
        }

        void LoadDataFromDB()
        {
            {
                Clients_Classes.Clear();
                string s = @"SELECT * FROM client where busy = 0 GROUP BY telephone  ;";
                db.Execute<Clients_class>("Taxi_DB.db", s, ref Clients_Classes);

                for (int i = 0; i < Clients_Classes.Count; i++)
                {
                    dataGridView1.Rows.Add(Clients_Classes[i].Telephone,Clients_Classes[i].Perfomed_zakaz,Clients_Classes[i].False_zakaz, Clients_Classes[i].From_where, Clients_Classes[i].Otkuda, Clients_Classes[i].Time_time, Clients_Classes[i].Data_time, Clients_Classes[i].Name_avto, Clients_Classes[i].Long_route, Clients_Classes[i].Price, Clients_Classes[i].Color_car, Clients_Classes[i].Nomer_taxometra);


                }
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[11], ListSortDirection.Ascending);
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[8], ListSortDirection.Ascending);
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
                r = @"SELECT * FROM client where nomer_taxometra ='" + textBox1.Text + "';";
            else
                if (comboBox1.Text == "Имя")
                r = @"SELECT * FROM client where name_avto='" + textBox1.Text + "';";

            else
            {
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clients_Classes.Clear();
                LoadDataFromDB(); dataGridView1.Rows.Clear();
            }
            db.Execute<Clients_class>("Taxi_DB.db", r, ref Clients_Classes);
            for (int i = 0; i < Clients_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Clients_Classes[i].Telephone, Clients_Classes[i].Perfomed_zakaz, Clients_Classes[i].False_zakaz, Clients_Classes[i].From_where, Clients_Classes[i].Otkuda, Clients_Classes[i].Time_time, Clients_Classes[i].Data_time, Clients_Classes[i].Name_avto, Clients_Classes[i].Long_route, Clients_Classes[i].Price, Clients_Classes[i].Color_car, Clients_Classes[i].Nomer_taxometra);

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

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string a = @"DELETE  FROM client;";
            db.Execute<Clients_class>("Taxi_DB.db", a, ref Clients_Classes);



            Clients_Classes.Clear();
            string s = @"SELECT * FROM client GROUP BY telephone  ;";
            db.Execute<Clients_class>("Taxi_DB.db", s, ref Clients_Classes);

            for (int i = 0; i < Clients_Classes.Count; i++)
            {
                dataGridView1.Rows.Add(Clients_Classes[i].Telephone, Clients_Classes[i].Perfomed_zakaz, Clients_Classes[i].False_zakaz, Clients_Classes[i].From_where, Clients_Classes[i].Otkuda, Clients_Classes[i].Time_time, Clients_Classes[i].Data_time, Clients_Classes[i].Name_avto, Clients_Classes[i].Long_route, Clients_Classes[i].Price, Clients_Classes[i].Color_car, Clients_Classes[i].Nomer_taxometra);


            }
            dataGridView1.Rows.Clear();
            Clients_Classes.Clear();
            LoadDataFromDB();
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
