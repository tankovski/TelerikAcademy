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
    public partial class EditCategories : System.Web.UI.Page
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
        public IQueryable<Category> EditCategoriesList_GetData()
        {
            var context = new LibrarySystemEntities();

            var categories = context.Categories;

            return categories;
        }


        protected void No_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = false;
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = true;
            this.InsertForm.Visible = false;
            this.EditCategoryForm.Visible = false;
            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);

            this.Yes.CommandArgument = id.ToString();
            var context = new LibrarySystemEntities();
            var category = context.Categories.Find(id);
            this.DeleteCategoryName.Text = category.Name;
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();

            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);


            var category = context.Categories.Find(id);

            context.Categories.Remove(category);

            try
            {
                context.SaveChanges();
                this.EditCategoriesList.DataBind();
                this.DeleteForm.Visible = false;
                ErrorSuccessNotifier.AddSuccessMessage("Category Deleted");
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
                string title = this.CategoryTitleTb.Text;
                Category category = new Category()
                {
                    Name = title
                };

                try
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    this.CategoryTitleTb.Text = "";
                    this.InsertForm.Visible = false;
                    this.EditCategoriesList.DataBind();

                    ErrorSuccessNotifier.AddSuccessMessage("Category created");
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

        protected void CreateNewCategoryBtn_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = false;
            this.EditCategoryForm.Visible = false;
            this.InsertForm.Visible = true;
        }

        protected void LenghtValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.CategoryTitleTb.Text;

            args.IsValid = text.Length < 150;
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            this.DeleteForm.Visible = false;
            this.InsertForm.Visible = false;
            this.EditCategoryForm.Visible = true;
            Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);

            this.SaveEditCategory.CommandArgument = id.ToString();

            var context = new LibrarySystemEntities();
            var category = context.Categories.Find(id);

            this.EditCategoryTitle.Text = category.Name;
        }

        protected void SaveEditCategory_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Button but = (Button)sender;
            int id = int.Parse(but.CommandArgument);
            string title = this.EditCategoryTitle.Text;

            var context = new LibrarySystemEntities();
            var category = context.Categories.Find(id);
            category.Name = title;

            try
            {
                context.SaveChanges();
                this.EditCategoryForm.Visible = false;
                this.EditCategoriesList.DataBind();
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("../EditCategories.aspx");
            }
            }
            
        }

        protected void CancelEditCategory_Click(object sender, EventArgs e)
        {
            this.EditCategoryForm.Visible = false;
        }

        protected void EditTitleLenghtValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var title = this.EditCategoryTitle.Text;

            args.IsValid = title.Length < 150;
        }

        
    }
}