using Parrot_Challenge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parrot_Challenge
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Session session = new Session();
			GenericRepository genericRepository = new GenericRepository();
			DataService dataService = new DataService(genericRepository, session);
			Application.Run(new frmMenuEdition(session, dataService));
		}
	}
}
