using Parrot_Challenge.Exceptions;
using Parrot_Challenge.Models;
using Parrot_Challenge.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parrot_Challenge
{
	public partial class frmLogin : Form
	{
		private readonly Session _session;
		private readonly IDataService _dataService;

		public frmLogin(Session pSession, IDataService pDataService)
		{
			InitializeComponent();
			_session = pSession;
			_dataService = pDataService;
		}

		private void frmLogin_Load(object sender, EventArgs e)
		{
			textbox_TextChanged(sender, e);
		}

		private void textbox_TextChanged(object sender, EventArgs e)
		{
			btnLogin.Enabled = !String.IsNullOrEmpty(txtUser.Text) && !String.IsNullOrEmpty(txtPassword.Text);
		}

		private async void btnLogin_Click(object sender, EventArgs e)
		{
			try {
				if (String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtPassword.Text))
					return;

				User user = new User() {
					username = txtUser.Text,
					password = txtPassword.Text
				};

				user.username = "android-challenge@parrotsoftware.io";
				user.password = "8mngDhoPcB3ckV7X";

				var response = await _dataService.Login(user);

				if (response != null) {
					_session.Token = response.Access;
					_session.Refresh = response.Refresh;
					this.DialogResult = DialogResult.OK;
					//frmMenuEdition frm = new frmMenuEdition(_session, _dataService);
					//frm.Show();
				}
			}
			catch (ServiceUnauthorizedException pE) {
				MessageBox.Show("user and/or password incorrect");
			}
			catch (Exception pE) {
				MessageBox.Show($"{pE.Message} \r\n { pE.StackTrace}");
			}
		}
	}
}
