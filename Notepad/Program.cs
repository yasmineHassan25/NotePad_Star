namespace Notepad
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            /* by it: start to apply windows seen on your form seen to appear by same style */
            ApplicationConfiguration.Initialize();

            /* Run()..Have formName which start run from it */
            
            Application.Run(new Start());
            
            /* notepad program runs after finishing time of start window */
            Application.Run(new Notepad());

            

        }
    }
}