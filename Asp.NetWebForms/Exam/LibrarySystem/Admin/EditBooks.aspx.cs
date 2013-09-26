using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Book> BooksListView_GetData()
        {
            var context = new LibrarySystemEntities();

            var books = context.Books;

            return books;
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            this.EditForm.Visible = true;
            this.DeleteForm.Visible = false;
            this.InsertForm.Visible = false;
            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);
            this.SaveEdit.CommandArgument = id.ToString();

            var context = new LibrarySystemEntities();
            var book = context.Books.Find(id);
            var categories = context.Categories;

            this.EditBookTitleTb.Text = book.Title;
            this.EditBookAuthorTb.Text = book.Author;
            this.EditBookIsbnTb.Text = book.ISBN;
            this.EditWebSiteTb.Text = book.WebSite;
            this.EditDescriptionTa.Value = book.Description;
            this.EditAllCategories.DataSource = categories.ToList();
            this.EditAllCategories.DataBind();


        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = true;
            this.InsertForm.Visible = false;
            this.EditForm.Visible = false;
            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);

            this.Yes.CommandArgument = id.ToString();
            var context = new LibrarySystemEntities();
            var book = context.Books.Find(id);
            this.DeleteCategoryName.Text = book.Title;
        }

        protected void CreateNewBookBtn_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = false;
            this.EditForm.Visible = false;
            this.InsertForm.Visible = true;

            var context = new LibrarySystemEntities();
            var categories = context.Categories;

            this.AllCategoriesList.DataSource = categories.ToList();
            this.AllCategoriesList.DataBind();
        }

        protected void No_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = false;
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();

            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);


            var book = context.Books.Find(id);

            context.Books.Remove(book);

            try
            {
                context.SaveChanges();
                this.BooksListView.DataBind();
                this.DeleteForm.Visible = false;
                ErrorSuccessNotifier.AddSuccessMessage("Book Deleted");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("../EditCategories.aspx");

            }
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var context = new LibrarySystemEntities();

                var title = this.BookTitleTb.Text;
                var author = this.BookAuthorTb.Text;
                var isbn = this.BookISBNTb.Text;
                var webSite = this.BookWebSite.Text;
                var description = this.BookDescriptionTa.Value;
                int categoryId = int.Parse(this.AllCategoriesList.SelectedValue);

                Book book = new Book()
                {
                    Title = title,
                    Author = author,
                    ISBN = isbn,
                    WebSite = webSite,
                    Description = description,
                    CategoryId = categoryId
                };

                try
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                    this.BooksListView.DataBind();
                    this.InsertForm.Visible = false;

                    this.BookTitleTb.Text = "";
                    this.BookAuthorTb.Text = "";
                    this.BookISBNTb.Text = "";
                    this.BookWebSite.Text = "";
                    this.BookDescriptionTa.Value = "";


                    ErrorSuccessNotifier.AddSuccessMessage("Book Added");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("../EditCategories.aspx");

                }
            }

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            this.InsertForm.Visible = false;
        }

        protected void AllFieldsLenghtInsert_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var title = this.BookTitleTb.Text;
            var author = this.BookAuthorTb.Text;
            var isbn = this.BookISBNTb.Text;
            var webSite = this.BookWebSite.Text;


            bool isBookValid = title.Length < 150 && author.Length < 150 && isbn.Length < 150 &&
                webSite.Length < 150;

            args.IsValid = isBookValid;
        }

        protected void DescriptionLenghtValidatorInser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var description = this.BookDescriptionTa.Value;

            args.IsValid = description.Length < 1000;
        }

        protected void EditAllFieldsLenght_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string title = this.EditBookTitleTb.Text;
            string author = this.EditBookAuthorTb.Text;
            string isbn = this.EditBookIsbnTb.Text;
            string webSite = this.EditWebSiteTb.Text;


            bool isBookValid = title.Length < 150 && author.Length < 150 && isbn.Length < 150 &&
                webSite.Length < 150;

            args.IsValid = isBookValid;
        }

        protected void EditDescriptionLenght_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string description = this.EditDescriptionTa.Value;

            args.IsValid = description.Length < 1000;
        }

        protected void CancelEdit_Click(object sender, EventArgs e)
        {
            this.EditForm.Visible = false;
        }

        protected void SaveEdit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string title = this.EditBookTitleTb.Text;
                string author = this.EditBookAuthorTb.Text;
                string isbn = this.EditBookIsbnTb.Text;
                string webSite = this.EditWebSiteTb.Text;
                string description = this.EditDescriptionTa.Value;
                int categoryId = int.Parse(this.EditAllCategories.SelectedValue);

                Button but = (Button)sender;
                int id = int.Parse(but.CommandArgument);

                var context = new LibrarySystemEntities();

                var book = context.Books.Find(id);

                book.Title = title;
                book.Author = author;
                book.ISBN = isbn;
                book.WebSite = webSite;
                book.Description = description;
                book.CategoryId = categoryId;

                try
                {
                    context.SaveChanges();
                    this.EditBookTitleTb.Text = "";
                    this.EditBookAuthorTb.Text = "";
                    this.EditBookIsbnTb.Text ="";
                    this.EditWebSiteTb.Text = "";
                    this.EditDescriptionTa.Value = "";
                    this.EditForm.Visible = false;
                    this.BooksListView.DataBind();

                    ErrorSuccessNotifier.AddSuccessMessage("Book Edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("../EditCategories.aspx");

                }
            }
        }
    }
}