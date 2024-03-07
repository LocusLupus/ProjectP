

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ProjectP
{
    public partial class Form1 : Form
    {
        private Polygon Polygon;
       

        public Form1()
        {
            InitializeComponent();
            Polygon = new Polygon();
            Polygon.Location = new System.Drawing.Point(10, 10); 
            Polygon.Size = new System.Drawing.Size(1000, 1000); 
            this.Controls.Add(Polygon);
            this.BackColor = Color.WhiteSmoke;

        }

        
    }
}