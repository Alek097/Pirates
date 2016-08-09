namespace Pirates.Services
{
	public static class Service
	{
		public static void ConfigureService<T>()
			where T : class, IService, new()
		{
			T service = new T();
			service.Configure();
		}
	}
}
