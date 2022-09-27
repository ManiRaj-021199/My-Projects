using System;

namespace DummyBlazorApp.Data.DependencyInjectionExample
{
	public class DependencyInjection : IDependencyInjection
	{
		public DateTime Time { get; set; }

		public DependencyInjection()
		{
			Time = DateTime.Now;
		}

		public string GetTime()
		{
			return Time.ToString();
		}

		public string GetVersion()
		{
			return "v1";
		}
	}
}
