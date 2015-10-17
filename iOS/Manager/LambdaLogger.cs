using System;

namespace ConverterPlayground.Sample
{
	public class NullLogger : LambdaLogger
	{
		static Action<string> nullAction = (msg) => {
		};

		public NullLogger () : base (nullAction, nullAction, nullAction)
		{
		}
	}

	public class LambdaLogger : ILogger
	{
		readonly Action<string> InfoAction;
		readonly Action<string> WarningAction;
		readonly Action<string> ErrorAction;

		public LambdaLogger (Action<string> logInfoAction, Action<string> logWarningAction, Action<string> logErrorAction)
		{
			if (logInfoAction == null) {
				throw new ArgumentNullException ("logInfoAction");
			}
			if (logWarningAction == null) {
				throw new ArgumentNullException ("logWarningAction");
			}
			if (logErrorAction == null) {
				throw new ArgumentNullException ("logErrorAction");
			}

			InfoAction = logInfoAction;
			WarningAction = logWarningAction;
			ErrorAction = logErrorAction;
		}

		public LambdaLogger (Action<string> logAnyAction) : this (logAnyAction, logAnyAction, logAnyAction)
		{
		}

		public void Info (string message)
		{
			InfoAction (message ?? "");
		}

		public void Warn (string message)
		{
			WarningAction (message ?? "");
		}

		public void Error (string message)
		{
			ErrorAction (message ?? "");
		}
	}
}
