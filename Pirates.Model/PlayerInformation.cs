namespace Server.Commands.Informations
{

	#region Using
	using System;
	using Pirates.Model;
	#endregion
	[Serializable]
	class PlayerInformation
	{
		public string Ip { get; set; }
		public Player Player { get; set; }
	}
}
