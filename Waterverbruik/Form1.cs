using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Waterverbruik
{
    public partial class Form1 : Form
    {
        private Tariff _newTariff0, _newTariff1, _newTariff2;
        private List<Tariff> tariffList;
        private double _priceTotal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tariffList = new List<Tariff>();
            _newTariff0 = new Tariff("tarief 0", 0, 0);
            _newTariff1 = new Tariff("tarief 1", 100, 0.25);
            _newTariff2 = new Tariff("tarief 2", 75, 0.38);

            tariffList.Add(_newTariff0);
            tariffList.Add(_newTariff1);
            tariffList.Add(_newTariff2);

            // Displays name property
            listBoxTariffs.DisplayMember = "Name";
            listBoxTariffs.DataSource = tariffList;

            // Displays calculation, total
            labelTicketsTotal.Text = $@"Vastrecht + verbruikskosten * verbruik";
            labelPriceTotal.Text = $@"Totaal: € {Math.Round(_priceTotal, 2)},-";
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            Tariff tempTariff = null;
            double tempTariff1 = 0;
            double tempTariff2 = 0;
            _priceTotal = 0;
            
            if (double.TryParse(textBoxConsumption.Text, out double resultConsumption) && resultConsumption > 0)
            {
                int tariffSelection = listBoxTariffs.SelectedIndex;
                
                switch (tariffSelection)
                {
                    case 0:
                        
                        tempTariff1 = CalculatePrice(_newTariff1, resultConsumption);
                        tempTariff2 = CalculatePrice(_newTariff2, resultConsumption);
                        if (tempTariff1<tempTariff2)
                        {
                            tempTariff = _newTariff1;
                            _priceTotal += tempTariff1;
                        }
                        else if (tempTariff1>tempTariff2)
                        {
                            tempTariff = _newTariff2;
                            _priceTotal += tempTariff2;
                        }
                        else
                        {
                            MessageBox.Show(
                                $"{_newTariff1.Name} : € {tempTariff1}, {_newTariff2.Name} : € {tempTariff2} choose one tariff");
                        }
                        break;
                    case 1:
                        tempTariff = _newTariff1;
                        _priceTotal += CalculatePrice(_newTariff1, resultConsumption);
                        break;
                    case 2:
                        tempTariff = _newTariff2;
                        _priceTotal += CalculatePrice(_newTariff2, resultConsumption);
                        break;
                }

                // Displays calculation, total
                labelTicketsTotal.Text = $@"Naam : {tempTariff.Name}| Vastrecht {tempTariff.StandingRight} + verbruikskosten {tempTariff.ConsumptionCosts} * verbruik {resultConsumption}";
                labelPriceTotal.Text = $@"Totaal: € {Math.Round(_priceTotal, 2):0.00},-";
            }
            else
            {
                MessageBox.Show($@"Consumption must contain only numbers > 0");
            }
        }

        private double CalculatePrice(Tariff tariff, double consumption)
        {
            double tempPrice = 0;
            tempPrice += tariff.StandingRight + tariff.ConsumptionCosts * consumption;
            return tempPrice;
        }
    }
}
