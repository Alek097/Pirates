namespace Pirates.Model
{
	#region Using
	using System.IO;
	using System.Text;
	using System.Xml;
	using System.Xml.Serialization;
	#endregion
	public static class Converter
	{
		public static byte[] GetBytes<T>(T obj)
		{
			XmlSerializer serilizer = new XmlSerializer(typeof(T));

			using (TextWriter writer = new StringWriter())
			{
				serilizer.Serialize(writer, obj);

				return Encoding.UTF8.GetBytes(writer.ToString());
			}
		}

		public static T GetObject<T>(byte[] bytes)
		{
			XmlSerializer serilizer = new XmlSerializer(typeof(T));

			using (StringReader stringReader = new StringReader(Encoding.UTF8.GetString(bytes)))
			{
				using (XmlReader reader = XmlReader.Create(stringReader))
				{
					return (T)serilizer.Deserialize(reader);
				}
			}
		}
	}
}
