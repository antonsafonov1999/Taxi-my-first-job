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
    public partial class DriverReg : Form
    {
        public List<Drivers_class> driver_class = new List<Drivers_class>();
        public List<Cars_class> cars_Class = new List<Cars_class>();
        public List<Clients_class> clients_Classes = new List<Clients_class>();
        ClassDataBase db = new ClassDataBase();
        public DriverReg(string data)
        {
            InitializeComponent();
            this.textBox9.Text = data;
        }

        private void DriverReg_Load(object sender, EventArgs e)
        {
            returncar();
        }

        private void returncar()
        {
            string q = @"SELECT * FROM  car  WHERE nomer_taxometra = '" + textBox9.Text + "';";
            db.Execute<Cars_class>("Taxi_DB.db", q, ref cars_Class);
            for (int i = 0; i < cars_Class.Count; i++)
            {
                comboBox4.Text = cars_Class[i].Whoes_avto;
                comboBox1.Text = cars_Class[i].Name_avto;
                textBox10.Text = cars_Class[i].Gos_name;
                textBox11.Text = cars_Class[i].Color_avto;
                textBox12.Text = cars_Class[i].Type_avto;
                maskedTextBox4.Text = cars_Class[i].Strahovka_ot;
                maskedTextBox3.Text = cars_Class[i].Strahovka_do;
            }
            string q1 = @"SELECT * FROM  sotrudnik  WHERE nomer_taxometra = '" + textBox9.Text + "';";
            db.Execute<Drivers_class>("Taxi_DB.db", q1, ref driver_class);
            for (int i = 0; i < driver_class.Count; i++)
            {
                textBox2.Text = driver_class[i].Name;
                textBox3.Text = driver_class[i].Familia;
                textBox4.Text = driver_class[i].Pasport;
                textBox1.Text = driver_class[i].Adress;
                maskedTextBox2.Text = driver_class[i].Telephone;
                maskedTextBox1.Text = driver_class[i].Date_year;
                textBox5.Text = driver_class[i].Nomer_taxometra;
                textBox7.Text = driver_class[i].Stach_robot.ToString();

            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }

        }

        private void ComboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }
        }

        private void TextBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }

        }

        private void TextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }

        }

        private void DriverReg_MouseHover(object sender, EventArgs e)
        {
            chekedDB();
        }
        private void chekedDB()
        {



            if (comboBox4.Text == "Предприятия")
            {


                if (textBox5.Text != "" && textBox7.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox1.Text != "")
                {
                    if (comboBox4.Text != "" && comboBox1.Text != "" && textBox10.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && textBox11.Text != "" && textBox12.Text != "")
                    {
                        button1.Enabled = true;
                    }
                }

            }
            else
            if (comboBox4.Text == "Сотрудника")
            {


                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "" && textBox7.Text != "")
                {
                    if (comboBox4.Text != "" && textBox6.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && maskedTextBox4.Text != "" && maskedTextBox3.Text != "")
                    {
                        button1.Enabled = true;
                    }
                }

            }
            else
                button1.Enabled = false;


        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Сотрудника")
            {
                comboBox1.Visible = false;
                comboBox1.Text = "";//name avto
                textBox10.Text = "";//UJnomer
                textBox11.Text = "";//Color
                textBox12.Text = "";//Type
                maskedTextBox4.Text= "";//Strahovka ot
                maskedTextBox3.Text = ""; //Strahovka do
            }
            else
            {
                comboBox1.Visible = true;
                string q = @"SELECT * FROM  car  WHERE nomer_taxometra = '" + textBox9.Text + "';";
                db.Execute<Cars_class>("Taxi_DB.db", q, ref cars_Class);
                for (int i = 0; i < cars_Class.Count; i++)
                {
                    comboBox4.Text = cars_Class[i].Whoes_avto;
                    comboBox1.Text = cars_Class[i].Name_avto;
                    textBox10.Text = cars_Class[i].Gos_name;
                    textBox11.Text = cars_Class[i].Color_avto;
                    textBox12.Text = cars_Class[i].Type_avto;
                    maskedTextBox4.Text = cars_Class[i].Strahovka_ot;
                    maskedTextBox3.Text = cars_Class[i].Strahovka_do;
                }
            }
        }
           
        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            proverka();
            if (a ==1)
            {
                
                this.timer1.Start();
                InputDataFromFrmAddSot();
                AddDataToDB();

            }
            this.Hide();
        }
      public  int a = 1;
        private void proverka()
        {
            driver_class.Clear();
            string q = @"SELECT * FROM  sotrudnik  WHERE pasport = '" + textBox4.Text + "';";
            db.Execute<Drivers_class>("Taxi_DB.db", q, ref driver_class);
            for (int i = 0; i < driver_class.Count; i++)
                textBox13.Text = driver_class[i].Pasport;
            driver_class.Clear();
            string q1 = @"SELECT * FROM  sotrudnik  WHERE nomer_taxometra = '" + textBox9.Text + "';";
            db.Execute<Drivers_class>("Taxi_DB.db", q, ref driver_class);
            for (int i = 0; i < driver_class.Count; i++)
                textBox14.Text = driver_class[i].Nomer_taxometra;
            if (textBox13.Text!=textBox14.Text)
            {
                a = 0;
                MessageBox.Show("Вы ввели неверный паспорт", "информация", MessageBoxButtons.OK);
            }
            else
            {
                driver_class.Clear();
                string q2 = @"SELECT * FROM  sotrudnik  WHERE telephone = '" + maskedTextBox2.Text + "';";
                db.Execute<Drivers_class>("Taxi_DB.db", q2, ref driver_class);
                if (q2.ToString()== maskedTextBox2.Text)
                {
                    a = 0;
                    MessageBox.Show("Вы ввели неверный Телефон", "информация", MessageBoxButtons.OK);
                }
            }
            driver_class.Clear();
            string q3 = @"SELECT * FROM  sotrudnik  WHERE nomer_taxometra = '" + textBox5.Text + "';";
            db.Execute<Drivers_class>("Taxi_DB.db", q3, ref driver_class);
            if (q3.ToString()==textBox5.Text)
            {
                a = 0;
                MessageBox.Show("Вы ввели неверный №Таксометра", "информация", MessageBoxButtons.OK);
            }

            else
            {
                driver_class.Clear();
                cars_Class.Clear();
                string q4 = @"SELECT * FROM  car  WHERE gos_name = '" + textBox10.Text + "';";
                db.Execute<Cars_class>("Taxi_DB.db", q4, ref cars_Class);
                if (q4.ToString()==textBox10.Text)
                {
                    a = 0;
                    MessageBox.Show("Вы ввели неверный ГО Номер", "информация", MessageBoxButtons.OK);
                }
            }
        }


        public void InputDataFromFrmAddSot()
        {
            Cars_class t3 = new Cars_class();
            Drivers_class t2 = new Drivers_class();
            
            t3.Nomer_taxometra = textBox5.Text;
            t3.Whoes_avto = comboBox4.Text;
            if (comboBox4.Text == "Сотрудника")
                t3.Name_avto = textBox6.Text;
            else
                t3.Name_avto= comboBox1.Text;
            t3.Gos_name = textBox10.Text;
            t3.Color_avto = textBox11.Text;
            t3.Strahovka_ot = maskedTextBox4.Text;
            t3.Strahovka_do = maskedTextBox3.Text;
            cars_Class.Add(t3);

            t2.Name = textBox2.Text;
            t2.Familia = textBox3.Text;
            t2.Pasport = textBox4.Text;
            t2.Adress = textBox1.Text;
            t2.Telephone = maskedTextBox2.Text;
            t2.Date_year = maskedTextBox1.Text;
            t2.Nomer_taxometra = textBox5.Text;
            t2.Stach_robot =Convert.ToInt32( textBox7.Text);
            driver_class.Add(t2);

        }
        void AddDataToDB()
        {


            {
                ///Обновление Машины
                string sb11 = @"UPDATE car SET whoes_avto ='" + comboBox4.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string sb121 = @"UPDATE car SET gos_name ='" + textBox10.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                if (comboBox4.Text == "Предприятия")
                {
                    string sb3 = @"UPDATE car SET name_avto ='" + textBox6.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    int t3 = db.ExecuteNonQuery("Taxi_DB.db", sb3);
                }
                else
                {
                    string sab3 = @"UPDATE car SET name_avto ='" + comboBox1.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    int t5 = db.ExecuteNonQuery("Taxi_DB.db", sab3);
                }
                string s511 = @"UPDATE car SET color_avto ='" + textBox11.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string s111 = @"UPDATE car SET type_avto ='" + textBox12.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string s1a = @"UPDATE car SET strahovka_ot='" + maskedTextBox4.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string sa1 = @"UPDATE car SET strahovka_do='" + maskedTextBox3.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string saa1 = @"UPDATE car SET nomer_taxometra ='" + textBox5.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                
                int t = db.ExecuteNonQuery("Taxi_DB.db", sb11);
                int t2 = db.ExecuteNonQuery("Taxi_DB.db", sb121);
                int t4 = db.ExecuteNonQuery("Taxi_DB.db", s511);
                int t6 = db.ExecuteNonQuery("Taxi_DB.db", s111);
                int t42 = db.ExecuteNonQuery("Taxi_DB.db", s1a);
                int t52 = db.ExecuteNonQuery("Taxi_DB.db", sa1);
                int t52a = db.ExecuteNonQuery("Taxi_DB.db", saa1);
                            }
            {
                //Обновление водителя
                string sb11 = @"UPDATE sotrudnik SET name ='" + textBox2.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string sb121 = @"UPDATE sotrudnik SET familia ='" + textBox3.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
               string s511 = @"UPDATE sotrudnik SET pasport ='" + textBox4.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string s111 = @"UPDATE sotrudnik SET adress ='" + textBox1.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string s1a = @"UPDATE sotrudnik SET telephone='" + maskedTextBox2.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string saw1 = @"UPDATE sotrudnik SET whoes_avto='" + comboBox4.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string sa1 = @"UPDATE sotrudnik SET date_year='" + maskedTextBox1.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                string saa1 = @"UPDATE sotrudnik SET nomer_taxometra ='" + textBox5.Text + "' WHERE nomer_taxometra = '" + textBox9.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                int t22q2 = db.ExecuteNonQuery("Taxi_DB.db", s511);
                int t222 = db.ExecuteNonQuery("Taxi_DB.db", sb11);
                int az = db.ExecuteNonQuery("Taxi_DB.db", sb121);
                int azz = db.ExecuteNonQuery("Taxi_DB.db", s111);
                int xa = db.ExecuteNonQuery("Taxi_DB.db", s1a);
                int ad = db.ExecuteNonQuery("Taxi_DB.db", saw1);
                int za = db.ExecuteNonQuery("Taxi_DB.db", sa1);
                int z = db.ExecuteNonQuery("Taxi_DB.db", saa1);

            }
        }
            private void Timer1_Tick(object sender, EventArgs e)
        {

            this.progressBar1.Increment(2000);
        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (Char.IsDigit(number))
                {
                    e.Handled = true;
                }

            }
        }

        private void DriverReg_FormClosed(object sender, FormClosedEventArgs e)
        {
  
        }
    }
}
