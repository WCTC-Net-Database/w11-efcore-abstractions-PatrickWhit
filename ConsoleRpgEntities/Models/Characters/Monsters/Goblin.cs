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
            var damage = Equipment.Weapon.Damage - target.Equipment.Armour.Defence;
            if (damage < 0)
            {
                damage = 0;
            }

            var newHealth = target.Health - damage;
            target.Health = newHealth;

            Console.WriteLine($"{Name} sneaks up and attacks {target.Name}!");
        }
    }
}
