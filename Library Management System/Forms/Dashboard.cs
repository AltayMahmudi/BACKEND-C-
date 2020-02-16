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
		BookInfo book = new BookInfo();
		Person person = new Person();
		OrderBook order = new OrderBook();
		public Dashboard()
		{
			InitializeComponent();
			FillBookDataGridView();
			FillPersonDataGridView();
			FillOrderPersonBookDGV();
			FillOrderListDGV();
		}
		           
		private void Dashboard_Load(object sender, EventArgs e)
		{
			ClearOrderList();
			ClearPerson();
			ClearBook();
		}
		//============================DataGridview=Fill=Start=================================
		//Fills DataGridView for Book with Corresponding Values from Database
		void FillBookDataGridView()
		{
			using (BookEntities db = new BookEntities())
			{
				DGVBooks.AutoGenerateColumns = false;
				DGVBooks.DataSource = db.Bookİnfoes.ToList<BookInfo>();
			
			}
		}
		//Fills DataGridView for Person with Corresponding Values from Database
		void FillPersonDataGridView()
		{
			using (BookEntities db = new BookEntities())
			{
				DGVPerson.AutoGenerateColumns = false;
				DGVPerson.DataSource = db.People.ToList<Person>();
				
			}
		}
		void FillOrderPersonBookDGV()
		{
			using (BookEntities db = new BookEntities())
			{
				
				DGVFindOrderS.AutoGenerateColumns = false;
				DGVFindBook.AutoGenerateColumns = false;
				DGVFindOrderS.DataSource = db.People.ToList<Person>();
				DGVFindBook.DataSource = db.Bookİnfoes.ToList<BookInfo>();

			}
		}
		void FillOrderListDGV()
		{
			using (BookEntities db = new BookEntities())
			{
			
				DGVOrderList.DataSource = db.OrderBooks.ToList<OrderBook>();
				DGVReport.DataSource= db.OrderBooks.ToList<OrderBook>();

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
		void ClearOrderList()
		{
			LabelpersonNameS.Text
			= LabelBookNames.Text = "";
			SaveOrderS.Text = "Save";
			DeleteOrderS.Enabled = false;
			order.OrderID = 0;
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
		private void DGVFindBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DGVFindBook.CurrentRow.Index != -1)
			{
				book.BookID = Convert.ToInt32(DGVFindBook.CurrentRow.Cells["dataGridViewTextBoxColumn10"].Value);
				using (BookEntities db = new BookEntities())
				{
					book = db.Bookİnfoes.Where(x => x.BookID == book.BookID).FirstOrDefault();
					LabelBookNames.Text = book.BookName;
				}
				BTNSave.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells
				BTNBookDelete.Enabled = true;
			}
		}
		private void DGVBooks_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
					dateTimePickerBook.Value = book.BookReleaseDate;
					textBoxQuantity.Text = book.BookQuantity;
					textBoxPrice.Text = book.BookPrice;
				}
				BTNSave.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells
				BTNBookDelete.Enabled = true;
			}
		}
		//BOOK DOUBLE-CLICK  END



		private void DGVOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DGVOrderList.CurrentRow.Index != -1)
			{
				order.OrderID = Convert.ToInt32(DGVOrderList.CurrentRow.Cells["OrderID"].Value);
				using (BookEntities db = new BookEntities())
				{
					order = db.OrderBooks.Where(x => x.OrderID == order.OrderID).FirstOrDefault();
					LabelBookNames.Text = order.BookOrderName;
					LabelpersonNameS.Text = order.PersonOrderName;
				}
				SaveOrderS.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells
				DeleteOrderS.Enabled = true;
			}
		}

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
		private void SaveOrderS_Click_1(object sender, EventArgs e)
		{
			//Make Fields Empty
			order.PersonOrderName = LabelpersonNameS.Text.Trim();
			order.BookOrderName = LabelBookNames.Text.Trim();
			order.IssueDate = DateTimePickerIssueDate.Value;
			order.Deadline = DateTimePickerDeadline.Value;
			//Make Fields Empty
			using (BookEntities db = new BookEntities())
			{
				//Checks wether if fields empty or not
				if (LabelpersonNameS.Text == "Name" ||
					LabelBookNames.Text == "Name")
				{ MessageBox.Show("Please fill fields from List"); }
				//Checks wether if fields empty or not
				else
				//if fieldboxes are not empty it allows operation 
				{
					if (order.OrderID == 0)
						db.OrderBooks.Add(order); //Insert Operation

					else db.Entry(order).State = EntityState.Modified;
					db.SaveChanges(); //update Operation
					MessageBox.Show("Submit Successfull");
				}
			}
			FillOrderListDGV();
			ClearOrderList();
		}


		//BOOK SAVE UPDATE START
		private void InsertNewBook_Click(object sender, EventArgs e)
		{
			book.BookName = textBoxBookName.Text.Trim();
			book.BookAuthor = textBoxAuthor.Text.Trim();
			book.BookPublicationName = textBoxPublication.Text.Trim();
			book.BookReleaseDate = dateTimePickerBook.Value;
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
		private void CancelOrder_Click(object sender, EventArgs e)
		{
			ClearOrderList();
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
		private void TxtOrderBox_TextChanged_1(object sender, EventArgs e)
		{
			DGVOrderList.DataSource = db.OrderBooks.Where(x =>
	x.PersonOrderName.Contains(TxtOrderBox.Text)).ToList();
		}

		private void TextBoxSearchBookName_TextChanged_1(object sender, EventArgs e)
		{
			DGVOrderList.DataSource = db.OrderBooks.Where(x =>
	x.BookOrderName.Contains(TextBoxSearchBookName.Text)).ToList();
		}


		private void txtFindPersonOrder_TextChanged(object sender, EventArgs e)
		{
			DGVFindOrderS.DataSource = db.People.Where(x =>
			x.Name.Contains(txtFindPersonOrder.Text)).ToList();
		}

		private void TextboxFindBookOrders_TextChanged(object sender, EventArgs e)
		{
			DGVFindBook.DataSource = db.Bookİnfoes.Where(x =>
			x.BookName.Contains(TextboxFindBookOrders.Text)).ToList();
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



		private void DGVFindOrderS_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DGVFindOrderS.CurrentRow.Index != -1)
			{
				person.PersonID = Convert.ToInt32(DGVFindOrderS.CurrentRow.Cells["dataGridViewTextBoxColumn1"].Value);
				using (BookEntities db = new BookEntities())
				{
					person = db.People.Where(x => x.PersonID == person.PersonID).FirstOrDefault();
					LabelpersonNameS.Text = person.Name;
				}
				BTNSave.Text = ("Update");
				//Delete Button becomes available once you double click to Rows/Cells
				BTNBookDelete.Enabled = true;
			}


			//=================================MISC=END=================================

		}

		private void DeleteOrderS_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to Return this", "EF CRUD Opp", MessageBoxButtons.YesNo) == DialogResult.Yes)
				//Confirm for Deletion
				using (BookEntities db = new BookEntities())
				{
					var entry = db.Entry(order);
					if (entry.State == EntityState.Detached)
						db.OrderBooks.Attach(order);
					db.OrderBooks.Remove(order);
					db.SaveChanges();
					//FillDataGridView
					FillOrderListDGV();
					ClearOrderList();
					MessageBox.Show("Returned Successfully");
				}
		}

	
	

		//===========================================EXCEL=EXPORT=================================================================
		private void BTNExport_Click_1(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
			Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
			Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
			worksheet = workbook.Sheets["Sheet1"];
			worksheet = workbook.ActiveSheet;
			worksheet.Name = "OrderDetail";
			for (int i = 1; i < DGVReport.Columns.Count + 1; i++)
			{
				worksheet.Cells[i, 1] = DGVReport.Columns[i - 1].HeaderText;
			}

			for (int i = 0; i < DGVReport.Rows.Count; i++)
			{
				for (int j = 0; j < DGVReport.Columns.Count; j++)
				{
					worksheet.Cells[i + 2, j + 1] = DGVReport.Rows[i].Cells[j].Value.ToString();
				}
			}
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "Output";
			saveFileDialog.DefaultExt = ".xlsx";
			if (saveFileDialog.ShowDialog()== DialogResult.OK)
			{
				workbook.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			}
		}

		private void RefreshDGV_Click(object sender, EventArgs e)
		{
			ClearOrderList();
		}
	}
}
