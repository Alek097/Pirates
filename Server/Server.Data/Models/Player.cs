namespace Server.Models
{
	public class Player : Pirates.Model.Player
	{
		public virtual Ship Ship { get; set; }
		public virtual Role Role { get; set; }
	}
}
