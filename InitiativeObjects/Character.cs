using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InitiativeObjects
{
    public interface IInitiative
    {
        string Name {get; set;}
        int InitiativeMod { get; set; }
        int Initiative { get; set; }
        int initrolloff { get; set; }
    }

    public class Character : IInitiative
    {
        public string name;
        public int maxHP;
        public int currentHP;
        public int AC;

        
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
            return Name;
        }


        #region IInitiative Members

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private int initiativeMod;
        public int InitiativeMod
        {
            get
            {
                return this.initiativeMod;
            }
            set
            {
                this.initiativeMod = value;
            }
        }

        private int initiative;
        public int Initiative
        {
            get
            {
                return this.initiative;
            }
            set
            {
                this.initiative = value;
            }
        }
        private int _initirolloff;
        public int initrolloff
        {
            get
            {
                return _initirolloff;
            }
            set
            {
                _initirolloff = value;
            }
        }

        #endregion
    }

    public class InitiativeGroup : IInitiative, IList<Character>
    {
        private List<Character> _characters;
        private string name;

        public override string ToString()
        {
            return name;
        }

        public InitiativeGroup(string name, int init)
        {
            _characters = new List<Character>();
            this.name = name;
        }

        #region IList<Character> Members

        public int IndexOf(Character item)
        {
            return _characters.IndexOf(item);
        }

        public void Insert(int index, Character item)
        {
            _characters.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _characters.RemoveAt(index);
        }

        public Character this[int index]
        {
            get
            {
                return _characters[index];
            }
            set
            {
                _characters[index] = value;
            }
        }

        #endregion

        #region ICollection<Character> Members

        public void Add(Character item)
        {
            _characters.Add(item);
        }

        public void Clear()
        {
            _characters.Clear();
        }

        public bool Contains(Character item)
        {
            return _characters.Contains(item);
        }

        public void CopyTo(Character[] array, int arrayIndex)
        {
            _characters.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _characters.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Character item)
        {
            return _characters.Remove(item);
        }

        #endregion

        #region IEnumerable<Character> Members

        public IEnumerator<Character> GetEnumerator()
        {
            return _characters.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _characters.GetEnumerator();
        }

        #endregion

        #region IInitiative Members

        string IInitiative.Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private int initiativeMod;
        public int InitiativeMod
        {
            get
            {
                return this.initiativeMod;
            }
            set
            {
                this.initiativeMod = value;
            }
        }

        private int initiative;
        public int Initiative
        {
            get
            {
                return this.initiative;
            }
            set
            {
                this.initiative = value;
            }
        }
        private int _initirolloff;
        public int initrolloff
        {
            get
            {
                return _initirolloff;
            }
            set
            {
                _initirolloff = value;
            }
        }

        #endregion
    }

    public class InitiativeSort : Comparer<IInitiative>
    {
        private static Random r;
        public static Random R
        {
            get
            {
                if (r == null)
                {
                    r = new Random();
                }
                return r;
            }

        }


        public override int Compare(IInitiative y, IInitiative x)
        {
            if (x.Initiative.CompareTo(y.Initiative) != 0)
            {
                return x.Initiative.CompareTo(y.Initiative);
            }
            else if (x.InitiativeMod.CompareTo(y.InitiativeMod) != 0)
            {
                return x.InitiativeMod.CompareTo(y.InitiativeMod);
            }
            else
            {
                
                y.initrolloff = R.Next(21, 40);
                x.initrolloff = R.Next(1, 20);
                if (x.initrolloff == y.initrolloff) 
                    return 0;
                else
                {
                    y.initrolloff %= 20;
                    return x.initrolloff.CompareTo(y.initrolloff);
                }

            }

        }
    }

    public class Combat
    {
        public int round;
        public Queue<IInitiative> InitiativeList;
        public List<IInitiative> HeldList;
        public List<IInitiative> ReadiedList;
        public List<IInitiative> PlayerCharacters;
        public List<IInitiative> NonPlayerCharacters;
        public List<IInitiative> Enemies;
        public List<IInitiative> Combatants;
        public Combat()
        {
            InitiativeList = new Queue<IInitiative>();
            HeldList = new List<IInitiative>();
            ReadiedList = new List<IInitiative>();
            PlayerCharacters = new List<IInitiative>();
            NonPlayerCharacters = new List<IInitiative>();
            Enemies = new List<IInitiative>();
            Combatants = new List<IInitiative>();
        }
    }
}
