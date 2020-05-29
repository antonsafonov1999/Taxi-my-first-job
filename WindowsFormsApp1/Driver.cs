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
    public partial class Driver : Form
    {
        private void Driver_Load(object sender, EventArgs e)
        {
            taxometr();
            Enebled();
            chekedDB();
        }


        //коментирующая Функция  
        private void Enebled()
        {
            textBox5.Enabled = checkBox1.Checked;
            comboBox1.Enabled = false; textBox10.Enabled = false;maskedTextBox4.Enabled = false; maskedTextBox3.Enabled = false; textBox11.Enabled = false; textBox12.Enabled = false;
        } 

        // Проверка на введенность всех форм
        private void chekedDB()
        {
          


            if (comboBox4.Text == "Предприятия")
            {
                

                if (textBox5.Text != "" && textBox7.Text != ""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox1.Text != "")
                {
                    if (comboBox4.Text != "" && comboBox1.Text != "" && textBox10.Text != "" && maskedTextBox3.Text!="" && maskedTextBox4.Text!="" && textBox11.Text!="" && textBox12.Text!="")
                    {
                        button1.Enabled = true;
                    }
                }

            }
            if (comboBox4.Text == "Сотрудника")
            {
               
              
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox1.Text != ""&& textBox5.Text!=""&& textBox7.Text!="")
                {
                    if (comboBox4.Text != "" && textBox6.Text != "" && textBox10.Text != "" && textBox11.Text!="" && textBox12.Text!="" && maskedTextBox4.Text!="" && maskedTextBox3.Text!="")
                    {
                        button1.Enabled = true;
                    }
                }

            }

        }

        // Генерация № таксометра
        private void taxometr() 
        {
            a:
            Random random = new Random();
            int a = random.Next(1, 3000);
            textBox5.Text = a.ToString();

            string q = @"SELECT * from sotrudnik ";
            db.Execute<Drivers_class>("Taxi_DB.db", q, ref driver_class);
            for (int i = 0; i < driver_class.Count; i++)
            {
                textBox8.Text = driver_class[i].Nomer_taxometra;
                if (textBox8.Text== textBox5.Text)
                {
                    textBox5.Text = "";
                    goto a;
                }
            }

        }



        /// ///////////////база данный водителя

        public Driver()  
        {
            InitializeComponent();

        }




        public List<Drivers_class> driver_class = new List<Drivers_class>();
        public List<Cars_class> cars_Class = new List<Cars_class>();
        ClassDataBase db = new ClassDataBase();

        public void InputDataFromFrmAddSot()
        {
     
            Drivers_class t = new Drivers_class();
            Cars_class t2 = new Cars_class();

            t.Name = textBox2.Text;
            t.Familia = textBox3.Text;
            t.Adress = textBox1.Text;
            t.Pasport = textBox4.Text;
            t.Telephone = maskedTextBox2.Text;
            t.Date_year = maskedTextBox1.Text;
            t.Nomer_taxometra = textBox5.Text;
            t.Stach_robot =Convert.ToInt32 (textBox7.Text);
            driver_class.Add(t);

            t2.Whoes_avto = comboBox4.Text;
           
            t2.Gos_name = textBox10.Text;
            t2.Color_avto = textBox11.Text;
            t2.Type_avto = textBox12.Text; 
            t2.Strahovka_ot = maskedTextBox4.Text;
            t2.Strahovka_do = maskedTextBox3.Text;
            
            if (comboBox1.Visible == true)
                t2.Name_avto = comboBox1.Text;
            else
                t2.Name_avto = textBox6.Text;
            cars_Class.Add(t2);

        }

        //Функция которая сохраняет ин-цию о машины и сотрудника
        void AddDataToDB()
        {
            string a = "";
             a= comboBox4.Text;
            if (a == "Предприятия")
            {
                string s1 = @"INSERT INTO sotrudnik (nomer_taxometra,name,familia,pasport,adress, telephone,date_year,whoes_avto,stach_robot,salary_day, busy, remont) 
        VALUES ('" + textBox5.Text + "','" + textBox2.Text + "',' " + textBox3.Text + "',' " + textBox4.Text + "','" + textBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox1.Text + "','" + comboBox4.Text + "','" + textBox7.Text + "','" + 0 + "', '" + 0 + "', '" + 0 + "');";
                string s2 = @"INSERT INTO car (nomer_taxometra,whoes_avto,gos_name,name_avto,color_avto,type_avto,strahovka_ot,strahovka_do,busy,remont,salary_day)
        VALUES('" + textBox5.Text + "','" + comboBox4.Text + "','" + textBox10.Text + "','" + comboBox1.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + maskedTextBox4.Text + "','" + maskedTextBox3.Text + "','" + 0 + "', '" + 0 + "','" + 0 + "');";


                int t = db.ExecuteNonQuery("Taxi_DB.db", s1);
                if (t != 0)
                {
                    MessageBox.Show("Сохранено в базу сотрудника", "Informatoin", MessageBoxButtons.OK);
                }
                int t2 = db.ExecuteNonQuery("Taxi_DB.db", s2);
                if (t2 != 0)
                {
                    MessageBox.Show("Сохранено в базу машины", "Informatoin", MessageBoxButtons.OK);
                }

            }
            else
            {
                string ss = @"INSERT INTO sotrudnik (nomer_taxometra,name,familia,pasport,adress, telephone,date_year,whoes_avto,stach_robot,salary_day, busy, remont) 
        VALUES ('" + textBox5.Text + "','" + textBox2.Text + "',' " + textBox3.Text + "',' " + textBox4.Text + "','" + textBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox1.Text + "','" + comboBox4.Text + "','" + textBox7.Text + "','" + 0 + "', '" + 0 + "', '" + 0 + "');";
                string sss = @"INSERT INTO car (nomer_taxometra,whoes_avto,gos_name,name_avto,color_avto,type_avto,strahovka_ot,strahovka_do,busy,remont,salary_day)
        VALUES('" + textBox5.Text + "','" + comboBox4.Text + "','" + textBox10.Text + "','" + textBox6.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + maskedTextBox4.Text + "','" + maskedTextBox3.Text + "','" + 0 + "', '" + 0 + "','" + 0 + "');";

                int t = db.ExecuteNonQuery("Taxi_DB.db", ss);
                if (t != 0)
                {
                    MessageBox.Show("Сохранено в базу сотрудника", "Informatoin", MessageBoxButtons.OK);
                }
                int t2 = db.ExecuteNonQuery("Taxi_DB.db", sss);
                if (t2 != 0)
                {
                    MessageBox.Show("Сохранено в базу машины", "Informatoin", MessageBoxButtons.OK);
                }

            }
        }

     
        void SearchDataFromDB()
        {

          
            string k = "";
            if (comboBox1.Text == "Hyundai Solaris")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
             else
                 if (comboBox1.Text == "Kia Rio")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
            else
                 if (comboBox1.Text == "Skoda Rapid")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
            else
             if (comboBox1.Text == "Renault Logan")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
            else
            if (comboBox1.Text == "Ford Focus")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
            else
            if (comboBox1.Text == "Toyota Camry")
                k = @"SELECT * FROM car  where name_avto ='" + comboBox1.Text + "';";
            else
                MessageBox.Show("Не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            db.Execute<Cars_class>("Taxi_DB.db", k, ref cars_Class);
            for (int i = 0; i < cars_Class.Count; i++)
            {
                maskedTextBox4.Text = (cars_Class[i].Strahovka_ot);
                maskedTextBox3.Text = (cars_Class[i].Strahovka_do);

            }




        }

                private void Button1_Click(object sender, EventArgs e)
                {

                    this.timer1.Start();

            InputDataFromFrmAddSot();
            AddDataToDB();

            Close();



                }
     

            private void Timer1_Tick(object sender, EventArgs e)
                {
                    this.progressBar1.Increment(2000);

                }



                private void GroupBox1_Enter(object sender, EventArgs e)
                {

                }

                private void MaskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
                {

                }




                private void GroupBox2_Enter(object sender, EventArgs e)
                {

                }


                private void TextBox1_TextChanged(object sender, EventArgs e)
                {

                }

                private void ProgressBar1_Click(object sender, EventArgs e)
                {

                }


                private void GroupBox3_Enter_1(object sender, EventArgs e)
                {

                }


                private void TextBox5_TextChanged(object sender, EventArgs e)
                {

                }



                private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
                {

                }



                private void MaskedTextBox4_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
                {


                }


                private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Rand2();
          
            
        }
                private void Rand2()  // Генерация информации о машине 
                {

            {
                switch (comboBox1.Text) // Тип кузова 
                {
                    case "Hyundai Solaris":

                        textBox12.Text = "Седан";
                        break;
                    case "Kia Rio":

                        textBox12.Text = "Универсал";
                        break;
                    case "Skoda Rapid":

                        textBox12.Text = "Хэтчбек";
                        break;
                    case "Renault Logan":

                        textBox12.Text = "Универсал";
                        break;
                    case "Ford Focus":

                        textBox12.Text = "Седан";
                        break;
                    case "Toyota Camry":

                        textBox12.Text = "Седан";
                        break;
                }


            }

            
            {//Номерные знаки
                    w:
                        var rnd = new Random();
                        var s1 = new StringBuilder();
                        string a = "АХ";
                        for (int i = 0; i < 4; i++)
                            s1.Append((char)rnd.Next('0', '9'));
                        var str = s1.ToString();

                        textBox10.Text = a.ToString() + " " + s1.ToString();
                        if (textBox10.Text == "")
                        {
                            goto w;

                        }
                    }
                    {//Цвет
                    q:
                        Random random = new Random();
                        int n = comboBox2.Items.Count;
                        comboBox2.SelectedIndex = random.Next(0, n);
                        if (comboBox2.Text == "")
                        {
                            goto q;

                        }
                        textBox11.Text = comboBox2.Text;
                    }
            SearchDataFromDB();
        }






                private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
                {

                }

                private void TextBox10_TextChanged(object sender, EventArgs e)
                {

                }

                private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
                {
                    if (comboBox4.Text != "")
                    {

                        clear();
                    }


                }
                //Функция которая чистит формы при выборе машины
                private void clear()
                {
                    if (comboBox4.Text == "Сотрудника")
                    {

                        textBox6.Visible = true; comboBox1.Visible = false; textBox10.Enabled = true; textBox6.Text = "";
                        maskedTextBox4.Enabled = true; maskedTextBox3.Enabled = true; textBox11.Enabled = true; textBox12.Enabled = true;
                        comboBox1.Text = ""; textBox11.Text = ""; textBox10.Text = ""; textBox12.Text = ""; maskedTextBox3.Text = ""; maskedTextBox4.Text = "";
                    }
                    else
                    {
                        if (comboBox4.Text == "Предприятия")
                        {
                            comboBox1.Visible = true; textBox6.Visible = false; comboBox1.Enabled = true;
                            textBox10.Enabled = false; textBox11.Enabled = false; textBox12.Enabled = false;
                    maskedTextBox3.Enabled = false; maskedTextBox4.Enabled = false;
                            comboBox1.Text = ""; textBox11.Text = ""; textBox10.Text = ""; textBox12.Text = ""; maskedTextBox3.Text = ""; maskedTextBox4.Text = "";
                        }
                    }
                }

                private void TextBox7_TextChanged(object sender, EventArgs e)
                {

                }

                private void TextBox2_TextChanged(object sender, EventArgs e)
                {

                }

                private void TextBox4_TextChanged(object sender, EventArgs e)
                {

                }

                private void Label1_Click(object sender, EventArgs e)
                {

                }

                private void TextBox11_TextChanged(object sender, EventArgs e)
                {

                }

                private void TextBox12_TextChanged(object sender, EventArgs e)
                {

                }

                private void Driver_MouseHover(object sender, EventArgs e)
                {
                    chekedDB();
           
        }

                private void TextBox4_Leave(object sender, EventArgs e)
                {
                }

                private void Label10_Click(object sender, EventArgs e)
                {

                }

                private void MaskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
                {

                }

        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)//стаж роботы
        {
           
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void MaskedTextBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            {//проверка на то что  нужно писать только цифры
                char number = e.KeyChar;

                if (!Char.IsDigit(number))
                {
                    e.Handled = true;
                }
            
            }

        }

        private void TextBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Driver_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
