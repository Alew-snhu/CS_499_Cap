using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMonitoringSystem
{
    public class HabitatFromTextFileViewModel
    {
        public List<string> HabitatInfo { get; set; } = new List<string>();
        public List<string> Habitats { get; set; } = new List<string>();
        public Dictionary<string, string> HabitatKeysAndValues { get; set; } = new Dictionary<string, string>();
        public object SelectedHabitat { get; set; }
        public string HabitatTextFilePath { get; set; }

        public string HardCodedTextFilePath = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "TextFiles/Habitats.txt");

        public string TextFileDirectory = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), "TextFiles");
        

        public async Task GetHabitatTextFile()
        {
            // Function to open file dialog. once the file is selected it will be
            // parsed through the other functions below. 

            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = TextFileDirectory,
                DefaultExt = ".txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == true)
            {
                HabitatTextFilePath = dlg.FileName;
                await GetHabitatList(HabitatTextFilePath);
                await GetHabitatInfo(HabitatTextFilePath);
                await ReturnHabitatKeysAndValues();
            }
        }

        //Function to parse through animal file and create a list of animal types
        public async Task<List<string>> GetHabitatList(string filePath)
        {
            try
            {
                //Stream Reader used to read the text file.
                using StreamReader streamReader = new StreamReader(filePath);
                string textLine = streamReader.ReadLine();

                // while loop will loop through the text to grab the animal habitat name for each entry.
                while (!textLine.Trim().Equals(""))
                {
                    int lastSpaceIndex = textLine.LastIndexOf("on ") + 3;
                    string stringAfterOn = textLine.Substring(lastSpaceIndex);
                    string[] habitatTokens = stringAfterOn.Split(" ");
                    string habitatType = habitatTokens[0];
                    Habitats.Add(FirstCharToUpper(habitatType));
                    textLine = streamReader.ReadLine();
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("A File Was Not Selected For This Function.");
            }

            // Return list of Habitats
            return await Task.FromResult(Habitats);
        }

        // Function to parse through the habitat information, combine it into a string, and add it to another list. 

        public async Task<List<string>> GetHabitatInfo(string filePath)
        {
            try
            {
                using StreamReader streamReader = new StreamReader(filePath);
                //skip first 4 lines of file.
                for (var i = 0; i < 4; i++)
                {
                    streamReader.ReadLine();
                }

                string textLine = streamReader.ReadLine();

                while (!"".Equals(textLine))
                {
                    // combine each line of habitat information 
                    var description = streamReader.ReadLine() + "\n" + streamReader.ReadLine() + "\n" +
                        streamReader.ReadLine() + "\n" + streamReader.ReadLine();

                    HabitatInfo.Add(description);

                    if (streamReader.Peek() > 1)
                    {
                        textLine = streamReader.ReadLine();
                    }
                    else
                    {
                        textLine = "";
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("A File Was Not Selected For This Function.");
            }

            //return the list of habitat info from the text file
            return await Task.FromResult(HabitatInfo);
        }

        // Function to take the two lists from above and merge them into a dictionary. 
        public async Task<Dictionary<string, string>> ReturnHabitatKeysAndValues()
        {
            // Zip will take the two lists and create a dictionary from them. Habitat types will be the key, Habitat info will be the values. 
            // This is used for the combobox and text box on the XAML page. When the User selects a habitat type, the value will appear in the text box. 

            HabitatKeysAndValues = Habitats.Zip(HabitatInfo, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v);

            return await Task.FromResult(HabitatKeysAndValues);
        }

        // Function to format first letter of the animal type
        private static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
