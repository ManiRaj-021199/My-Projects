namespace DummyBlazorApp.Data.DependencyInjectionExample
{
	public class DependencyInjection_V2 : IDependencyInjection
	{
		public DateTime Time { get; set; }

		public DependencyInjection_V2()
		{
			this.Time = DateTime.Now;
		}

		public string GetTime()
		{
			return this.Time.ToString();
		}

		public string GetVersion()
		{
			return "v2";
		}
	}
}
