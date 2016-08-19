namespace Server.Commands
{
	#region Using
	using System.Collections.Concurrent;
	using Informations;
	using System.Threading.Tasks;
	using System.Net.Sockets;
	using System.Text;
	#endregion
	class StartCommand : ServerCommand
	{
		private Task register = new Task(()=>
			{
				using (TcpClient newClient = new TcpClient("localhost", 80))
				{
					while (true)
					{
						byte[] bytes = new byte[newClient.ReceiveBufferSize];

						using (NetworkStream tcpStream = newClient.GetStream())
						{
							tcpStream.Read(bytes, 0, newClient.ReceiveBufferSize);
							
						}

						if(bytes.Length == 0)
						{
							continue;
						}

						string returnData = Encoding.UTF8.GetString(bytes);
					}
				}
			});
		public StartCommand()
			: base("Start", "Starting server.", new ParameterInformation[0])
		{
		}

		public override void Start(params Parameter[] parameters)
		{
			this.register.Start();
		}

	}
}
