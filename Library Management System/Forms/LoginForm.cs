using Library_Management_System.ExternalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_Management_System.Models;
using Library_Management_System.Data;
using CryptoHelper;

namespace Library_Management_System.Forms
{
	public partial class LoginForm : Form
	{
		private readonly BookEntities _context;
		public LoginForm()
		{
			_context = new BookEntities();
			InitializeComponent();
		}

		private void BtnLogin_Click(object sender, EventArgs e)
		
		{

			string sPass = Encrypt.GetSHA256(TxtboxPassword.Text.Trim());
			using (BookEntities db = new BookEntities())
			{
				var lst = from d in db.Users
						  where d.Username == TxtboxUsername.Text
						  && d.Password == sPass
						  select d;
				if (lst.Count() > 0)
				{
					this.Hide();
					Dashboard dsb = new Dashboard();
					dsb.FormClosed += (s, args) => this.Close();
					dsb.Show();
				}
				else
				{
					MessageBox.Show("user does not exist");
				}
			}
			//if (string.IsNullOrEmpty(TxtboxUsername.Text))
			//{
			//	MessageBox.Show("Insert Username");
			//	return;
			//}
			//if (string.IsNullOrEmpty(TxtboxPassword.Text))
			//{
			//	MessageBox.Show("Insert Password");
			//	return;
			//}
			//User user = _context.Users.FirstOrDefault(u => u.Username == TxtboxUsername.Text);

			//if (user != null && Crypto.VerifyHashedPassword(user.Password, TxtboxPassword.Text))
			//{
			//	Dashboard dashboard = new Dashboard();
			//	dashboard.Show();
			//	this.Hide();
			//}
			//MessageBox.Show("Wrong username or password ");
		}


	}
}
