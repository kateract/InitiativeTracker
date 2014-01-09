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
                int output;
                if (int.TryParse(input, out output))
                {
                    item.Initiative = output;
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
                        if (copies > 1)
                        {
                            InitiativeGroup g = new InitiativeGroup(parts[0] + "s (" + copies.ToString() + ")", int.Parse(parts[3]));
                            for (int i = 0; i < copies; i++)
                            {
                                g.Add(new Character(parts[0] + " " + (i + 1).ToString(), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                            }
                            c.Enemies.Add(g);
                        }
                        else
                            c.Enemies.Add(new Character(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                    }
                    else
                    {
                        c.Enemies.Add(new Character(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                    }
                }
            }
            while (!sr.EndOfStream);
            sr.Close();
            foreach (IInitiative item in c.Enemies)
            {
                Console.Write(item.ToString() + " Initiative Total = ");
                input = Console.ReadLine();
                int output;
                if (int.TryParse(input, out output))
                {
                    item.Initiative = output;
                }
                else
                {
                    item.Initiative = 0;
                }
            }

            c.Combatants.AddRange(c.PlayerCharacters);
            c.Combatants.AddRange(c.Enemies);
            c.Combatants.Sort(new InitiativeSort());

            foreach (var item in c.Combatants)
            {
                Console.WriteLine(item.ToString() + " \t" + item.Initiative.ToString() + " " + item.InitiativeMod.ToString() + " " + item.initrolloff.ToString());
                c.InitiativeList.Enqueue(item);
            }
            Console.ReadLine();


        }
     
    }
}
    