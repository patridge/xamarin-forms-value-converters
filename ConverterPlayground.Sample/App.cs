using System;

using Xamarin.Forms;

namespace ConverterPlayground.Sample
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new MainPageXaml () {
				BindingContext = new MainPageViewModel (),
			};
		}
	}
}
