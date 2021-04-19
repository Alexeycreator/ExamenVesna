using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenVasnaPM03
{
    class Weather
    {
        int vlagnost = 0;
        int temperatura = 0;
        int davlenie = 0;

        public int Vlagnost {
            get { return this.vlagnost; }
            set { this.vlagnost = value; }
        }

        public int Temperatura
        {
            get { return this.temperatura; }
            set { this.temperatura = value; }
        }

        public int Davlenie
        {
            get { return this.davlenie; }
            set { this.davlenie = value; }
        }
    }
}
