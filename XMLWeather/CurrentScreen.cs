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
            cityOutput.Location = new Point((295 / 2) - (cityOutput.Width / 2), 30);
            DisplayCurrent();
            maxLabel.Location = new Point(295 / 2 - maxLabel.Width / 2 - 25, 177);
            minLabel.Location = new Point(maxLabel.Location.X + maxLabel.Width + 18, 177);
           
            pictureBox1.Location = new Point(minLabel.Location.X + minLabel.Width + 15, 168); 

            #region Formating
            showLabels(true);
            moreInfoFormating();
            xLabel.Parent = backColorLabel;
            int newX = xLabel.Location.X - backColorLabel.Location.X;
            int newY = xLabel.Location.Y - backColorLabel.Location.Y;
            xLabel.ForeColor = Color.White;
            xLabel.Location = new Point(newX, newY);

            humidityLabel.Parent = backColorLabel;
            newX = humidityLabel.Location.X - backColorLabel.Location.X;
            newY = humidityLabel.Location.Y - backColorLabel.Location.Y;
            humidityLabel.ForeColor = Color.White;
            humidityLabel.Location = new Point(newX, newY);

            sunriseLabel.Parent = backColorLabel;
            newX = sunriseLabel.Location.X - backColorLabel.Location.X;
            newY = sunriseLabel.Location.Y - backColorLabel.Location.Y;
            sunriseLabel.ForeColor = Color.White;
            sunriseLabel.Location = new Point(newX, newY);

            sunsetLabel.Parent = backColorLabel;
            newX = sunsetLabel.Location.X - backColorLabel.Location.X;
            newY = sunsetLabel.Location.Y - backColorLabel.Location.Y;
            sunsetLabel.ForeColor = Color.White;
            sunsetLabel.Location = new Point(newX, newY);

            lastUpdateLabel.Parent = backColorLabel;
            newX = lastUpdateLabel.Location.X - backColorLabel.Location.X;
            newY = lastUpdateLabel.Location.Y - backColorLabel.Location.Y;
            lastUpdateLabel.ForeColor = Color.White;
            lastUpdateLabel.Location = new Point(newX, newY);

            moreInfoLabel.Parent = backColorLabel;
            newX = moreInfoLabel.Location.X - backColorLabel.Location.X;
            newY = moreInfoLabel.Location.Y - backColorLabel.Location.Y;
            moreInfoLabel.ForeColor = Color.White;
            moreInfoLabel.Location = new Point(newX, newY);

            currentConditionsLabel.Location = new Point(maxLabel.Location.X + Math.Abs((minLabel.Location.X + minLabel.Width) - maxLabel.Location.X)/2 - currentConditionsLabel.Width/2, currentConditionsLabel.Location.Y);

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
            lastUpdateLabel.Text = $"Last Updated:            {Convert.ToDouble(Form1.days[0].lastUpdate.Substring(11, 2)) + Convert.ToDouble(Form1.days[0].timeZone) / 3600}:{Form1.days[0].lastUpdate.Substring(14, 2)}"; 
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

        public void moreInfoFormating()
        {
            moreInfoLabel.Location = new Point(99, 79);
            humidityLabel.Location = new Point(33, 142);
            sunriseLabel.Location = new Point(33, 224); 
            sunsetLabel.Location = new Point(33, 309);
            lastUpdateLabel.Location = new Point(33, 387);
            backColorLabel.Location = new Point(17, 65);
            xLabel.Location = new Point(244, 79); 
        }
    }
}
