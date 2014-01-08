using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;


namespace InitiativeTrackerConsole
{
    class Program
    {
        

        static void Main(string[] args)
        {
            FileInfo players = new FileInfo("pc.txt");
            StreamReader sr = new StreamReader(players.OpenRead());
            Combat c = new Combat();

            string line;
            string[] parts;
            do
            {
                line = sr.ReadLine().Trim();
                if (line.Length > 0)
                {
                    parts = line.Split(',');
                    Console.WriteLine(line);
                    c.PlayerCharacters.Add(new Character(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                }
            }
            while (!sr.EndOfStream);

            foreach (Character item in c.PlayerCharacters)
            {
                c.ToString();
            }

        }
     
    }
}
