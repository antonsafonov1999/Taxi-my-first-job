using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Drivers_class
    {
        private int id;
        private string name;
        private string familia;
        private string pasport;
        private string adress;
        private string telephone;
        private string date_year;
        private string nomer_taxometra;
        private int stach_robot;
        private string salary_day;
        private string whoes_avto;
        private int busy;
        private string remont;

        public string Remont
        {
            set { remont = value; }
            get { return remont; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Familia
        {
            set { familia = value; }
            get { return familia; }
        }
        public string Pasport
        {
            set { pasport = value; }
            get { return pasport; }
        }

        public string Adress
        {
            set { adress = value; }
            get { return adress; }
        }

        public string Telephone
        {
            set { telephone = value; }
            get { return telephone; }
        }
        public string Date_year
        {
            set { date_year = value; }
            get { return date_year; }
        }
        public string Nomer_taxometra
        {
            set { nomer_taxometra = value; }
            get { return nomer_taxometra; }
        }
        public int Stach_robot
        {
            set { stach_robot = value; }
            get { return stach_robot; }
        }
        public string Salary_day
        {
            set { salary_day = value; }
            get { return salary_day; }
        }
        public string Whoes_avto
        {
            set { whoes_avto = value; }
            get { return whoes_avto; }
        }
        public int Busy
        {
            set { busy = value; }
            get { return busy; }
        }
        public Drivers_class()
        {
            id = -1;
            name = "";
            familia = "";
            pasport = "";
            adress = "";
            telephone = "";
            date_year = "";
            nomer_taxometra = "";
            stach_robot = 0;
            salary_day = "";
            whoes_avto = "";
            busy = 0;
            remont = "";

        }

        public Drivers_class(string remont, string name, string familia, string pasport, string adress, string telephone, string date_year, string nomer_taxometra, int stach_robot, string salary_day, string whoes_avto, int busy)
        {
            Id = -1;
            this.name = name;   
            this.familia = familia;
            this.pasport = pasport;
            this.adress = adress;
            this.telephone = telephone;
            this.date_year = date_year;
            this.nomer_taxometra = nomer_taxometra;
            this.stach_robot = stach_robot;
            this.salary_day = salary_day;
            this.whoes_avto = whoes_avto;
            this.busy = busy;
            this.remont = remont;
        }

        public Drivers_class(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            nomer_taxometra = val[1];
            name = val[2];
            familia = val[3];
            pasport = val[4];
             adress = val[5];
            telephone = val[6];
            date_year = val[7];
            whoes_avto = val[8];
            stach_robot = Convert.ToInt32(val[9]);
            salary_day = val[10];
            busy =Convert.ToInt32(val[11]);
            remont = val[12];
        }




    }
}
