using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InitiativeObjects
{
    class Character
    {
        public string name;
        public int maxHP;
        public int currentHP;
        public int AC;
        public int InitiativeMod;
        
        public Character(string name, int hp, int ac, int init)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.AC = ac;
            this.InitiativeMod = init;
        }

        public override string ToString()
        {
            return name;
        }
    }

    class Combat
    {
        public int round;
        public Queue<Character> InitiativeList;
        public List<Character> HeldList;
        public List<Character> ReadiedList;
        public List<Character> PlayerCharacters;
        public List<Character> NonPlayerCharacters;
        public List<Character> Enemies;

        public Combat()
        {
            InitiativeList = new Queue<Character>();
            HeldList = new List<Character>();
            ReadiedList = new List<Character>();
            PlayerCharacters = new List<Character>();
            NonPlayerCharacters = new List<Character>();
            Enemies = new List<Character>();
        }
    }
}
