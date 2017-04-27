/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14.03.2017
 * Time: 13:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace ScreenSaver
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MainForm());
			
			if (args.Length > 0) {
				string firstArgument = args[0].ToLower().Trim();
				string secondArgument = null;
         
				// Handle cases where arguments are separated by colon.
				// Examples: /c:1234567 or /P:1234567
				if (firstArgument.Length > 2) {
					secondArgument = firstArgument.Substring(3).Trim();
					firstArgument = firstArgument.Substring(0, 2);
				} else if (args.Length > 1)
					secondArgument = args[1];
 
				if (firstArgument == "/c") {           // Configuration mode
					// TODO
				} else if (firstArgument == "/p") {      // Preview mode
					// TODO
				} else if (firstArgument == "/s") {      // Full-screen mode
					ShowScreenSaver();
					Application.Run();
				} else {    // Undefined argument
					MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
					"\" is not valid.", "ScreenSaver",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			} else {    // No arguments - treat like /c
				// TODO
			}
			
		}
		
		static void ShowScreenSaver()
		{
			foreach (Screen screen in Screen.AllScreens) {
				MainForm screensaver = new MainForm(screen.Bounds);
				screensaver.Show();
			}          
		}
		
	}
}
