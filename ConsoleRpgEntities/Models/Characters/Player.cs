using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipables_Items;
using ConsoleRpgEntities.Models.Equipment;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual IEnumerable<Ability> Abilities { get; set; }
        public virtual Equipable Equipment { get; set; }
        public virtual List<Item> Items { get; set; }

        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            var damage = Equipment.Weapon.Damage - target.Equipment.Armour.Defence;
            if (damage < 0) {
                damage = 0;
            }

            var newHealth = target.Health - damage;
            target.Health = newHealth;

            Console.WriteLine($"{Name} attacks {target.Name} with a sword!");
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
