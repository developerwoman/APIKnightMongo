using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIKnightMongo.Entities
{
    [Table("Weapons")]
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int Mod { get; set; }
        public string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
