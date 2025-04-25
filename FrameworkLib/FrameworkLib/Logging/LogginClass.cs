using System.Diagnostics;

namespace FrameworkLib.Logging
{
    /// <summary>
    /// Simple logger that uses TraceSource to log messages from the framework.
    /// Supports different levels: Information, Warning, Error, Critical.
    /// Allows users to add their own TraceListeners (e.g., for file logging).
    /// </summary>
    public static class Logger
    {
        // Opret en TraceSource, som frameworket bruger til al logning
        private static readonly TraceSource ts = new TraceSource("GameFramework");

        static Logger()
        {
            // Sæt logniveauet til "All" for at tillade alle typer beskeder
            ts.Switch = new SourceSwitch("GameSwitch", "All");

            // Tilføj kun en standard konsol-listener, hvis ingen allerede findes
            if (ts.Listeners.Count == 0)
            {
                ts.Listeners.Add(new ConsoleTraceListener());
            }
        }

        /// <summary>
        /// Logs a message with the given TraceEventType (default is Information).
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="type">The severity/type of the log message.</param>
        public static void Log(string message, TraceEventType type = TraceEventType.Information)
        {
            ts.TraceEvent(type, 0, message);
            ts.Flush(); // Sikrer at beskeden sendes med det samme
        }

        /// <summary>
        /// Exposes the listener collection so the user can add/remove TraceListeners.
        /// This allows logging to files, custom formats, or external systems.
        /// </summary>
        public static TraceListenerCollection Listeners => ts.Listeners;
    }
}

