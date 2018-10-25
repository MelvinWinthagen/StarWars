using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarWarsConquest
{
    public partial class Building_Interface : Form
    {
        public Building_Interface()
        {
            InitializeComponent();
            PageTwo.Location = PageOne.Location;
            PageThree.Location = PageOne.Location;
        }
        public static string Building = "";
        public static bool Closed = false;
        public string Gebouwtje = "";

        public void ClickHandlerBoi(string SelectedBuilding)
        {
            Closed = true;
            Building = SelectedBuilding;
            SelectedBuilding = null;
            Gebouwtje = null;
            this.Hide();
            
        }


        private void BuildingOne_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Mining Facility Level One";
            MessageBox.Show(Building);
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingTwo_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Mining Facility Level Two";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingThree_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Mining Facility Level Three";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingFour_Click(object sender, EventArgs e)
        {
            Gebouwtje = "XQ 1 Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingFive_Click(object sender, EventArgs e)
        {
            Gebouwtje = "XQ 2 Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingSix_Click(object sender, EventArgs e)
        {
            Gebouwtje = "XQ 3 Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void ButtonNextOne_Click(object sender, EventArgs e)
        {
            PageTwo.Show();
            PageOne.Hide();
        }

        private void BuildingSeven_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Golan I Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void ButtenEight_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Golan II Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingNine_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Golan III Defence Station";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingTen_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Light Shipyard";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingEleven_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Medium Shipyard";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingTwelve_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Heavy Shipyard";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BackOne_Click(object sender, EventArgs e)
        {
            PageTwo.Hide();
            PageOne.Show();
        }

        private void NextTwo_Click(object sender, EventArgs e)
        {
            PageThree.Show();
            PageTwo.Hide();
        }

        private void BuildingThirteen_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Laser Defence Satelite";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingFourteen_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Missile Defence Satelite";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BuildingFifteen_Click(object sender, EventArgs e)
        {
            Gebouwtje = "Ion Defence Satelite";
            ClickHandlerBoi(Gebouwtje);
        }

        private void BackTwo_Click(object sender, EventArgs e)
        {
            PageThree.Hide();
            PageTwo.Show();
        }
    }
}
