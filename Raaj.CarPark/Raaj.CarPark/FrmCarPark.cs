using Raaj.CarPark.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raaj.CarPark
{
    public partial class frmCarPark : Form
    {
        public frmCarPark()
        {
            InitializeComponent();
        }

        public void Start()
        {
            var eventsProcessor = new EventsProcessor();
            var step1and2 = "Initialise the car park with 10 bays and a name of “Test carpark”. " +
                "Have one of each type of vehicles enter the car park. The truck should have a weight of 101 kg.";
            MessageBox.Show(step1and2);
            eventsProcessor.Step1();
            eventsProcessor.Step2();
            
            var caption = eventsProcessor.CarPark.Name;
            this.Text = caption;

            Display(eventsProcessor.CarPark);
            MessageBox.Show("Pay the outstanding fee for the luxury car",caption);
            eventsProcessor.Step4();
            Display(eventsProcessor.CarPark);
            MessageBox.Show("Have the luxury car exit the car park", caption);
            eventsProcessor.Step6();
            Display(eventsProcessor.CarPark);
            MessageBox.Show("Pay the outstanding fees for the remaining cars", caption);
            eventsProcessor.Step8();
            MessageBox.Show("Have the remaining cars exit the car park", caption);
            eventsProcessor.Step9();
            Display(eventsProcessor.CarPark);
            MessageBox.Show("Have a motorbike enter the car park", caption);
            eventsProcessor.Step11();
            MessageBox.Show("Have the motorbike exit the car park", caption);
            try
            {
                eventsProcessor.Step12();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Display(eventsProcessor.CarPark);
        }

        public void Display(BaseCarPark carPark)
        {
            MessageBox.Show("List the details of all the vehicles in the car park including their type and outstanding fees.", carPark.Name);
            var vehicles = carPark.Vehicles.Select(v => v.ToString()).ToArray();
            txtDisplay.Text = String.Join(Environment.NewLine, vehicles) + Environment.NewLine + Environment.NewLine +
            string.Format("Name: {0}, Spots: {1}, Occupancy: {2}, Occupied Percentage: {3}",
                carPark.Name,
                carPark.Bays,
                carPark.Occupancy,
                carPark.OccupiedPercentage);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
