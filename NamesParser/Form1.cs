using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace NamesParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CountryComboBox.DataSource = Enum.GetValues(typeof(Country));
        }

        private void LoadHtmlButton_Click(object sender, System.EventArgs e)
        {
            string namePattern = "(name)";
            string givenNamePattern = "(given name)";
            string surnamePattern = "(surname)";
            string disambiguationPattern = "(disambiguation)";

            var htmlWeb = new HtmlWeb();
            var document = htmlWeb.Load(url.Text);

            var names = new List<string>();

            var listNode = document.GetElementbyId("mw-pages");
            foreach (var liNode in listNode.SelectNodes(".//li"))
            {
                var name = liNode.InnerText;

                if (
                       liNode.InnerText.Contains(namePattern) 
                    || liNode.InnerText.Contains(givenNamePattern)               
                    || liNode.InnerText.Contains(surnamePattern)                                    
                    || liNode.InnerText.Contains(disambiguationPattern)
                   )
                {
                    name = liNode.InnerText
                        .Replace(namePattern, string.Empty)
                        .Replace(givenNamePattern, string.Empty)
                        .Replace(surnamePattern, string.Empty)
                        .Replace(disambiguationPattern, string.Empty);

                }

                name = name.Trim();
                names.Add(name);
            }

            var filename = FirstNameRadioButton.Checked ? "FirstNames" : "LastNames";

            if (File.Exists(@"D:/Names/" + CountryComboBox.SelectedValue + "." + filename + ".json"))
            {
                int counter = 2;

                while (File.Exists(@"D:/Names/" + CountryComboBox.SelectedValue + "." + filename + "." + counter + ".json"))
                {
                    counter++;
                }

                filename += "." + counter;
            }

            filename += ".json";

            using (var file = File.CreateText(@"D:/Names/" + CountryComboBox.SelectedValue + "." + filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, names);
            }
        }

        private void JoinFilesButton_Click(object sender, EventArgs e)
        {
            foreach (var value in Enum.GetValues(typeof(Country)))
            {
                JoinFilesForCountry(value.ToString());
            }
        }

        private void JoinFilesAndClearNamesForSelectedCountryButton_Click(object sender, EventArgs e)
        {
            var value = CountryComboBox.SelectedValue.ToString();

            JoinFilesForCountry(value);
        }

        private void JoinFilesForCountry(string value)
        {
            var shitCount = 0;
            string pattern = @"(\(.+?\))";

            //------------
            var filesPathes1 = Directory.GetFiles(@"D:/Names/AllFiles").Where(p => p.Contains(value.ToString()) && p.Contains("FirstNames"));
            var firstNames = new List<string>();

            foreach (var file in filesPathes1)
            {
                List<string> firstNamesPart = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(file));
                firstNames.AddRange(firstNamesPart);
            }

            if (firstNames.Count > 0)
            {
                firstNames = new List<string>(firstNames.OrderBy(s => s));
                var modifiedFirstNames = new List<string>();
                foreach (var name in firstNames)
                {
                    var n = Regex.Replace(name, pattern, String.Empty);

                    if (!n.Contains("#") && !n.Contains("&")) modifiedFirstNames.Add(n);
                }

                shitCount += modifiedFirstNames.Count(s => s.Contains('('));
                using (var file = File.CreateText(@"D:/Names/AllFiles/JoinFiles/" + value + ".FirstNames.Join.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, modifiedFirstNames);
                }
            }

            //------------
            var filesPathes2 = Directory.GetFiles(@"D:/Names/AllFiles").Where(p => p.Contains(value.ToString()) && p.Contains("LastNames"));
            var lastNames = new List<string>();

            foreach (var file in filesPathes2)
            {
                List<string> lastNamesPart = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(file));
                lastNames.AddRange(lastNamesPart);
            }

            if (lastNames.Count > 0)
            {
                lastNames = new List<string>(lastNames.OrderBy(s => s));
                var modifiedLastNames = new List<string>();
                foreach (var name in lastNames)
                {
                    var n = Regex.Replace(name, pattern, String.Empty);

                    if (!n.Contains("#") && !n.Contains("&")) modifiedLastNames.Add(n);
                }
                shitCount += modifiedLastNames.Count(s => s.Contains('('));
                using (var file = File.CreateText(@"D:/Names/AllFiles/JoinFiles/" + value + ".LastNames.Join.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, modifiedLastNames);
                }
            }

            var i = shitCount;
        }
    }
}
