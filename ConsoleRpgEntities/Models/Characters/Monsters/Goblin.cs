using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }
        public virtual Equipable Equipment { get; set; }

        public override void Attack(ITargetable target)
        {
            // Goblin-specific attack logic
            if (Equipment == null)
            {
                ((Player)target).Health--;
            }
            else
            {
                var damage = Equipment.Weapon.Damage - ((Player)target).Equipment.Armor.Defense;
                if (damage < 0)
                {
                    damage = 0;
                }

                var newHealth = ((Player)target).Health - damage;
                ((Player)target).Health = newHealth;
            }

            Console.WriteLine($"{Name} sneaks up and attacks {target.Name}!");
        }
    }
}
