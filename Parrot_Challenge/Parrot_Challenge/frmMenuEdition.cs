using Newtonsoft.Json;
using Parrot_Challenge.Controls;
using Parrot_Challenge.Models;
using Parrot_Challenge.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parrot_Challenge
{
	public partial class frmMenuEdition : Form
	{
		private readonly Session _session;
		private readonly IDataService _dataService;
		private Store _store = null;

		public frmMenuEdition(Session pSession, IDataService pDataService)
		{
			InitializeComponent();
			_session = pSession;
			_dataService = pDataService;
		}

		private async void frmMenuEdition_Load(object sender, EventArgs e)
		{
			try {
				LoginResponse tempLoginResponse = getTempLoginResponse();
				if (tempLoginResponse != null) {
					_session.Token = tempLoginResponse.Access;
					_session.Refresh = tempLoginResponse.Refresh;
					ValidateTokenResponse validateTokenResponse = await _dataService.ValidateToken();
					if (validateTokenResponse == null || validateTokenResponse.Status != "ok") {
						showLogin();
					}
				} else {
					showLogin();
				}

				StoresResponse storesResponse = await _dataService.GetMyStores();
				if (storesResponse != null &&
					storesResponse.Status == "ok") {
					_store = storesResponse.Result?.Stores.FirstOrDefault();
					btnRefresh_Click(sender, e);
				}
			} catch (Exception pE) {
				MessageBox.Show($"{pE.Message}\r\n{pE.StackTrace}");
			}
		}

		private void showLogin()
		{
			frmLogin fLogin = new frmLogin(_session, _dataService);

			if (fLogin.ShowDialog() == DialogResult.OK) {
				//store
				setTempLoginResponse();
			}
			else {
				Application.Exit();
			}
		}

		private LoginResponse getTempLoginResponse()
		{
			try { 
				string text = System.IO.File.ReadAllText(System.IO.Path.GetTempPath() + "LoginResponse.txt");
				
				LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(text);
				return loginResponse;
			} catch {
				return null;
			}
		}

		private void setTempLoginResponse()
		{
			try { 
				LoginResponse loginResponse = new LoginResponse() {
					Access = _session.Token,
					Refresh = _session.Refresh,
				};

				System.IO.File.WriteAllLines(System.IO.Path.GetTempPath() + "LoginResponse.txt", new string[] { JsonConvert.SerializeObject(loginResponse) } );

			} catch {
			}
		}


		private async void btnRefresh_Click(object sender, EventArgs e)
		{
			try {
				if (_store == null) {
					return;
				}

				flowLayoutPanel1.Controls.Clear();

				lblStoreName.Text = _store.Name;
				ProductsResponse productsResponse = await _dataService.GetProducts(_store.Uuid);
				List<Product> products = productsResponse.Results;

				foreach(Product product in products) {
					product.OnAvailabilityChanged += Product_OnAvailabilityChanged;
				}

				List<Category> categories = products.Select(o => o.Category).Distinct(new ComparerCategory()).ToList();

				foreach(Category category in categories) {
					ctrlCategory ctrl = new ctrlCategory();
					flowLayoutPanel1.Controls.Add(ctrl);
					ctrl.Category = category;
					ctrl.Products = products.FindAll(p => p.Category.Uuid == category.Uuid);
				}
			}
			catch (Exception pE) {
				MessageBox.Show($"{pE.Message}\r\n{pE.StackTrace}");
			}
		}

		private async void Product_OnAvailabilityChanged(Product pProduct, string pAvailability)
		{
			try {
				ProductResponse productResponse = await _dataService.UpdateProductAvailability(pProduct.Uuid, pAvailability);
				if (productResponse != null && productResponse.Result != null) {
					pProduct.Availability = productResponse.Result.Availability;
				}
			} catch (Exception pE) {
				MessageBox.Show($"{pE.Message}\r\n{pE.StackTrace}");
			}
		}
	}
}
