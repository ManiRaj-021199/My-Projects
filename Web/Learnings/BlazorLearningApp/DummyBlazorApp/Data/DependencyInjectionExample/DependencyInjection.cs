namespace DummyBlazorApp.Data.DependencyInjectionExample
{
	public class DependencyInjection : IDependencyInjection
	{
		public DateTime Time { get; set; }

		public DependencyInjection()
		{
			this.Time = DateTime.Now;
		}

		public string GetTime()
		{
			return this.Time.ToString();
		}

		public string GetVersion()
		{
			return "v1";
		}
	}
}
