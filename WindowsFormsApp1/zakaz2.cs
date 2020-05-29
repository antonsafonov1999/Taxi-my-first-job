using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class zakaz2 : Form
    {
        public zakaz2(string data)
        {
            InitializeComponent();

            this.textBox5.Text = data;

        }
        string data;
        public List<Drivers_class> driver_class = new List<Drivers_class>();
        public List<Cars_class> cars_Class = new List<Cars_class>();
        public List<Clients_class> clients_Classes = new List<Clients_class>();

        ClassDataBase db = new ClassDataBase();
        private void Zakaz2_Load(object sender, EventArgs e)
        {
            clintreturn();
            inputTypeCar();


            Do_Cheked();

            label35.Text = label12.Text;
            label36.Text = label9.Text;
            label38.Text = textBox2.Text;
            label37.Text = textBox7.Text;
        }

        //Записвается  из бд машин в форму
        private void clintreturn()
        {


            string q = @"SELECT * FROM  car  WHERE nomer_taxometra = '" + textBox5.Text + "';";
            db.Execute<Cars_class>("Taxi_DB.db", q, ref cars_Class);
            for (int i = 0; i < cars_Class.Count; i++)
            {
                label28.Text = cars_Class[i].Name_avto;
                label24.Text = cars_Class[i].Color_avto;
                label25.Text = cars_Class[i].Type_avto;
                label27.Text = cars_Class[i].Nomer_taxometra;
                label29.Text = cars_Class[i].Remont;
            }

            //Записывает из БД клиента в форму 
            string r = @"SELECT * FROM  client WHERE nomer_taxometra = '" + textBox5.Text + "';";
            db.Execute<Clients_class>("Taxi_DB.db", r, ref clients_Classes);
            for (int i = 0; i < clients_Classes.Count; i++)
            {
                maskedTextBox2.Text = clients_Classes[i].Telephone;      //телефон

                label15.Text = clients_Classes[i].Telephone;      //телефон
                label3.Text = clients_Classes[i].Perfomed_zakaz;        //Удачные заказы
                label4.Text = clients_Classes[i].False_zakaz;           //Ложные заказы

                textBox2.Text = clients_Classes[i].From_where;          //Откуда
                textBox7.Text = clients_Classes[i].Otkuda;              //Куда

                label18.Text = clients_Classes[i].From_where;          //Откуда
                label19.Text = clients_Classes[i].Otkuda;              //Куда
                label22.Text = clients_Classes[i].Time_time;            //Время
                label21.Text = clients_Classes[i].Data_time;            //Дата
                label9.Text = clients_Classes[i].Long_route;        //Длина 
                label12.Text = clients_Classes[i].Price;            //цена



            }

            label31.Text = label9.Text;// длина маршрута старая
            label30.Text = label12.Text;//цена старая
            label32.Text = label29.Text;//Ремонт старый 
            label34.Text = label27.Text; // №
        }


        //Записывает только свободные машины 
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



        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Do_Cheked();
             
            }
            else
            {
                if (checkBox1.Checked == false)
                {
                 
                    if (comboBox2.Text!="")
                    {
                        string k = @"select * from car where nomer_taxometra = '" + label34.Text + "';";

                        db.Execute<Cars_class>("Taxi_DB.db", k, ref cars_Class);
                        for (int i = 0; i < cars_Class.Count; i++)
                        {
                            label12.Text = label30.Text;
                            label9.Text = label31.Text;
                            label27.Text = cars_Class[i].Nomer_taxometra;
                            label28.Text = cars_Class[i].Name_avto;
                            label25.Text = cars_Class[i].Color_avto;
                            label24.Text = cars_Class[i].Type_avto;

                            label12.Text = label35.Text;
                            label9.Text = label36.Text;

                           


                        }
                    }
             
                    Do_Cheked();
                }
            }
        }
    





        // Функция которая из типа кузова combobox выводит всю информацию о машине
        private void inpdbAllCar()
        {

            //часть кода,которая проверяет есть в бд свободные маины
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

            /*
                        //ПРоверка включина ли доп услуги 
                        if (checkBox1.Checked == true)
                        {
                         string   k = @"select * from car where type_avto = '" + comboBox2.Text + "'and busy=0 limit 1;";

                            db.Execute<Cars_class>("Taxi_DB.db", k, ref cars_Class);
                            for (int i = 0; i < cars_Class.Count; i++)
                            {
                                label27.Text = cars_Class[i].Nomer_taxometra;
                                label28.Text = cars_Class[i].Name_avto;
                                label25.Text = cars_Class[i].Color_avto;
                                label24.Text = cars_Class[i].Type_avto;
                            }



                        }
                        */
            if (checkBox1.Checked == true)
            {
                string k = @"select * from car where type_avto = '" + comboBox2.Text + "'and busy=0 limit 1;";

                db.Execute<Cars_class>("Taxi_DB.db", k, ref cars_Class);
                for (int i = 0; i < cars_Class.Count; i++)
                    label33.Text = cars_Class[i].Nomer_taxometra;
                if (label27.Text == label34.Text)
                {
                    for (int i = 0; i < cars_Class.Count; i++)
                    {
                        label9.Text = label31.Text;
                        label12.Text = label32.Text;
                        label32.Text = label29.Text;
                    }
                }
                for (int i = 0; i < cars_Class.Count; i++)
                {

                    label27.Text = cars_Class[i].Nomer_taxometra;
                    label28.Text = cars_Class[i].Name_avto;
                    label25.Text = cars_Class[i].Color_avto;
                    label24.Text = cars_Class[i].Type_avto;

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


   

        //генериует цену и км ремонт
        private void generete()
        {

            if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
            {


                if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
                {   //Цена
                    Random random = new Random();
                    int a = random.Next(45, 200);
                    label12.Text = a.ToString();
                    //КМ
                    Random random1 = new Random();
                    int a2 = random1.Next(1, 10);
                    label9.Text = a2.ToString();
                    //Ремонт
                    Random random2 = new Random();
                    int a3 = random1.Next(20, 50);
                    label29.Text = a3.ToString();

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
                        label29.Text = "";
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                }
               // inpdbAllCar();
            }
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
            t2.Remont = label29.Text;
            driver_class.Add(t2);

        }
        void AddDataToDB()
        {
           
            // запрос на вывод финансов из бд чтобы от них отнять зарплату ремонта
          
            if (label34.Text == label27.Text)
            {
                {
                    string sb11 = @"UPDATE car SET remont = remont - '" + label32.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb21 = @"UPDATE car SET remont =  remont + '" + label29.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb112 = @"UPDATE car SET salary_day = salary_day - '" + label30.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb213 = @"UPDATE car SET salary_day = salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт

                    string sb12 = @"UPDATE sotrudnik SET salary_day = salary_day - '" + label30.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb22 = @"UPDATE sotrudnik SET salary_day =  salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb13 = @"UPDATE sotrudnik SET remont = remont - '" + label32.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string sb52 = @"UPDATE sotrudnik SET remont =  remont + '" + label29.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт

                    string x = @"UPDATE client SET from_where =  '" + label18.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x2 = @"UPDATE client SET otkuda =  '" + label19.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x3 = @"UPDATE client SET time_time =  '" + label22.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x4 = @"UPDATE client SET data_time =  '" + label21.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x33 = @"UPDATE client SET name_avto =  '" + label28.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x44 = @"UPDATE client SET long_route =  '" + label9.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x333 = @"UPDATE client SET price =  '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                    string x444 = @"UPDATE client SET color_car =  '" + label25.Text + "' WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                  

                    int t = db.ExecuteNonQuery("Taxi_DB.db", sb11);
                    int t2 = db.ExecuteNonQuery("Taxi_DB.db", sb21);
                    int t3 = db.ExecuteNonQuery("Taxi_DB.db", sb112);
                    int t4 = db.ExecuteNonQuery("Taxi_DB.db", sb213);

                    int t5 = db.ExecuteNonQuery("Taxi_DB.db", sb12);
                    int t6 = db.ExecuteNonQuery("Taxi_DB.db", sb22);
                    int t42 = db.ExecuteNonQuery("Taxi_DB.db", sb13);
                    int t52 = db.ExecuteNonQuery("Taxi_DB.db", sb52);


                    int t222 = db.ExecuteNonQuery("Taxi_DB.db", x);
                    int az = db.ExecuteNonQuery("Taxi_DB.db", x2);
                    int azz = db.ExecuteNonQuery("Taxi_DB.db", x3);
                    int xa = db.ExecuteNonQuery("Taxi_DB.db", x4);
                    int ad = db.ExecuteNonQuery("Taxi_DB.db", x33);
                    int za = db.ExecuteNonQuery("Taxi_DB.db", x44);
                    int z = db.ExecuteNonQuery("Taxi_DB.db", x333);
                    int aq = db.ExecuteNonQuery("Taxi_DB.db", x444);
                }
                }
            else
            {
                if (label34.Text!=label27.Text)
                {
                    {
                        //Очищаем сотрудника и машину
                        string qsb13 = @"UPDATE sotrudnik SET remont = remont - '" + label32.Text + "' WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                        string sbw12 = @"UPDATE sotrudnik SET salary_day = salary_day - '" + label30.Text + "' WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                        string sb12 = @"UPDATE sotrudnik SET busy = 0 WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы освободить машину

                        string qqq = @"UPDATE car SET salary_day = salary_day - '" + label30.Text + "' WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                        string sb111 = @"UPDATE car SET remont = remont - '" + label32.Text + "' WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы изменить поле ремонт
                        string sb213 = @"UPDATE car SET busy = 0  WHERE nomer_taxometra = '" + label34.Text + "';";   //Запрос на то чтобы освоюодить водителя
                        int t = db.ExecuteNonQuery("Taxi_DB.db", qsb13);
                        int t2 = db.ExecuteNonQuery("Taxi_DB.db", sbw12);
                        int t3 = db.ExecuteNonQuery("Taxi_DB.db", qqq);
                        int t4 = db.ExecuteNonQuery("Taxi_DB.db", sb111);
                        int t5 = db.ExecuteNonQuery("Taxi_DB.db", sb213);
                        int t6 = db.ExecuteNonQuery("Taxi_DB.db", sb12);
                      
                    }
                   
                    {
                        //добавляем сотрудника

                        string sb = @"UPDATE sotrudnik SET busy = 1 WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
                        string cb = @"UPDATE car SET busy = 1 WHERE nomer_taxometra = '" + label27.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                        string ss = @"UPDATE sotrudnik SET salary_day  = salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; "; //Запрос на заполнении зарплаты 
                        string cs = @"UPDATE car SET salary_day  = salary_day + '" + label12.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; "; //Запрос на заполнении зарплаты 
                        string cr = @"UPDATE car SET remont  = remont + '" + label29.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; ";//Запрос на заполнении ремонта
                        string sr = @"UPDATE sotrudnik SET remont  = remont + '" + label29.Text + "' WHERE nomer_taxometra = '" + label27.Text + "'; ";//Запрос на заполнении ремонта     

                        int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
                        int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
                        int t3 = db.ExecuteNonQuery("Taxi_DB.db", ss);
                        int t4 = db.ExecuteNonQuery("Taxi_DB.db", cr);
                        int t5 = db.ExecuteNonQuery("Taxi_DB.db", cs);
                        int t6 = db.ExecuteNonQuery("Taxi_DB.db", sr);
                    }
                    {
                        //Запросы на обновление заказа Клиента
                        string qq = @"DELETE FROM client WHERE nomer_taxometra ='"+label34.Text+ "' AND from_where = '"+label38.Text+ "' AND otkuda = '"+label37.Text+"';";
                       string q = @"INSERT INTO  client (telephone,perfomed_zakaz, false_zakaz,from_where,otkuda,time_time,data_time,name_avto,long_route,price,color_car,nomer_taxometra,busy)
VALUES ('" + maskedTextBox2.Text + "','" + label3.Text + "',' " + label4.Text + "',' " + label18.Text + "','" + label19.Text + "','" + label22.Text + "','" + label21.Text + "','" + label28.Text + "','" + label9.Text + "','" + label12.Text + "','" + label25.Text + "','" + label27.Text + "','" + 1 + "');";
                        int t = db.ExecuteNonQuery("Taxi_DB.db", qq);
                        int t2 = db.ExecuteNonQuery("Taxi_DB.db", q);

                    }
                }

            }
         

        }



        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox7.Text != "" && textBox2.Text != textBox7.Text)
            {
                generete();
                label35.Text = label12.Text;
                label36.Text = label9.Text;
            }
        }

       

        private void TextBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            //label24.Text = ""; label25.Text = ""; label28.Text = ""; label27.Text = ""; label9.Text = "0.0"; label12.Text = "0";
            //label18.Text = "";
            button1.Enabled = true; button2.Enabled = false;
        }

        private void TextBox7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            label19.Text = "";
            button1.Enabled = true; button2.Enabled = false;
            label24.Text = ""; label25.Text = ""; label28.Text = ""; label27.Text = ""; label9.Text = "0.0"; label12.Text = "0";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            InputDataFromFrmAddSot();
            AddDataToDB();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GroupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void Label28_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox7.Text != "")
            {
                inpdbAllCar();
                generete();
            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label25_Click(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Label24_Click(object sender, EventArgs e)
        {

        }

        private void Label23_Click(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label29_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Label30_Click(object sender, EventArgs e)
        {

        }

        private void Label31_Click(object sender, EventArgs e)
        {

        }

        private void Label32_Click(object sender, EventArgs e)
        {

        }

        private void Label33_Click(object sender, EventArgs e)
        {

        }

        private void Label34_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = true;
        }

        private void Zakaz2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
