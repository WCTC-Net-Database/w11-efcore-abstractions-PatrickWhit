using ConsoleRpgEntities.Models.Equipables_Items;

namespace ConsoleRpgEntities.Models.Equipment
{
    public class Equipable
    {
        public int Id { get; set; }

        // Navigation prperties
        public virtual Weapon? Weapon { get; set; }
        public virtual Armor? Armor { get; set; }
    }
}
