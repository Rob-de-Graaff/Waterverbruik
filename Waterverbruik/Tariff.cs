using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterverbruik
{
    class Tariff
    {
        private string name;
        private double standingRight;
        private double consumptionCosts;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double StandingRight
        {
            get { return standingRight; }
            set { standingRight = value; }
        }

        public double ConsumptionCosts
        {
            get { return consumptionCosts; }
            set { consumptionCosts = value; }
        }

        public Tariff(string tariffName, double tariffStandingRight, double tariffConsumptionCosts)
        {
            name = tariffName;
            standingRight = tariffStandingRight;
            consumptionCosts = tariffConsumptionCosts;
        }
    }
}
