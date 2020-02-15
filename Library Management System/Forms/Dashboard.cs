using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_Management_System.Forms;
using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Forms
{
	public partial class Dashboard : Form
	{

		BookEntities db = new BookEntities();
		BookInfo book= new BookInfo();
		Person person = new Person();
		public Dashboard()
		{
			InitializeComponent();
			FillBookDataGridView();
			FillPersonDataGridView();
			FillOrderPersonDGV();
		}
		private void Dashboard_Load(object sender, EventArgs e)
		{
			ClearPerson();
			ClearBook();
		}
		//============================DataGridview=Fill=Start=================================
		//Fills DataGridView for Book with Corresponding Values from Database
		void FillBookDataGridView() 
		{
			using (BookEntities db=new BookEntities())
			{
				DGVBooks.DataSource = db.Bookİnfoes.ToList<BookInfo>();
			}
		}
		//Fills DataGridView for Person with Corresponding Values from Database
		void FillPersonDataGridView()
		{
			using (BookEntities db = new BookEntities())
			{
				DGVPerson.DataSource = db.People.ToList<Person>();
			}
		}
		void FillOrderPersonDGV()
		{
			using (BookEntities db = new BookEntities())
			{
				DGVFindOrderS.DataSource = db.People.ToList<Person>();
			}
		}
		//=============================DataGridview=Fill=End==================================

		//==============================CLEAR=TEXTBOX=START===================================
		//Cleans Filled Textboxes,Used after DELETE/ADD/INSERT operations
		void ClearPerson()
		{
	
			TxtBoxPersonName.Text 
			= TxtBoxSurname.Text 
		    = TxtBoxPhone.Text 
			= TxtBoxEmail.Text = "";
			BTNPersonSave.Text = "Save";
			BTNPersonDelete.Enabled = false;
			person.PersonID = 0;
		}

		void ClearBook()
		{
			textBoxBookName.Text 
			= textBoxAuthor.Text 			                 
			= textBoxPublication.Text               
			= textBoxPrice.Text  
			= textBoxQuantity.Text = "";
			BTNSave.Text = "Save";
			BTNBookDelete.Enabled = false;
			book.BookID = 0;
		}
		//==============================CLEAR=TEXTBOX=START==========================


		//=============================CLİCK-START============================

		//Double Clicking Fills Empty Textboxes therefore makes Updating possible
		//BOOK DOUBLE-CLICK  START
		private void DGVBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DGVBooks.CurrentRow.Index != -1)
			{
				book.BookID = Convert.ToInt32(DGVBooks.CurrentRow.Cells["BookID"].Value);
				using (BookEntities db = new BookEntities())
				{
					book = db.Bookİnfoes.Where(x => x.BookID == book.BookID).FirstOrDefault();
					textBoxBookName.Text = book.BookName;
					textBoxAuthor.Text = book.BookAuthor;
					textBoxPublication.Text = book.BookPublicationName;
					dateTimePickerBook.Value = book.BookPurchaseDate;
					textBoxQuantity.Text = book.BookQuantity;
					textBoxPrice.Text = book.BookPrice;
				}
				BTNSave.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells
				BTNBookDelete.Enabled = true;
			}
		}
		//BOOK DOUBLE-CLICK  END

		//PERSON DOUBLE-CLICK  START



		private void DGVPerson_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DGVPerson.CurrentRow.Index != -1)

			{
				person.PersonID = Convert.ToInt32(DGVPerson.CurrentRow.Cells["PersonID"].Value);
				using (BookEntities db = new BookEntities())
				{
					person = db.People.Where(x => x.PersonID == person.PersonID).FirstOrDefault();
					TxtBoxPersonName.Text = person.Name;
					TxtBoxSurname.Text = person.Surname;
					TxtBoxPhone.Text = person.Phone;
					TxtBoxEmail.Text = person.Email;
				}

				BTNPersonSave.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells in DataGridView
				BTNPersonDelete.Enabled = true;
				//PERSON DOUBLE-CLICK  END
			}


		}



			//=============================CLİCK-END==============================

			//========================SAVE-UPDATE-BUTTON-START===========================

			//BOOK SAVE UPDATE START
			private void InsertNewBook_Click(object sender, EventArgs e)
		{
			book.BookName = textBoxBookName.Text.Trim();
			book.BookAuthor = textBoxAuthor.Text.Trim();
			book.BookPublicationName = textBoxPublication.Text.Trim();
			book.BookPurchaseDate = dateTimePickerBook.Value;
			book.BookQuantity = textBoxQuantity.Text.Trim();
			book.BookPrice = textBoxPrice.Text.Trim();
			using (BookEntities db = new BookEntities())
			{
				////Checks wether if fields empty or not
				if (textBoxBookName.Text == "" || textBoxAuthor.Text == "" || textBoxPublication.Text == "" || textBoxQuantity.Text == "" || textBoxPrice.Text == "")
				{ MessageBox.Show("Please fill in all the fields"); }
				else
				{
					if (book.BookID == 0)
						db.Bookİnfoes.Add(book); //Insert

					else db.Entry(book).State = EntityState.Modified;
					db.SaveChanges(); //update
					MessageBox.Show("Submit Successfull");
				}
			}

			ClearBook();
			FillBookDataGridView();
		}
		//BOOK SAVE UPDATE END

		//PERSON SAVE UPDATE START
		private void BTNPersonSave_Click(object sender, EventArgs e)
		{
			//Make Fields Empty
			person.Name = TxtBoxPersonName.Text.Trim();
			person.Surname = TxtBoxSurname.Text.Trim();
			person.Email = TxtBoxEmail.Text.Trim();
			person.Phone = TxtBoxPhone.Text.Trim();
			//Make Fields Empty
			using (BookEntities db = new BookEntities())
			{
				//Checks wether if fields empty or not
				if (TxtBoxPersonName.Text == "" || 
					TxtBoxSurname.Text == "" || 
					TxtBoxPhone.Text == "" || 
					TxtBoxEmail.Text == "")
				{ MessageBox.Show("Please fill in all the fields"); }
				//Checks wether if fields empty or not
				else
				//if fieldboxes are not empty it allows operation 
				{
				if (person.PersonID == 0)
				     db.People.Add(person); //Insert Operation

				else db.Entry(person).State = EntityState.Modified;

					 db.SaveChanges(); //update Operation
					MessageBox.Show("Submit Successfull");
				}
			}
			ClearPerson();
			FillPersonDataGridView();
			//PERSON SAVE UPDATE START
		}
		//=========================SAVE-UPDATE-BUTTON-END============================
		//===========================DELETE-BUTTON-START=============================
		private void BTNBookDelete_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to Delete this", "EF CRUD Op", MessageBoxButtons.YesNo) == DialogResult.Yes)
				//Confirm for Deletion
				using (BookEntities db = new BookEntities())
				{
					var entry = db.Entry(book);
					if (entry.State == EntityState.Detached)
					db.Bookİnfoes.Attach(book);
					db.Bookİnfoes.Remove(book);
					db.SaveChanges();
					//FillDataGridView
					FillBookDataGridView();
					ClearBook();
					MessageBox.Show("Deleted Successfully");
				}
		}
		private void BTNPersonDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to Delete this", "EF CRUD Opp", MessageBoxButtons.YesNo) == DialogResult.Yes)
				//Confirm for Deletion
				using (BookEntities db = new BookEntities())
				{
			var entry = db.Entry(person);
					if (entry.State == EntityState.Detached)
					db.People.Attach(person);
					db.People.Remove(person);
					db.SaveChanges();
					//FillDataGridView
					FillPersonDataGridView();
					ClearPerson();
					MessageBox.Show("Deleted Successfully");
				}
		}
		//============================DELETE-BUTTON-END==============================
		//===========================CANCEL-BUTTON-START=============================

		private void BTNCancel_Click_1(object sender, EventArgs e)
		{
			ClearBook();
		}
		private void BTNPersonCancel_Click(object sender, EventArgs e)
		{
			ClearPerson();
		}
		//============================CANCEL-BUTTON-EMD==============================

		//=============================SEARCH-START==================================
		//Book Search Box
		private void SearchBook_TextChanged(object sender, EventArgs e)
		{
			DGVBooks.DataSource = db.Bookİnfoes.Where(x => 
			x.BookName.Contains(SearchBook.Text) || 
			x.BookAuthor.Contains(SearchBook.Text)).ToList();
		}

		private void SearchPrice_TextChanged(object sender, EventArgs e)
		{
			DGVBooks.DataSource = db.Bookİnfoes.Where(x => 
			x.BookPrice.Contains(SearchPrice.Text)).ToList();
		}

		//Person Search Box
		private void TxtSearchName_TextChanged(object sender, EventArgs e)
		{
			DGVPerson.DataSource = db.People.Where(x => 
			x.Name.Contains(TxtSearchName.Text)).ToList();
		}

		private void TxtSearchSurname_TextChanged(object sender, EventArgs e)
		{
			DGVPerson.DataSource = db.People.Where(x => 
			x.Surname.Contains(TxtSearchSurname.Text)).ToList();
		}

		private void TxtSearchPhone_TextChanged(object sender, EventArgs e)
		{
			DGVPerson.DataSource = db.People.Where(x => 
			x.Phone.Contains(TxtSearchPhone.Text)).ToList();
		}

		private void TxtSearchEmail_TextChanged(object sender, EventArgs e)
		{
			DGVPerson.DataSource = db.People.Where(x =>
			x.Email.Contains(TxtSearchEmail.Text)).ToList();
		}
		//================================SEARCH=END=================================

		//================================MISC=START=================================
		private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;

			if (ch == 46 && textBoxPrice.Text.IndexOf('.') != -1)
			{
				e.Handled = true;
				return;
			}
			if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
			{
				e.Handled = true;
			}
		}

		private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if (!Char.IsDigit(ch) && ch != 8)
			{
				e.Handled = true;
			}
		}

		//Form Close Confirmation 
		private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to close?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				e.Cancel = true;
			}
		}

	









		//=================================MISC=END=================================



	}
}
