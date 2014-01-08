using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using InitiativeObjects;

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
            string input;
            sr.Close();
            foreach (Character item in c.PlayerCharacters)
            {
                Console.Write(item.ToString() + " Initiative Total = ");
                input = Console.ReadLine();
                if (int.TryParse(input, out item.Initiative))
                {

                }
                else
                {
                    item.Initiative = 0;
                }
            }

            FileInfo enemies = new FileInfo("enemies.txt");

            sr = new StreamReader(enemies.OpenRead());

            do
            {
                line = sr.ReadLine().Trim();
                if (line.Length > 0)
                {
                    parts = line.Split(',');
                    Console.WriteLine(line);
                    Console.Write("Copies?");
                    input = Console.ReadLine();
                    int copies;
                    if(int.TryParse(input, out copies))
                    {
                        for (int i = 0; i < copies; i++)
                        {
                            c.Enemies.Add(new Character(parts[0] + (copies > 1 ? " " + (i + 1).ToString() : ""), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                        }
                        
                    }
                    else
                    {
                        c.Enemies.Add(new Character(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                    }
                }
            }
            while (!sr.EndOfStream);
            sr.Close();
            foreach (Character item in c.Enemies)
            {
                Console.Write(item.ToString() + " Initiative Total = ");
                input = Console.ReadLine();
                if (int.TryParse(input, out item.Initiative))
                {

                }
                else
                {
                    item.Initiative = 0;
                }
            }

            c.Combatants.AddRange(c.PlayerCharacters);
            c.Combatants.AddRange(c.Enemies);
            c.Combatants.Sort(new InitiativeSort());

            foreach (Character item in c.Combatants)
            {
                Console.WriteLine(item.ToString() + " " + item.Initiative.ToString() + " " + item.InitiativeMod.ToString() + " " + item.initrolloff.ToString());
                c.InitiativeList.Enqueue(item);
            }
            Console.ReadLine();


        }
     
    }
}
