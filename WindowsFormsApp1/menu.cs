using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class menu : Form
    {

        public menu()
        {
            InitializeComponent();

        }

        public List<Drivers_class> drivers = new List<Drivers_class>();
        public List<Cars_class> cars_Class = new List<Cars_class>();
        public List<Clients_class> clients_Classes = new List<Clients_class>();//проверка1
        public List<Clients_class> clients = new List<Clients_class>();//проверка2
        ClassDataBase db = new ClassDataBase();



        private void Menu_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();         
            proverkaCar2();
            chekDriver();

        }

        private void chekDriver()
        {
            drivers.Clear();
            textBox5.Text = "";
            string k1 = @"SELECT * FROM sotrudnik WHERE busy=0 LIMIT 1;";
            db.Execute<Drivers_class>("Taxi_DB.db", k1, ref drivers);

            for (int i = 0; i < drivers.Count; i++)
            
                textBox5.Text = drivers[i].Nomer_taxometra;
            if (textBox5.Text=="")
            {
                button1.Enabled = false;
              
            }
            else
            {             
                button1.Enabled = true;
            }
            textBox5.Text = "";
            clients.Clear();

            string k2 = @"SELECT * FROM client WHERE busy=1 LIMIT 1;";
            db.Execute<Clients_class>("Taxi_DB.db", k2, ref clients);

            for (int i = 0; i < clients.Count; i++)

                textBox5.Text = clients[i].Nomer_taxometra;
            if (textBox5.Text == "")
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

            }

            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

            }
           // dataGridView2.Columns["Column19"].Visible = false;
        }

        public int ind2 = 0;
        private void proverkaCar2()
        {
           
    
            if (ind2 == 0)
            {
                clients.Clear();
                ind2++;
                string k1 = @"SELECT * FROM client WHERE busy=1;";
                    db.Execute<Clients_class>("Taxi_DB.db", k1, ref clients);
           

                for (int i = 0; i < clients.Count; i++)
                {
                    if (Convert.ToDateTime(clients[i].Data_time) == DateTime.Now.Date)
                    {
                        string k2 = @"SELECT * FROM car WHERE busy=1 and nomer_taxometra ='" + clients[i].Nomer_taxometra + "';";
                        db.Execute<Cars_class>("Taxi_DB.db", k2, ref cars_Class);

                        dataGridView2.Rows.Add(clients[i].Nomer_taxometra, clients[i].Telephone, clients[i].From_where, clients[i].Otkuda, clients[i].Name_avto, clients[i].Color_car,
                           clients[i].Long_route, clients[i].Price, cars_Class[i].Remont );
                      
                    }
                   
                    if (Convert.ToDateTime(clients[i].Data_time) > DateTime.Now.Date)
                    {
                        string k2 = @"SELECT * FROM car WHERE busy=1 and nomer_taxometra ='" + clients[i].Nomer_taxometra + "';";
                        db.Execute<Cars_class>("Taxi_DB.db", k2, ref cars_Class);
                        dataGridView1.Rows.Add(clients[i].Nomer_taxometra, clients[i].Telephone, clients[i].From_where, clients[i].Otkuda,
                            clients[i].Time_time, clients[i].Data_time, clients[i].Name_avto, clients[i].Color_car,
 clients[i].Long_route, clients[i].Price);
                    }


                }


               
            }
            ind2 = 0;
           //dataGridView2.Columns["Column19"].Visible = false;
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            chekDriver();
        }

        
     

        

        private void Button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            zakaz new_Zakaz = new zakaz();
            new_Zakaz.ShowDialog();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
                      ind2 = 0;
            proverkaCar2();
            chekDriver();
        }

      


        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void СотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void СвободныеМашиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }



      

        private void Button2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.Visible == true)
            {
                string z = @"SELECT * FROM client where busy=1 LIMIT 1;";
                db.Execute<Clients_class>("Taxi_DB.db", z, ref clients_Classes);
                for (int i = 0; i < clients_Classes.Count; i++)
                {
                    textBox4.Text = clients_Classes[i].Name_avto;
                }
                string s = dataGridView2.CurrentCell.Value.ToString();
                textBox3.Text = s;

                zakaz2 f = new zakaz2(this.textBox3.Text);
                f.ShowDialog();


            }
            if (dataGridView1.Visible== true)
            {
                string z = @"SELECT * FROM client where busy=1 LIMIT 1;";
                db.Execute<Clients_class>("Taxi_DB.db", z, ref clients_Classes);
                for (int i = 0; i < clients_Classes.Count; i++)
                {
                    textBox4.Text = clients_Classes[i].Name_avto;
                }
                string s = dataGridView1.CurrentCell.Value.ToString();
                textBox3.Text = s;



                zakaz2 f = new zakaz2(this.textBox3.Text);
                f.ShowDialog();

            }
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            ind2 = 0;
            proverkaCar2();
            chekDriver();

        }
     public   int column, row;
        private void Button3_Click(object sender, EventArgs e)
        {
            zakaz();
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            ind2 = 0;
            proverkaCar2();
            chekDriver();
        }



        private void zakaz()

        {

            string z = @"SELECT * FROM client where busy=1 LIMIT 1;";
            db.Execute<Clients_class>("Taxi_DB.db", z, ref clients_Classes);
            for (int i = 0; i < clients_Classes.Count; i++)
            {
                textBox4.Text = clients_Classes[i].Nomer_taxometra;
            }
            if (textBox4.Text != "")
            {
                
                if (dataGridView2.Visible == true)
                {

                    string s = dataGridView2.CurrentCell.Value.ToString();
                    textBox3.Text = s;

                    if (s != "")
                    {
                        string sb = @"UPDATE sotrudnik SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
                        string cb = @"UPDATE car SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                        string clb = @"UPDATE client SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                        string cp = @"UPDATE client SET perfomed_zakaz = perfomed_zakaz + '" + 1 + "' WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.

                        int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
                        int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
                        int t3 = db.ExecuteNonQuery("Taxi_DB.db", clb);
                        int t4 = db.ExecuteNonQuery("Taxi_DB.db", cp);
                        if (t != 0 && t2 != 0 && t3 != 0 && t4 != 0)
                        {
                            MessageBox.Show("Заказ завершен удачно", "информация", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    textBox4.Text = "";
                    string f = @"SELECT * FROM client where busy=1 LIMIT 1;";
                    db.Execute<Clients_class>("Taxi_DB.db", f, ref clients);
                    for (int i = 0; i < clients_Classes.Count; i++)
                    {
                        textBox4.Text = clients[i].Name_avto;
                    }
                    if (textBox4.Text != "")
                    {
                        if (dataGridView1.Visible == true)

                        {
                            ind2++;
                            

                            string s = dataGridView1.CurrentCell.Value.ToString();
                            textBox3.Text = s;
                            if (s != "")
                            {
                                string sb = @"UPDATE sotrudnik SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
                                string cb = @"UPDATE car SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                                string clb = @"UPDATE client SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                                string cp = @"UPDATE client SET perfomed_zakaz = perfomed_zakaz + '" + 1 + "' WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.

                                int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
                                int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
                                int t3 = db.ExecuteNonQuery("Taxi_DB.db", clb);
                                int t4 = db.ExecuteNonQuery("Taxi_DB.db", cp);
                                if (t != 0 && t2 != 0 && t3 != 0 && t4 != 0)
                                    MessageBox.Show("Заказ завершен удачно", "информация", MessageBoxButtons.OK);

                            }


                        }

                    }
                }
            }
          
      
        }




    private void Button4_Click(object sender, EventArgs e)
        {
            zakaz2();
  
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            //ind = 0;
            ind2 = 0;
          //  proverkaCar();
            proverkaCar2();
            chekDriver();
        }
        private void zakaz2()
        {
            string z = @"SELECT * FROM client where busy=1 LIMIT 1;";
            db.Execute<Clients_class>("Taxi_DB.db", z, ref clients_Classes);
            for (int i = 0; i < clients_Classes.Count; i++)
            {
                textBox4.Text = clients_Classes[i].Name_avto;
            }
            if (textBox4.Text != "")
            {


                if (dataGridView2.Visible == true)
                { 
               
                    string s = dataGridView2.CurrentCell.Value.ToString();
                    textBox3.Text = s;
                    if (s != "")
                    {
                        for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                            /*if (dataGridView2.Rows[i].Cells[0].Value.ToString() == textBox3.Text)
                            {
                                label6.Text = dataGridView2.Rows[i].Cells[8].Value.ToString();
                                label5.Text = dataGridView2.Rows[i].Cells[7].Value.ToString();
                            }*/

            }
        
        
                            string sb = @"UPDATE sotrudnik SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
                        string cb = @"UPDATE car SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                        string clb = @"UPDATE client SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.

                       string ss = @"UPDATE sotrudnik SET salary_day  = salary_day - '" +200+ "' WHERE nomer_taxometra = '" + textBox3.Text + "'; "; //Запрос на заполнении зарплаты 
                        string cs = @"UPDATE car SET salary_day  = salary_day - '" +200+ "' WHERE nomer_taxometra = '" + textBox3.Text + "'; "; //Запрос на заполнении зарплаты 
                        string cr = @"UPDATE car SET remont  = remont + '" +20+ "' WHERE nomer_taxometra = '" + textBox3.Text + "'; ";//Запрос на заполнении ремонта
                        string sr = @"UPDATE sotrudnik SET remont  = remont + '" +20+ "' WHERE nomer_taxometra = '" + textBox3.Text + "'; ";//Запрос на заполнении ремонта     

                        string cp = @"UPDATE client SET false_zakaz = false_zakaz + '" +1+ "' WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.

                        int t22 = db.ExecuteNonQuery("Taxi_DB.db", ss);
                        int t2112 = db.ExecuteNonQuery("Taxi_DB.db", cs);
                        int t31 = db.ExecuteNonQuery("Taxi_DB.db", cr);
                        int t12 = db.ExecuteNonQuery("Taxi_DB.db", sr);

                        int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
                        int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
                        int t3 = db.ExecuteNonQuery("Taxi_DB.db", clb);
                        int t4 = db.ExecuteNonQuery("Taxi_DB.db", cp);
                        if (t != 0 && t2 != 0 && t3 != 0 && t4 != 0)
                        {
                            MessageBox.Show("Заказ завершен фатально", "информация", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    textBox4.Text = "";
                    string f = @"SELECT * FROM client where busy=1 LIMIT 1;";
                    db.Execute<Clients_class>("Taxi_DB.db", f, ref clients);
                    for (int i = 0; i < clients_Classes.Count; i++)
                    {
                        textBox4.Text = clients[i].Name_avto;
                    }
                    if (textBox4.Text != "")
                    {
                        if (dataGridView1.Visible == true)

                        {

                            string o = @"select * from car WHERE nomer_taxometra = '" + textBox3.Text + "';";
                            db.Execute<Cars_class>("Taxi_DB.db", o, ref cars_Class);
                            for (int i = 0; i < cars_Class.Count; i++)
                            {
                                label5.Text = cars_Class[i].Salary_day;
                                label6.Text = cars_Class[i].Remont;
                            }
                            ind2++;
                      

                            string s = dataGridView1.CurrentCell.Value.ToString();
                            textBox3.Text = s;
                            if (s != "")
                            {
                                string ss = @"UPDATE sotrudnik SET salary_day  = salary_day - '" + label5.Text + "' WHERE nomer_taxometra = '" + textBox3.Text + "'; "; //Запрос на заполнении зарплаты 
                                string cs = @"UPDATE car SET salary_day  = salary_day - '" + label5.Text + "' WHERE nomer_taxometra = '" + textBox3.Text + "'; "; //Запрос на заполнении зарплаты 
                                string cr = @"UPDATE car SET remont  = remont - '" + label6.Text + "' WHERE nomer_taxometra = '" + textBox3.Text + "'; ";//Запрос на заполнении ремонта
                                string sr = @"UPDATE sotrudnik SET remont  = remont - '" + label6.Text + "' WHERE nomer_taxometra = '" + textBox3.Text + "'; ";//Запрос на заполнении ремонта     

                                string sb = @"UPDATE sotrudnik SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы сотрудник занимает заказ.
                                string cb = @"UPDATE car SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                                string clb = @"UPDATE client SET busy = 0 WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.
                                string cp = @"UPDATE client SET false_zakaz = false_zakaz + '" + 1 + "' WHERE nomer_taxometra = '" + textBox3.Text + "';";   //Запрос на то чтобы Машина занимает заказ.

                                int t22 = db.ExecuteNonQuery("Taxi_DB.db", ss);
                                int t2112 = db.ExecuteNonQuery("Taxi_DB.db", cs);
                                int t31 = db.ExecuteNonQuery("Taxi_DB.db", cr);
                                int t12 = db.ExecuteNonQuery("Taxi_DB.db", sr);

                                int t = db.ExecuteNonQuery("Taxi_DB.db", sb);
                                int t2 = db.ExecuteNonQuery("Taxi_DB.db", cb);
                                int t3 = db.ExecuteNonQuery("Taxi_DB.db", clb);
                                int t4 = db.ExecuteNonQuery("Taxi_DB.db", cp);
                                if (t != 0 && t2 != 0 && t3 != 0 && t4 != 0)
                                    MessageBox.Show("Заказ завершен фатально", "информация", MessageBoxButtons.OK);

                            }


                        }

                    }
                }
            }


        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ИнформацияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ДобавитьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.ShowDialog();
        }

        private void БазаДаныйСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sotrudnik sotrudnik = new Sotrudnik();
            sotrudnik.ShowDialog();
        }

        private void ДоходыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Doxod doxod = new Doxod();
            doxod.ShowDialog();
        }

        private void РемонтАвтомобилейToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            RemontCar remontCar = new RemontCar();
            remontCar.ShowDialog();
        }

        private void БазаМашинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LookCar lookCar = new LookCar();
            lookCar.ShowDialog();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void DataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
            row = e.RowIndex;
        }

        private void ИсторияЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void КлиентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Client client = new Client();
            client.ShowDialog();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        
           

        }
    }
}
