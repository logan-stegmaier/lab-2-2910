using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2___2910
{
    // Step 2
    public class VideoGame : IComparable<VideoGame>
    {

        public string Name { get; set; }

        public string Platform { get; set; } // will change

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Publisher { get; set; }

        public double NA_Sales { get; set; }

        public double EU_Sales { get; set; }

        public double JP_Sales { get; set; }

        public double Other_Sales { get; set; }

        public double Global_Sales { get; set; }

        public VideoGame()
        {

        }

        public VideoGame(string name, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            Name = name; 
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NA_Sales = naSales;
            EU_Sales = euSales;
            JP_Sales = jpSales;
            Other_Sales = otherSales;
            Global_Sales = globalSales;
        }

        public int CompareTo(VideoGame other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {

            //Name,Platform,Year,Genre,Publisher,NA_Sales,EU_Sales,JP_Sales,Other_Sales,Global_Sales
            string gameString = "";
            gameString += "=================================\n";
            gameString += $"Name: {Name}\n";
            gameString += $"Platform: {Platform}\n";
            gameString += $"Year: {Year}\n";
            gameString += $"Genre: {Genre}\n";
            gameString += $"Publisher: {Publisher}\n";
            gameString += $"NA Sales - {NA_Sales}\n";
            gameString += $"EU Sales - {EU_Sales}\n"; 
            gameString += $"Other Sales - {Other_Sales}\n";
            gameString += $"Global Sales - {Global_Sales}\n";
            gameString += "=================================";

            return gameString;
        }

    }
}
