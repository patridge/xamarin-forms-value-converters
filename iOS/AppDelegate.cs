using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace ConverterPlayground.Sample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}

	public class Application
	{
		public static ILogger Logger { get; set; }

		static void Main (string[] args)
		{
			#if DEBUG
			Logger = new LambdaLogger ((msg) => {
				Console.WriteLine (msg);
			});
			#else
			Logger = new NullLogger();
			#endif

			try {
				AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
				TaskScheduler.UnobservedTaskException += HandleTaskSchedulerException;

				UIApplication.Main (args, null, "AppDelegate");
			} catch (Exception ex) {
				HandleException (ex, fatal: true);
			}
		}

		static void OnUnhandledException (object sender, UnhandledExceptionEventArgs e)
		{
			HandleException (e.ExceptionObject as Exception, fatal: true);
		}

		static void HandleTaskSchedulerException (object sender, UnobservedTaskExceptionEventArgs e)
		{
			var exception = e != null
				? (e.Exception ?? new Exception ("Unhandled Task exception (null Exception)."))
				: new Exception ("Unhandled Task exception (null UnobservedTaskExceptionEventArgs).");
			HandleException (exception, fatal: false);
		}

		static void HandleException (Exception exception, bool fatal)
		{
			string description = string.Format ("Top-level exception: {0}", exception);
			Console.WriteLine (description);
			try {
				Logger.Error (description);
			} catch {
				// Swallow error during error reporting.
			}
		}

	}
}