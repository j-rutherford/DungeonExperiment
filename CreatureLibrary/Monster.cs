using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureLibrary
{
    public class Monster : Creature
    {
        private int _minDamage;
        public int ID { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage { get => _minDamage; set => _minDamage = value <= MaxDamage && value >= 0 ? value : 1; }

        public Monster(int id, string name, int maxHealth, string description, int maxDamage, int minDamage) : base(name, maxHealth, description)
        {
            ID = id;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }

        public Monster()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static List<Monster> GetMonsters()
        {
            return new List<Monster>() {
                new Monster(0,"Monster 1",100,null,15,5),
                new Monster(1,"Monster 2",100,null,15,5),
                new Monster(2,"Monster 3",100,null,15,5),
                new Monster(3,"Monster 4",100,null,15,5),
                new Monster(4,"No Monster",0,null,0,0)
            };
        }
        public static Monster GetMonsterById(int id)
        {
            return GetMonsters().FirstOrDefault(x => x.ID == id);
        }
    }
}
