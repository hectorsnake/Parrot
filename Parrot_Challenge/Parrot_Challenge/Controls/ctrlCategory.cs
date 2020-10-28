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
	public partial class ctrlCategory : UserControl
	{
		private bool _collapse = false;

		private Category _category = null;

		public Category Category
		{
			get { return _category;}
			set {
				_category = value;
				lblTitle.Text = _category?.Name;
			}
		}
		private List<Product> _products = null;

		public List<Product> Products
		{
			get {return _products; }
			set {
				_products = value;

				if (_products != null) { 
					foreach (Product product in _products) {
						ctrlProduct ctrl = new ctrlProduct();
						flowLayoutPanel1.Controls.Add(ctrl);
						ctrl.Product = product;
					}

					if (_category != null) {
						lblTitle.Text = $"{_category.Name} ({_products.Count})  ";
					}
				}
			}
		}
		public ctrlCategory()
		{
			InitializeComponent();
			picUp_Click(null, null);
		}

		private void ctrlCategory_Load(object sender, EventArgs e)
		{

		}

		private void picUp_Click(object sender, EventArgs e)
		{
			_collapse = true;
			picUp.Visible = false;
			picDown.Visible = true;
			this.Height = 55;
		}

		private void picDown_Click(object sender, EventArgs e)
		{
			_collapse = false;
			picDown.Visible = false;
			picUp.Visible = true;
			
			if (_products == null || _products.Count == 0) { 
				this.Height = 55;
			} else {
				this.Height = 55 + (_products.Count * 166);
			}
		}
	}
}
