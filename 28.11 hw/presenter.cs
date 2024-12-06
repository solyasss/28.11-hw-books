using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace authors_and_books
{
    public class presenter
    {
        private readonly i_view view;
        private readonly mod model;

        public presenter(i_view view)
        {
            this.view = view;
            model = new mod();

            // Подписываемся на события view
            view.author_selected += on_author_selected;
            view.filter_changed += on_filter_changed;
            view.add_author_clicked += on_add_author_clicked;
            view.edit_author_clicked += on_edit_author_clicked;
            view.delete_author_clicked += on_delete_author_clicked;
            view.add_book_clicked += on_add_book_clicked;
            view.edit_book_clicked += on_edit_book_clicked;
            view.delete_book_clicked += on_delete_book_clicked;
            view.open_clicked += on_open_clicked;
            view.save_clicked += on_save_clicked;
            view.exit_clicked += on_exit_clicked;
        }

        public void initialize()
        {
            update_authors();
            update_books();
        }

        private void update_authors()
        {
            var authors = model.get_authors();
            view.update_authors(authors);
        }

        private void update_books()
        {
            if (view.is_filter_enabled && !string.IsNullOrEmpty(view.selected_author))
            {
                var books = model.get_books_by_author(view.selected_author);
                view.update_books(books);
            }
            else
            {
                var all_books = model.get_all_books();
                view.update_books(all_books);
            }
        }

        private void on_author_selected(object sender, EventArgs e)
        {
            update_books();
        }

        private void on_filter_changed(object sender, EventArgs e)
        {
            update_books();
        }

        private void on_add_author_clicked(object sender, EventArgs e)
        {
            var name = view.show_input_dialog("Enter author's name:", "Add Author");
            if (!string.IsNullOrWhiteSpace(name))
            {
                model.add_author(name);
                update_authors();
                update_books();
                view.show_message("Author added successfully.");
            }
        }

        private void on_edit_author_clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.selected_author))
            {
                var new_name = view.show_input_dialog("Enter new author's name:", "Edit Author");
                if (!string.IsNullOrWhiteSpace(new_name))
                {
                    model.edit_author(view.selected_author, new_name);
                    update_authors();
                    update_books();
                    view.show_message("Author updated successfully.");
                }
            }
            else
            {
                view.show_message("Please select an author to edit.", "Error");
            }
        }

        private void on_delete_author_clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.selected_author))
            {
                var result = view.show_confirm($"Are you sure you want to delete author '{view.selected_author}' and all their books?", "Confirm Delete");
                if (result)
                {
                    model.delete_author(view.selected_author);
                    update_authors();
                    update_books();
                    view.show_message("Author deleted successfully.");
                }
            }
            else
            {
                view.show_message("Please select an author to delete.", "Error");
            }
        }

        private void on_add_book_clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.selected_author))
            {
                var book_title = view.show_input_dialog("Enter book title:", "Add Book");
                if (!string.IsNullOrWhiteSpace(book_title))
                {
                    model.add_book(view.selected_author, book_title);
                    update_books();
                    view.show_message("Book added successfully.");
                }
            }
            else
            {
                view.show_message("Please select an author first.", "Error");
            }
        }

        private void on_edit_book_clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.selected_author) && !string.IsNullOrEmpty(view.selected_book))
            {
                var new_title = view.show_input_dialog("Enter new book title:", "Edit Book");
                if (!string.IsNullOrWhiteSpace(new_title))
                {
                    model.edit_book(view.selected_author, view.selected_book, new_title);
                    update_books();
                    view.show_message("Book updated successfully.");
                }
            }
            else
            {
                view.show_message("Please select a book to edit.", "Error");
            }
        }

        private void on_delete_book_clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(view.selected_author) && !string.IsNullOrEmpty(view.selected_book))
            {
                var result = view.show_confirm($"Are you sure you want to delete book '{view.selected_book}'?", "Confirm Delete");
                if (result)
                {
                    model.delete_book(view.selected_author, view.selected_book);
                    update_books();
                    view.show_message("Book deleted successfully.");
                }
            }
            else
            {
                view.show_message("Please select a book to delete.", "Error");
            }
        }

        private void on_open_clicked(object sender, EventArgs e)
        {
            var open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                model.set_file_path(open_file_dialog.FileName);
                update_authors();
                update_books();
                view.show_message("Data loaded successfully.");
            }
        }

        private void on_save_clicked(object sender, EventArgs e)
        {
            var save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                model.set_file_path(save_file_dialog.FileName);
                model.save_data();
                view.show_message("Data saved successfully.");
            }
        }

        private void on_exit_clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
