using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
 public   class Clients_class
    {
        private int id;
        private string telephone;
        private string perfomed_zakaz;
        private string false_zakaz;
        private string from_where;
        private string otkuda;
        private string data_time;
        private string time_time;
        private string name_avto;
        private string long_route;
        private string price;
        private string color_car;
        private string nomer_taxometra;
        private int busy;
     
        public int Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Telephone
        {
            set { telephone = value; }
            get { return telephone; }
        }
        public string Perfomed_zakaz
        {
            set { perfomed_zakaz = value; }
            get { return perfomed_zakaz; }
        }
        public string False_zakaz
        {
            set { false_zakaz = value; }
            get { return false_zakaz; }
        }
        public string From_where
        {
            set { from_where = value; }
            get { return from_where; }
        }
        public string Otkuda
        {
            set { otkuda = value; }
            get { return otkuda; }
        }
        public string Data_time
        {
            set { data_time = value; }
            get { return data_time; }
        }
        public string Time_time
        {
            set { time_time = value; }
            get { return time_time; }
        }
        public string Name_avto
        {
            set { name_avto = value; }
            get { return name_avto; }
        }
        public string Long_route
        {
            set { long_route = value; }
            get { return long_route; }
        }

        public string Color_car
        {
            set { color_car = value; }
            get { return color_car; }
        }
        public string Nomer_taxometra
        {
            set { nomer_taxometra = value; }
            get { return nomer_taxometra; }
        }
        public string Price
        {
            set { price = value; }
            get { return price; }
        }
        public int Busy
        {
            set { busy = value; }
            get { return busy; }
        }
        public Clients_class()
        {
            id = -1;
            telephone = "";
            perfomed_zakaz = "";
            false_zakaz = "";
            from_where = "";
            otkuda = "";
            time_time = "";
            data_time = "";
            name_avto = "";
            long_route = "";
            price = "";
            color_car = "";
            nomer_taxometra = "";
            busy = 0;


        }

        public Clients_class(string telephone, string perfomed_zakaz, string false_zakaz, string from_where, string otkuda, string data_time, string time_time, string name_avto, string long_route, string price, string color_car, string nomer_taxometra,int busy)
        {
            Id = -1;
            this.telephone = telephone;
            this.perfomed_zakaz = perfomed_zakaz;
            this.false_zakaz = false_zakaz;
            this.from_where = from_where;
            this.otkuda = otkuda;
            this.time_time = time_time;
            this.data_time = data_time;
            this.name_avto = name_avto;
            this.long_route = long_route;
            this.price = price;
            this.color_car = color_car;
            this.nomer_taxometra = nomer_taxometra;
            this.busy = busy;
    

        }

        public Clients_class(string info)
        {
            string[] val = info.Split('|');
            id = Convert.ToInt32(val[0]);
            telephone = val[1];
            perfomed_zakaz = val[2];
            false_zakaz =val[3];
            from_where = val[4];
            otkuda = val[5];
            time_time = val[6];
            data_time = val[7];
            name_avto = val[8];
            long_route = val[9];
            price = val[10];
            color_car =val[11];
            nomer_taxometra = val[12];
            busy = Convert.ToInt32(val[13]);

        }




    }
}
