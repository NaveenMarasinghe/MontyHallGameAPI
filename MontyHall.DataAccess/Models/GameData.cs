using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MontyHall.DataAccess.Models
{
    [Table("GameData")]
    public class GameData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int GameDataId { get; set; }

        [Column(Order = 1)]
        public int GameId { get; set; }

        [Column(Order = 2)]
        public bool SwitchDoor { get; set; }
        [Column(Order = 3)]
        public int? SelectedDoorNumber { get; set; }
        [Column(Order = 4)]
        public int? WinDoorNumber { get; set; }
        [Column(Order = 5)]
        public int? RevealDoorNumber { get; set; }
    }
}