using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            cityOutput.Location = new Point((this.Width / 2) - (cityOutput.Width / 2), 30);
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            currentOutput.Text = $"{Convert.ToDouble(Form1.days[0].currentTemp).ToString("#")}°";
            cityOutput.Text = Form1.days[0].location;
            minLabel.Text = $"L: {Convert.ToDouble(Form1.days[0].tempLow).ToString("#")}°";
            maxLabel.Text = $"H: {Convert.ToDouble(Form1.days[0].tempHigh).ToString("#")}°";
            dateLabel.Text = $"{DateTime.Now.ToString("dddd")} \n{DateTime.Now.ToString("MMMM dd")}";
            backColorLabel.BackColor = Color.FromArgb(50, 50, 50, 50); 
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
