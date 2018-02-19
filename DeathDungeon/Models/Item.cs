using System;
using SQLite;

namespace DeathDungeon.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public int AttackStat { get; set; }
        public int DefenseStat { get; set; }
        public int SpeedStat { get; set; }
        public int RangeStat { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }

        public void Update(Item newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            AttackStat = newData.AttackStat;
            DefenseStat = newData.DefenseStat;
            SpeedStat = newData.SpeedStat;
            RangeStat = newData.RangeStat;
            Location = newData.Location;
            Description = newData.Description;
        }
        public Item()
        {
            Name = "Empty Slot";
            AttackStat = 0;
            DefenseStat = 0;
            SpeedStat = 0;
            RangeStat = 1;
            Location = 0;
        }

        public Item(Location newitem)
        {
            Name = "Empty Slot";
            AttackStat = 0;
            DefenseStat = 0;
            SpeedStat = 0;
            RangeStat = 1;
            Location = newitem;
        }

        //case where empty slot from init
        public Item(string item, int attack, int defense, int speed, int range,
                        Location bodyLocation)
        {
            this.Name = item;
            this.AttackStat = attack;
            this.DefenseStat = defense;
            this.SpeedStat = speed;
            this.RangeStat = range;
            this.Location = bodyLocation;
        }
    }
}