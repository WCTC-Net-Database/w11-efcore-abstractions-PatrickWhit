using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipables_Items
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // navigation property
        public virtual List<Player> Characters { get; set; }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

    }

    public class Armor : Item
    {
        public int Defense { get; set; }
    }
}
