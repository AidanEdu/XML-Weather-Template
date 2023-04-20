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

            #region Formating
            showLabels(true);
            xLabel.Parent = backColorLabel;
            int newX = xLabel.Location.X - backColorLabel.Location.X;
            int newY = xLabel.Location.Y - backColorLabel.Location.Y;
            xLabel.Location = new Point(newX, newY);

            humidityLabel.Parent = backColorLabel;
            newX = humidityLabel.Location.X - backColorLabel.Location.X;
            newY = humidityLabel.Location.Y - backColorLabel.Location.Y;
            humidityLabel.Location = new Point(newX, newY);

            sunriseLabel.Parent = backColorLabel;
            newX = sunriseLabel.Location.X - backColorLabel.Location.X;
            newY = sunriseLabel.Location.Y - backColorLabel.Location.Y;
            sunriseLabel.Location = new Point(newX, newY);

            sunsetLabel.Parent = backColorLabel;
            newX = sunsetLabel.Location.X - backColorLabel.Location.X;
            newY = sunsetLabel.Location.Y - backColorLabel.Location.Y;
            sunsetLabel.Location = new Point(newX, newY);

            lastUpdateLabel.Parent = backColorLabel;
            newX = lastUpdateLabel.Location.X - backColorLabel.Location.X;
            newY = lastUpdateLabel.Location.Y - backColorLabel.Location.Y;
            lastUpdateLabel.Location = new Point(newX, newY);

            moreInfoLabel.Parent = backColorLabel;
            newX = moreInfoLabel.Location.X - backColorLabel.Location.X;
            newY = moreInfoLabel.Location.Y - backColorLabel.Location.Y;
            moreInfoLabel.Location = new Point(newX, newY);
            #endregion
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;
            currentOutput.Text = $"{Convert.ToDouble(Form1.days[0].currentTemp).ToString("#")}°";
            minLabel.Text = $"L: {Convert.ToDouble(Form1.days[0].tempLow).ToString("#")}°";
            maxLabel.Text = $"H: {Convert.ToDouble(Form1.days[0].tempHigh).ToString("#")}°";
            dateLabel.Text = $"{DateTime.Now.ToString("dddd")} \n{DateTime.Now.ToString("MMMM dd")}";
            humidityLabel.Text = $"Humidity:                       {Form1.days[0].humidity}%";
            sunriseLabel.Text = $"Sunrise:                    {Convert.ToDouble(Form1.days[0].sunRise.Substring(11, 2)) + Convert.ToDouble(Form1.days[0].timeZone)/3600}:{Form1.days[0].sunRise.Substring(14,2)}am";
            sunsetLabel.Text =  $"Sunset:                     {12 - Convert.ToDouble(Form1.days[0].sunSet.Substring(11, 2)) + Convert.ToDouble(Form1.days[0].timeZone) / 3600}:{Form1.days[0].sunSet.Substring(14, 2)}pm";
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
            showLabels(true);
            backColorLabel.BackColor = Color.FromArgb(200, 100, 100, 100);
            
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            showLabels(false);
        }

        public void showLabels(bool show)
        {
            if (show == false)
            {
                backColorLabel.Visible = false;
                humidityLabel.Visible = false;
                sunriseLabel.Visible = false; 
                sunsetLabel.Visible = false;
                lastUpdateLabel.Visible = false;
                xLabel.Visible = false; 
            }
            else if (show == true)
            {
                backColorLabel.Visible = true;
                humidityLabel.Visible = true;
                sunriseLabel.Visible = true;
                sunsetLabel.Visible = true;
                lastUpdateLabel.Visible = true;
                xLabel.Visible = true;
            }
        }
    }
}
