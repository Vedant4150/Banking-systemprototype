using System;
using System.Threading;
using System.Windows.Forms;

namespace Bankappvedant
{
    internal static class Program
    {
        // STAThread is needed for Windows Forms to work properly
        // Concept used: Attribute
        [STAThread]
        static void Main()
        {
            // initializes app settings like default font and config
            // Concept used: Method call / application setup
            ApplicationConfiguration.Initialize();

            // this makes sure unhandled UI errors are caught instead of app just closing suddenly
            // Concept used: Exception handling
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // event subscription for UI thread exceptions
            // Concept used: Event handling
            Application.ThreadException += Application_ThreadException;

            // catches non-UI thread exceptions also
            // Concept used: Event handling / global exception handling
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // starts the main form of the application
            // Concept used: Object creation
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // this method runs when UI thread gets an unhandled exception
            // it shows the error message and stack trace in a message box
            MessageBox.Show(
                "Unhandled UI Exception:\n\n" +
                e.Exception.Message + "\n\n" +
                e.Exception.StackTrace,
                "Crash Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // trying to convert the error object into Exception type
            // Concept used: Type casting
            Exception ex = e.ExceptionObject as Exception;

            if (ex != null)
            {
                // if its a proper exception, show full details
                MessageBox.Show(
                    "Unhandled Exception:\n\n" +
                    ex.Message + "\n\n" +
                    ex.StackTrace,
                    "Crash Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                // if it is not a normal exception object, show generic message
                MessageBox.Show(
                    "Unhandled non-Exception error occurred.",
                    "Crash Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}