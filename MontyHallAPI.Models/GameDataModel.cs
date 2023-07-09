namespace MontyHall.Models
{
    public class GameDataModel
    {
        public int GameDataId { get; set; }
        public int GameId { get; set; }
        public bool SwitchDoor { get; set; }
        public int SelectedDoorNumber { get; set; }
        public int WinDoorNumber { get; set; }
        public int RevealDoorNumber { get; set; }
    }
}