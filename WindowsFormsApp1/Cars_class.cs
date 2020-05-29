using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Cars_class
    {
        private int id;
        private string name_avto;
        private string gos_name;
        private string color_avto;      
        private string type_avto;
        private string strahovka_ot;
        private string strahovka_do;
        private string whoes_avto;
        private string nomer_taxometra;
        private int busy;
        private string remont;
        private string salary_day;
        public string Salary_day
        {
            set { salary_day = value; }
            get { return salary_day; }
        }
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
        public string Name_avto
        {
            set { name_avto = value; }
            get { return name_avto; }
        }
        public string Color_avto
        {
            set { color_avto = value; }
            get { return color_avto; }
        }
        public string Gos_name
        {
            set { gos_name = value; }
            get { return gos_name; }
        }
        public string Type_avto
        {
            set { type_avto = value; }
            get { return type_avto; }
        }
        public string Strahovka_ot
        {
            set { strahovka_ot = value; }
            get { return strahovka_ot; }
        }
        public string Strahovka_do
        {
            set { strahovka_do = value; }
            get { return strahovka_do; }
        }
        public string Whoes_avto
        {
            set { whoes_avto = value; }
            get { return  whoes_avto; }
        }
        public string Nomer_taxometra
        {
            set { nomer_taxometra = value; }
            get { return nomer_taxometra; }
        }

        public int Busy
        {
            set { busy = value; }
            get { return busy; }
        }
        public Cars_class()
        {
            id = -1;
            name_avto = "";
                        gos_name = "";
            color_avto = "";
            type_avto = "";
            strahovka_ot = "";
            strahovka_do = "";
            whoes_avto = "";
            nomer_taxometra = "";
            busy = 0;
            remont = "";
           

        }

        public Cars_class(string salary_day, string remont, string name_avto, string color_avto, string gos_name, string type_avto, string strahovka_ot, string strahovka_do, string whoes_avto, string nomer_taxometra,int busy)
        {
            Id = -1;
            this.name_avto = name_avto;
            this.color_avto = color_avto;
            this.gos_name = gos_name;
            this.type_avto = type_avto;
            this.strahovka_ot = strahovka_ot;
            this.strahovka_do = strahovka_do;
            this.whoes_avto = whoes_avto;
            this.nomer_taxometra = nomer_taxometra;
            this.busy = busy;
            this.remont = remont;
            this.salary_day = salary_day;
        }

        public Cars_class(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            nomer_taxometra =val[1];
            whoes_avto = val[2];
            gos_name = val[3];           
            name_avto = val[4];            
            color_avto = val[5];
            type_avto = val[6];
            strahovka_ot = val[7];
            strahovka_do = val[8];
            busy = Convert.ToInt32(val[9]);
            remont = val[10];
            salary_day = val[11];


        }




    }
}
