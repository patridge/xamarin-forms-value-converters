using System;

using Xamarin.Forms;

namespace ConverterPlayground.Sample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new MainPageXaml () {
				BindingContext = new MainPageViewModel (),
			};
		}
	}
}
