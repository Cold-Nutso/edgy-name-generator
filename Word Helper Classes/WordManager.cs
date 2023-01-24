using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Edgy_Name_Generator
{
    public class WordManager
    {
        // Fields

        private Random actOfGod;
        private List<WordFamily<NounPair>> nounFams = new List<WordFamily<NounPair>>();
        private List<WordFamily<string>> adjFams = new List<WordFamily<string>>();
        public EdgyName currentName;
        public EdgyTitle currentTitle;



        // Properties

        public List<WordFamily<NounPair>> NounFamilies { get { return nounFams; } set { nounFams = value; } }
        public List<WordFamily<string>> AdjFamilies { get { return adjFams; } set { adjFams = value; } }



        // Constructor

        public WordManager()
        {
            // Initialize random
            actOfGod = new Random();

            // Read external files
            ReadFile("edgy.adj");
            ReadFile("edgy.noun");
        }



        // Methods

        // --------------------------------------
        // - - - - - DEALING WITH FILES - - - - -
        // --------------------------------------

        private void WriteFile(string fileName)
        {
            if (fileName.Split('.')[1] == "adj") // Write an adjective file
                try
                {
                    // Clear and flush content of the file
                    FileStream fileStream = File.Open(fileName, FileMode.Open);
                    fileStream.SetLength(0);
                    fileStream.Close();

                    // Begin writing to the file
                    FileStream outStream = File.OpenWrite(fileName);
                    BinaryWriter output = new BinaryWriter(outStream);

                    output.Write(adjFams.Count); // Write the family count

                    foreach (WordFamily<string> adjFam in adjFams)
                    {
                        output.Write(adjFam.Name);         // Write the family name
                        output.Write(adjFam.Items.Count);  // Write the item count
                        for (int i = 0; i < adjFam.Items.Count; i++)
                            output.Write(adjFam.Items[i]); // Write each item
                    }

                    // Stop writing
                    output.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            else if (fileName.Split('.')[1] == "noun") // Write a noun file
                try
                {
                    // Clear and flush content of the file
                    FileStream fileStream = File.Open(fileName, FileMode.Open);
                    fileStream.SetLength(0);
                    fileStream.Close();

                    // Begin writing to the file
                    FileStream outStream = File.OpenWrite(fileName);
                    BinaryWriter output = new BinaryWriter(outStream);

                    output.Write(NounFamilies.Count); // Write the family count

                    foreach (WordFamily<NounPair> nounFam in nounFams)
                    {
                        output.Write(nounFam.Name);        // Write the family name
                        output.Write(nounFam.Items.Count); // Write the item count

                        for (int i = 0; i < nounFam.Items.Count; i++)
                        {
                            output.Write(nounFam.Items[i].HasPlural);  // Write the plural boolean
                            output.Write(nounFam.Items[i].Singular);   // Write the singular
                            if (nounFam.Items[i].HasPlural == true)
                                output.Write(nounFam.Items[i].Plural); // Write the plural
                        }
                    }

                    // Stop writing
                    output.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }

        private void ReadFile(string fileName)
        {
            if (fileName.Split('.')[1] == "adj") // Read an adjective file
                try
                {
                    FileStream inStream = File.OpenRead(fileName);
                    BinaryReader input = new BinaryReader(inStream);
                    int adjCount = input.ReadInt32();
                    for (int i = 0; i < adjCount; i++)
                    {
                        string name = input.ReadString();
                        List<string> tempList = new List<string>();
                        int tempCount = input.ReadInt32();

                        for (int n = 0; n < tempCount; n++)
                        {
                            string tempAdj = input.ReadString();
                            tempList.Add(tempAdj);
                        }

                        WordFamily<string> tempFam = new WordFamily<string>(name);

                        foreach (string adj in tempList)
                            tempFam.Add(adj);

                        adjFams.Add(tempFam);
                    }

                    input.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            else if (fileName.Split('.')[1] == "noun") // Write a noun file
                try
                {
                    FileStream inStream = File.OpenRead(fileName);
                    BinaryReader input = new BinaryReader(inStream);
                    int nounCount = input.ReadInt32();
                    for (int i = 0; i < nounCount; i++)
                    {
                        string name = input.ReadString();

                        List<NounPair> tempList = new List<NounPair>();
                        int tempCount = input.ReadInt32();

                        for (int n = 0; n < tempCount; n++)
                        {
                            bool hasPlural = input.ReadBoolean();
                            string singular = input.ReadString();

                            if (hasPlural == true)
                            {
                                string plural = input.ReadString();
                                tempList.Add(new NounPair(singular, plural));
                            }
                            else
                                tempList.Add(new NounPair(singular));
                        }

                        WordFamily<NounPair> tempFam = new WordFamily<NounPair>(name);

                        foreach (NounPair noun in tempList)
                            tempFam.Add(noun);

                        nounFams.Add(tempFam);
                    }

                    input.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
        }

        public void UpdateFiles()
        {
            WriteFile("edgy.noun");
            WriteFile("edgy.adj");
            WriteToCSV();
        }

        private void WriteToCSV()
        {
            // Write the adjective file
            try
            {
                // Clear and flush content of the file
                FileStream fileStream = File.Open("edgy-adjs.csv", FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

                // Begin writing to the file
                FileStream outStream = File.OpenWrite("edgy-adjs.csv");
                StreamWriter output = new StreamWriter(outStream);

                foreach (WordFamily<string> adjFam in adjFams)
                {
                    output.Write(adjFam.Name + ",,");
                    output.WriteLine(string.Join(",", adjFam.Items));
                }

                // Stop writing
                output.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Write the noun file
            try
            {
                // Clear and flush content of the file
                FileStream fileStream = File.Open("edgy-nouns.csv", FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

                // Begin writing to the file
                FileStream outStream = File.OpenWrite("edgy-nouns.csv");
                StreamWriter output = new StreamWriter(outStream);

                foreach (WordFamily<NounPair> nounFam in nounFams)
                {
                    string row = nounFam.Name + ",,";

                    for (int i = 0; i < nounFam.Count; i++)
                    {
                        row += nounFam[i].Singular + "/" + nounFam[i].Plural;

                        if (i < nounFam.Count - 1)
                            row += ",";
                    }

                    output.WriteLine(row);
                }

                // Stop writing
                output.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // ----------------------------------------
        // - - - - - STUFF FOR ADJECTIVES - - - - -
        // ----------------------------------------



        public bool AddAdjFamily(string name)
        {
            // Search for a duplicate name
            foreach (WordFamily<string> adjFam in adjFams)
                if (adjFam.Name == name)
                    return false;

            adjFams.Add(new WordFamily<string>(name)); // Add the new family
            adjFams.Sort();                   // Sort the list
            WriteFile("edgy.adj");                    // Rewrite the file

            return true;
        }
        public void RemoveAdjFamily(string name)
        {
            adjFams.RemoveAt(IndexOfAdjFamily(name));
            WriteFile("edgy.adj"); // Rewrite external file
        }
        public int IndexOfAdjFamily(string inputName)
        {
            // Consider making this a binary search
            for (int i = 0; i < adjFams.Count; i++)
                if (adjFams[i].Name == inputName)
                    return i;

            return -1;
        }

        public WordFamily<string> AddAdj(string inputAdj, WordFamily<string> inputAdjFam)
        {
            // Check the entire family list for the input noun
            foreach (WordFamily<string> adjFam in adjFams)
                foreach (string adj in adjFam.Items)
                    if (adj == inputAdj) // If found, return the family that contains it
                        return adjFam;

            int index = adjFams.BinarySearch(inputAdjFam); // Find index of input family
            if (!adjFams[index].Add(inputAdj))             // Try adding input noun to family index
                return adjFams[index];                     // If it fails, return the family

            WriteFile("edgy.adj"); // Rewrite external file
            return null;      // Success
        }
        public int RemoveAdj(string inputAdj, WordFamily<string> inputAdjFam)
        {
            // Find the input noun within the family
            foreach (string adj in inputAdjFam.Items)
                if (adj == inputAdj)
                {
                    if (inputAdjFam.Remove(adj)) // Try removing noun
                    {
                        if (inputAdjFam.Count == 0) // If family is empty, remove it
                        {
                            adjFams.Remove(inputAdjFam);
                            WriteFile("edgy.adj");
                            return 1; // Noun and family were removed
                        }

                        WriteFile("edgy.adj");
                        return 0; // Noun was removed
                    }
                }

            return 2; // Noun wasn't found
        }

        public WordFamily<string> GetFamilyOf(string inputAdj)
        {
            // Make this less inefficient at some point
            foreach (WordFamily<string> fam in adjFams)
                for (int i = 0; i < fam.Count; i++)
                    if (fam[i] == inputAdj)
                        return fam;
            return null;
        }



        // -----------------------------------
        // - - - - - STUFF FOR NOUNS - - - - -
        // -----------------------------------

        public bool AddNounFamily(string name)
        {
            // Search for a duplicate name
            foreach (WordFamily<NounPair> nounFam in nounFams)
                if (nounFam.Name == name)
                    return false;

            nounFams.Add(new WordFamily<NounPair>(name)); // Add the new family
            nounFams.Sort();                          // Sort the list
            WriteFile("edgy.noun");                           // Rewrite the file

            return true;
        }
        public void RemoveNounFamily(string name)
        {
            nounFams.RemoveAt(IndexOfNounFamily(name));
        }
        public int IndexOfNounFamily(string inputName)
        {
            // Consider making this a binary search
            for (int i = 0; i < nounFams.Count; i++)
                if (nounFams[i].Name == inputName)
                    return i;

            return -1;
        }

        public WordFamily<NounPair> AddNoun(NounPair inputNoun, WordFamily<NounPair> inputNounFam)
        {
            // Check the entire family list for the input noun
            foreach (WordFamily<NounPair> nounFam in nounFams)
                foreach (NounPair noun in nounFam.Items)
                    if (noun.Singular == inputNoun.Singular) // If found, return the family that contains it
                        return nounFam;

            int index = nounFams.BinarySearch(inputNounFam); // Find index of input family
            if (!nounFams[index].Add(inputNoun)) // Try adding input noun to family index
                return nounFams[index];          // If it fails, return the family

            WriteFile("edgy.noun"); // Rewrite external file
            return null;       // Success
        }
        public int RemoveNoun(NounPair inputNoun, WordFamily<NounPair> inputFam)
        {
            // Find the input noun within the family
            foreach (NounPair noun in inputFam.Items)
                if (noun.Singular == inputNoun.Singular)
                {
                    if (inputFam.Remove(noun)) // Try removing noun
                    {
                        if (inputFam.Count == 0) // If family is empty, remove it
                        {
                            nounFams.Remove(inputFam);
                            WriteFile("edgy.noun");
                            return 1; // Noun and family were removed
                        }

                        WriteFile("edgy.noun");
                        return 0; // Noun was removed
                    }
                }

            return 2; // Noun wasn't found
        }

        public WordFamily<NounPair> GetFamilyOf(NounPair inputNoun)
        {
            // Make this less inefficient at some point
            foreach (WordFamily<NounPair> fam in nounFams)
                for (int i = 0; i < fam.Count; i++)
                    if (fam[i] == inputNoun)
                        return fam;
            return null;
        }



        // -------------------------------------
        // - - - - - RANDOM GENERATION - - - - -
        // -------------------------------------

        public EdgyName GetRandomName()
        {
            // -------
            // Legend:
            // -------
            // ADJ  - Adjective
            // SING - Singular noun (hasPlural == true)
            // NOUN - Singular noun (hasPlural == false)

            // --------------------------
            // All Possible combinations:
            // --------------------------
            // ADJ SING - ADJ NOUN
            // SING SING - SING NOUN - SING's SING - SING's NOUN
            // NOUN SING - NOUN NOUN - NOUN's SING - NOUN's NOUN

            // All of these are used at some point
            WordFamily<string> famA;
            WordFamily<NounPair> famN;
            string tempAdj;
            NounPair tempNounA;
            NounPair tempNounB;

            int roll = actOfGod.Next(2); // Roll a D2

            // The name building tree
            switch (roll)
            {
                // ADJ SING - ADJ NOUN
                case 0:
                    // Generate first word
                    famA = adjFams[actOfGod.Next(adjFams.Count)];
                    tempAdj = famA[actOfGod.Next(famA.Count)];

                    // Generate second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    // Construct full title
                    return new EdgyName(tempAdj, tempNounB, NameStyle.AdjNoun);

                // SING SING - SING NOUN - SING's SING - SING's NOUN
                // NOUN SING - NOUN NOUN - NOUN's SING - NOUN's NOUN
                case 1:
                    // Generate first word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounA = famN[actOfGod.Next(famN.Count)];

                    // Generate second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    // Construct full title
                    roll = actOfGod.Next(3); // Roll a D3
                    if (roll == 0)
                        return new EdgyName(tempNounA, tempNounB, NameStyle.PosNoun);
                    else
                        return new EdgyName(tempNounA, tempNounB, NameStyle.NounNoun);

                default:
                    return new EdgyName(new NounPair("Butter"), new NounPair("Boy", "Boys"), NameStyle.NounNoun);
            }
        }
        public EdgyTitle GetRandomTitle()
        {
            // -------
            // Legend:
            // -------
            // ADJ  - Adjective
            // SING - Singular noun (hasPlural == true)
            // PLUR - Plural noun (hasPlural == true)
            // NOUN - Singular noun (hasPlural == false)
            // VERB - Singular noun (verbBased == true)

            // --------------------------
            // All Possible combinations:
            // --------------------------
            // the ADJ SING - the ADJ NOUN
            // the SING SING - the SING NOUN
            // the NOUN SING - the NOUN NOUN
            // the SING's SING - the SING's NOUN
            //     NOUN's SING -     NOUN's NOUN
            // SING of the SING - SING of PLUR - the SING of PLUR - SING of NOUN - the SING of NOUN
            // NOUN of the SING - NOUN of PLUR - the NOUN of PLUR - NOUN of NOUN - the NOUN of NOUN 
            // SING of the ADJ - NOUN of the ADJ

            // All of these are used at some point
            WordFamily<string> famA;
            WordFamily<NounPair> famN;
            string tempAdj;
            NounPair tempNounA;
            NounPair tempNounB;

            int roll = actOfGod.Next(5); // Roll a D5

            // The title building tree
            switch (roll)
            {
                case 0:
                    // Generate the first word
                    famA = adjFams[actOfGod.Next(adjFams.Count)];
                    tempAdj = famA[actOfGod.Next(famA.Count)];

                    // Generate the second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    // Construct full title
                    return new EdgyTitle(tempAdj, tempNounB, TitleStyle.TheAdjNoun);

                case 1:
                    // Generate the first word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounA = famN[actOfGod.Next(famN.Count)];

                    // Generate the second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    // Construct full title
                    return new EdgyTitle(tempNounA, tempNounB, TitleStyle.TheNounNoun);

                case 2:
                    // Generate the first word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounA = famN[actOfGod.Next(famN.Count)];

                    // Generate the second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    // Construct full title
                    return new EdgyTitle(tempNounA, tempNounB, TitleStyle.ThePosNoun);

                case 3:
                    // Generate the first word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounA = famN[actOfGod.Next(famN.Count)];

                    // Generate the second word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounB = famN[actOfGod.Next(famN.Count)];

                    roll = actOfGod.Next(5); // Roll a D5
                    if (roll == 0)
                        return new EdgyTitle(tempNounA, tempNounB, TitleStyle.NounOfTheNoun);
                    if (roll == 1)
                        return new EdgyTitle(tempNounA, tempNounB, TitleStyle.TheNounOfTheNoun);
                    else if (roll == 2)
                        return new EdgyTitle(tempNounA, tempNounB, TitleStyle.NounOfPlur);
                    else if (roll == 3)
                        return new EdgyTitle(tempNounA, tempNounB, TitleStyle.NounOfThePlur);
                    else
                        return new EdgyTitle(tempNounA, tempNounB, TitleStyle.TheNounOfPlur);

                case 4:
                    // Generate the first word
                    famN = nounFams[actOfGod.Next(nounFams.Count)];
                    tempNounA = famN[actOfGod.Next(famN.Count)];

                    // Generate the second word
                    famA = adjFams[actOfGod.Next(adjFams.Count)];
                    tempAdj = famA[actOfGod.Next(famA.Count)];

                    // Construct full title
                    return new EdgyTitle(tempNounA, tempAdj, TitleStyle.NounOfTheAdj);

                default:
                    return new EdgyTitle("Sticky", new NounPair("Kid", "Kids"), TitleStyle.TheAdjNoun);
            }
        }

        public NounPair GetRandomNoun()
        {
            WordFamily<NounPair> famN = nounFams[actOfGod.Next(nounFams.Count)];
            return famN[actOfGod.Next(famN.Count)];
        }
        public string GetRandomAdj()
        {
            WordFamily<string> famA = adjFams[actOfGod.Next(adjFams.Count)];
            return famA[actOfGod.Next(famA.Count)];
        }


    }
}
