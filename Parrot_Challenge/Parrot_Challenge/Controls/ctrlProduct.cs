using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parrot_Challenge.Models;

namespace Parrot_Challenge.Controls
{
	public partial class ctrlProduct : UserControl
	{
		private Product _product;

		public Product Product
		{
			get { return _product;}
			set {
				_product = value;

				if (_product != null) {
					lblCategory.Text = _product.Category?.Name;
					lblName.Text = _product.Name;
					lblPrice.Text = String.Format("$ {0:#,##0.00}", _product.Price);
					chkStatus.Checked = _product.Availability == "AVAILABLE";
					chkStatus.Text = " " + _product.Availability;
					imgMain.Load(_product.ImageUrl);
				}
			}
		}

		public ctrlProduct()
		{
			InitializeComponent();
		}

		private void chkStatus_CheckedChanged(object sender, EventArgs e)
		{
			try {
				if (_product == null)
					return;

				string value = String.Empty;

				if (chkStatus.Checked) {
					value = "AVAILABLE";
				} else {
					value = "UNAVAILABLE";
				}

				if (value != _product.Availability) {
					_product.Availability = value;
					chkStatus.Text = value;
					_product.RaiseAvailabilityChanged(_product.Availability);
				}
			} catch (Exception pE) {
				MessageBox.Show($"{pE.Message} \r\n {pE.StackTrace}");
			}
		}
	}
}
