using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class zakaz : Form
    {
        public zakaz()
        {
            InitializeComponent();
        }
        public List<Drivers_class> driver_class = new List<Drivers_class>();
        public List<Cars_class> cars_Class = new List<Cars_class>();
        public List<Clients_class> clients_Classes = new List<Clients_class>();

        ClassDataBase db = new ClassDataBase();
        private void New_zakaz_Load(object sender, EventArgs e)
        {
            telephone();
            inputTypeCar();
            Do_Cheked();
        }



        //Если value <= 5 то берется телефон из бд и работает с ним иначе генер новый телефон
        private void telephone()
        {
            textBox1.Text = "";
               Random rnd = new Random();
            int value = rnd.Next(1, 10);
            if (value < 6)
            {
                //Проверяет есть  ли клиенты вообще свободные
                string k = "";
                k = @"SELECT * FROM  client WHERE busy= 0 LIMIT 1 ;";
                db.Execute<Clients_class>("Taxi_DB.db", k, ref clients_Classes);

                for (int i = 0; i < clients_Classes.Count; i++)
                {
                    textBox1.Text = (clients_Classes[i].Nomer_taxometra);
                }



                //если есть свободные клиенты ,то он заполняется в определенные формы
                if (textBox1.Text != "")
                {

                    string r = "";
                    r = @"SELECT * FROM  client WHERE busy= 0 LIMIT 1 ;";
                    db.Execute<Clients_class>("Taxi_DB.db", r, ref clients_Classes);
                    for (int i = 0; i < clients_Classes.Count; i++)
                    {
                        maskedTextBox2.Text = (clients_Classes[i].Telephone);
                        label3.Text = (clients_Classes[i].Perfomed_zakaz);
                        label4.Text = (clients_Classes[i].False_zakaz);
                    }
                    label15.Text = maskedTextBox2.Text;
                    clients_Classes.Clear();
                    string a = @"SELECT * FROM client where telephone = '"+label15.Text+"' AND busy ='1'";
                    db.Execute<Clients_class>("Taxi_DB.db", r, ref clients_Classes);
                    for (int i = 0; i < clients_Classes.Count; i++)
                        textBox5.Text = clients_Classes[i].Nomer_taxometra;
                    if (textBox5.Text != "")
                    {
                        maskedTextBox2.Text = "";
                        label3.Text = "0";
                        label4.Text = "0";
                        {
                        w:
                            var s2 = new StringBuilder();
                            string aa = "050";
                            for (int i = 0; i < 7; i++)
                                s2.Append((char)rnd.Next('0', '9'));
                            var str2 = s2.ToString();

                            maskedTextBox2.Text = aa.ToString() + s2.ToString();

                            if (maskedTextBox2.Text == "")
                            {
                                goto w;

                            }
                            label15.Text = maskedTextBox2.Text;
                        }
                    }
               
                }
                else
                {
                    {
                    w:
                        var s2 = new StringBuilder();
                        string a = "050";
                        for (int i = 0; i < 7; i++)
                            s2.Append((char)rnd.Next('0', '9'));
                        var str2 = s2.ToString();

                        maskedTextBox2.Text = a.ToString() + s2.ToString();

                        if (maskedTextBox2.Text == "")
                        {
                            goto w;

                        }
                        label15.Text = maskedTextBox2.Text;
                    }
                }

            }
            //Иначе генериуется Рандомный телефон
            else
            {
                {
                w:
                    var s2 = new StringBuilder();
                    string a = "050";
                    for (int i = 0; i < 7; i++)
                        s2.Append((char)rnd.Next('0', '9'));
                    var str2 = s2.ToString();

                    maskedTextBox2.Text = a.ToString() + s2.ToString();

                    if (maskedTextBox2.Text == "")
                    {
                        goto w;

                    }
                    label15.Text = maskedTextBox2.Text;
                }
            }



        }



        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        int w = 0;
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            chekbox();
        }

        private void chekbox()
        {
            if (checkBox1.Checked == true)
            {
                Do_Cheked();
            }
            else
            {
                Do_Cheked();
                inpdbAllCar();


                if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
                {
                    label9.Text = label31.Text;
                    label12.Text = label32.Text;
                }
              
            }

            /*//предворительный заказ(проверка)
            if (checkBox1.Checked == true)
            {
                check();

                Do_Cheked();
            }
            else
                if (checkBox1.Checked == false)
            {
                label21.Text = DateTime.Now.ToLongDateString();
                dateTimePicker1.Text = DateTime.Now.ToLongDateString();
                Do_Cheked();
                button2.Enabled = true;
                label24.Text = ""; label25.Text = ""; label28.Text = ""; label27.Text = ""; label9.Text = "0.0"; label12.Text = "0";
                check();
                if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
                {
                    w++;
                    inpdbAllCar();
                  //  generete();
                }

            }*/
        }

        
        
        //функц проверяет поставлена ли галочка
        private void Do_Cheked()
        {
            dateTimePicker1.Enabled = checkBox1.Checked;
            maskedTextBox1.Enabled = checkBox1.Checked;
            comboBox2.Enabled = checkBox1.Checked;
            comboBox2.Text = "";
            maskedTextBox1.Text = "";
            label22.Text = "";//время


        }





        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label21.Text = dateTimePicker1.Text;
        }





        private void DateTimePicker1_Layout(object sender, LayoutEventArgs e)
        {
            label21.Text = dateTimePicker1.Text;
        }



        private void MaskedTextBox1_MouseLeave(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text != "")
            {

                label22.Text = maskedTextBox1.Text;
            }
            else
                label21.Text = "";
        }





        private void ComboBox2_TextChanged(object sender, EventArgs e)
        {
            label24.Text = comboBox2.Text;
        }





        // Функция которая из типа кузова выводит всю информацию о машине
        private void inpdbAllCar()
        {                      //часть кода,которая проверяет есть в бд свободные маины
           string o = @"select * from car WHERE busy=0;";
            db.Execute<Cars_class>("Taxi_DB.db", o, ref cars_Class);
            for (int i = 0; i < cars_Class.Count; i++)
            {
                textBox3.Text = cars_Class[i].Type_avto;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("В базе данных нету свободных машин ", "Ошибка", MessageBoxButtons.OK);
                this.Hide();
            }


            //ПРоверка включина ли доп услуги 
            if (checkBox1.Checked == true)
            {
             string   k = @"select * from car where type_avto = '" + comboBox2.Text + "'and busy=0 limit 1;";

                db.Execute<Cars_class>("Taxi_DB.db", k, ref cars_Class);
                for (int i = 0; i < cars_Class.Count; i++)
                    label34.Text = cars_Class[i].Nomer_taxometra;
                if (label27.Text==label34.Text)
                {
                    for (int i = 0; i < cars_Class.Count; i++)
                    {
                        label9.Text = label31.Text;
                        label12.Text = label32.Text;
                        textBox4.Text = label34.Text;
                    }
                }
                for (int i = 0; i < cars_Class.Count; i++)
                {

                    label27.Text = cars_Class[i].Nomer_taxometra;
                    label28.Text = cars_Class[i].Name_avto;
                    label25.Text = cars_Class[i].Color_avto;
                    label24.Text = cars_Class[i].Type_avto;
                    textBox4.Text = label34.Text;
                }


            }
            // Если не вкл чекбокс то выбирается первая свободная машина
            else
            {
               string p = @"select * from car where busy=0 limit 1;";
                db.Execute<Cars_class>("Taxi_DB.db", p, ref cars_Class);
                for (int i = 0; i < cars_Class.Count; i++)
                {
                    textBox3.Text = cars_Class[i].Type_avto;
                    label27.Text = cars_Class[i].Nomer_taxometra;
                    label28.Text = cars_Class[i].Name_avto;
                    label25.Text = cars_Class[i].Color_avto;
                    label24.Text = cars_Class[i].Type_avto;

                }
            }

        }


        //Функция которая из бд записывает в тип кузова информацию
        private void inputTypeCar()
        {
            string p = @"SELECT DISTINCT * FROM car WHERE busy='0';";
            db.Execute<Cars_class>("Taxi_DB.db", p, ref cars_Class);
            for (int i = 0; i < cars_Class.Count; i++)
            {
                if (!(comboBox2.Items.Contains(cars_Class[i].Type_avto)))
                {
                    comboBox2.Items.Add(cars_Class[i].Type_avto);
                }



            }

        }




        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
            {
                checkBox1.Enabled = true;
                w = 0;

                generete();
                marshrut();
            }


        }


        private void marshrut()
        {
            label29.Text = textBox2.Text;
            label30.Text = textBox7.Text;
            label33.Text = textBox4.Text;
            label31.Text = label9.Text;
            label32.Text = label12.Text;



        }


        string price = "";
        string loung = "";
        //генериует цену и км ремонт
        private void generete()
        {


            if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
            {
           

                Random random = new Random();//км
                int a = random.Next(45, 200);
                label12.Text = a.ToString();
                price = label12.Text;
                Random random1 = new Random();//гр
                int a2 = random1.Next(1, 10);
                label9.Text = a2.ToString();
                loung = label9.Text;
                Random random2 = new Random();//ремонт
                int a3 = random1.Next(20, 50);
                textBox4.Text = a3.ToString();

                label18.Text = textBox2.Text;
                label19.Text = textBox7.Text;
                button1.Enabled = false;
                button2.Enabled = true;



            }
            else
            {

                if (textBox7.Text == "")
                {
                    label9.Text = "0.0";
                    label12.Text = "0";
                    label19.Text = "";
                    // gen = 0;
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            inpdbAllCar();
        }

        // проверяет все ли поставленно для отправки заказа
        private void check()
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = false;
                if (button1.Enabled == false && label12.Text != "0" && label9.Text != "0.0" && label27.Text != "" && label28.Text != "" && label25.Text != "" && label24.Text != "" && label18.Text != "" && label19.Text != "" && label15.Text != "")
                {
                    if (comboBox2.Text != "" || maskedTextBox1.Text != "" || label22.Text != "")
                    {
                        button2.Enabled = true;
                    }


                }
            }
            else

            if (checkBox1.Checked == false)
            {
                button2.Enabled = false;
                if (button1.Enabled == false && label12.Text != "0" && label9.Text != "0.0" && label27.Text != "" && label28.Text != "" && label25.Text != "" && label24.Text != "" && label18.Text != "" && label19.Text != "" && label15.Text != "")
                {
                    button2.Enabled = true;
                }
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            InputDataFromFrmAddSot();
            AddDataToDB();
            this.Hide();

        }

        public void InputDataFromFrmAddSot()
        {
            Clients_class t3 = new Clients_class();
            Drivers_class t2 = new Drivers_class();



            t3.Telephone = label15.Text;
            t3.From_where = label18.Text;
            t3.Otkuda = label19.Text;
            t3.Perfomed_zakaz = label3.Text;
            t3.False_zakaz = label4.Text;
            t3.Data_time = label21.Text;
            t3.Time_time = label22.Text;
            t3.Name_avto = label28.Text;
            t3.Nomer_taxometra = label27.Text;
            t3.Long_route = label9.Text;
            t3.Price = label12.Text;
            t3.Color_car = label25.Text;
            clients_Classes.Add(t3);

            t2.Salary_day = label12.Text;
            t2.Remont = textBox4.Text;
            driver_class.Add(t2);

        }
        void AddDataToDB()
        {
            string sb = @"UPDATE sotrudnik SET busy = 1 WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
            string cb = @"UPDATE car SET busy = 1 WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
            string ss = @"UPDATE sotrudnik SET salary_day  = salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; "; //Запрос на заполнении зарплаты 
            string cs = @"UPDATE car SET salary_day  = salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; "; //Запрос на заполнении зарплаты 
            string cr = @"UPDATE car SET remont  = remont + '" + textBox4.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; ";//Запрос на заполнении ремонта
            string sr = @"UPDATE sotrudnik SET remont  = remont + '" + textBox4.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; ";//Запрос на заполнении ремонта     
            string q = @"INSERT INTO  client (telephone,perfomed_zakaz, false_zakaz,from_where,otkuda,time_time,data_time,name_avto,long_route,price,color_car,nomer_taxometra,busy) VALUES ('" + maskedTextBox2.Text + "','" + label3.Text + "',' " + label4.Text + "',' " + label18.Text + "','" + label19.Text + "','" + label22.Text + "','" + label21.Text + "','" + label28.Text + "','" + label9.Text + "','" + label12.Text + "','" + label25.Text + "','" + label27.Text + "','" + 1 + "');";
            int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
            int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
            int t3 = db.ExecuteNonQuery("Taxi_DB.db", ss);
            int t4 = db.ExecuteNonQuery("Taxi_DB.db", cr);
            int t5 = db.ExecuteNonQuery("Taxi_DB.db", cs);
            int t6 = db.ExecuteNonQuery("Taxi_DB.db", sr);
            int t7 = db.ExecuteNonQuery("Taxi_DB.db", q);

            if (t != 0 && t2 != 0 && t3 != 0 && t4 != 0 && t5 != 0 && t6 != 0 && t7 != 0)
            {
                MessageBox.Show("Заказ взят", "информация", MessageBoxButtons.OK);
            }

        }



        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            label24.Text = ""; label25.Text = ""; label28.Text = ""; label27.Text = ""; label9.Text = "0.0"; label12.Text = "0";
            label18.Text = "";
            button1.Enabled = true; button2.Enabled = false;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            label19.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
            label24.Text = ""; label25.Text = ""; label28.Text = ""; label27.Text = ""; label9.Text = "0.0"; label12.Text = "0";
            checkBox1.Enabled = false;
            checkBox1.Checked = false;

        }

        private void MaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            button2.Enabled = false;

        }

        private void Zakaz_MouseHover(object sender, EventArgs e)
        {
            check();
        }

        private void ComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox7.Text != "")
            {
                generete();
            }

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Label31_Click(object sender, EventArgs e)
        {

        }

        private void Zakaz_FormClosed(object sender, FormClosedEventArgs e)
        {
       
        }
    }
       
}
