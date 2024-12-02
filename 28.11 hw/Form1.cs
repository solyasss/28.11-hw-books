using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace authors_and_books
{
    public partial class form1 : Form
    {
        private XElement xml_data; 
        private string file_path = "data.xml"; 

        public form1()
        {
            InitializeComponent();
            load_data();
            update_authors();
            update_books();
        }

        private void load_data()
        {
            try
            {
                xml_data = XElement.Load(file_path);
            }
            catch
            {
                xml_data = new XElement("catalog"); 
            }
        }

        private void save_data()
        {
            xml_data.Save(file_path);
        }

        private void update_authors()
        {
            combo_authors.Items.Clear();
            if (xml_data != null)
            {
                var authors = xml_data.Elements("author")
                    .Select(a => a.Attribute("name")?.Value)
                    .Where(name => name != null)
                    .ToList();
                combo_authors.Items.AddRange(authors.ToArray());
            }
        }

        private void update_books()
        {
            list_books.Items.Clear();
            if (xml_data != null)
            {
                if (checkbox_filter.Checked && combo_authors.SelectedItem != null)
                {
                    var selected_author = combo_authors.SelectedItem.ToString();
                    var books = xml_data.Elements("author")
                        .Where(a => a.Attribute("name")?.Value == selected_author)
                        .Elements("book")
                        .Select(b => b.Value)
                        .ToList();
                    list_books.Items.AddRange(books.ToArray());
                }
                else if (!checkbox_filter.Checked)
                {
                    var books = xml_data.Elements("author")
                        .Elements("book")
                        .Select(b => b.Value)
                        .ToList();
                    list_books.Items.AddRange(books.ToArray());
                }
            }
        }

        private void menu_add_author_Click(object sender, EventArgs e)
        {
            var name = win.ShowDialog("Enter author's name:", "Add Author");
            if (!string.IsNullOrWhiteSpace(name))
            {
                xml_data.Add(new XElement("author", new XAttribute("name", name)));
                save_data();
                update_authors();
                update_books();
                MessageBox.Show("Author added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_delete_author_Click(object sender, EventArgs e)
        {
            if (combo_authors.SelectedItem != null && xml_data != null)
            {
                var selected_author = combo_authors.SelectedItem.ToString();
                var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == selected_author);
                if (author != null)
                {
                    var result = MessageBox.Show($"Are you sure you want to delete author '{selected_author}' and all their books?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        author.Remove();
                        save_data();
                        update_authors();
                        update_books();
                        MessageBox.Show("Author deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an author to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_edit_author_Click(object sender, EventArgs e)
        {
            if (combo_authors.SelectedItem != null && xml_data != null)
            {
                var selected_author = combo_authors.SelectedItem.ToString();
                var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == selected_author);
                if (author != null)
                {
                    var new_name = win.ShowDialog("Enter new author's name:", "Edit Author");
                    if (!string.IsNullOrWhiteSpace(new_name))
                    {
                        author.SetAttributeValue("name", new_name);
                        save_data();
                        update_authors();
                        update_books();
                        MessageBox.Show("Author updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an author to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_add_book_Click(object sender, EventArgs e)
        {
            if (combo_authors.SelectedItem != null && xml_data != null)
            {
                var selected_author = combo_authors.SelectedItem.ToString();
                var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == selected_author);
                if (author != null)
                {
                    var book_title = win.ShowDialog("Enter book title:", "Add Book");
                    if (!string.IsNullOrWhiteSpace(book_title))
                    {
                        author.Add(new XElement("book", book_title));
                        save_data();
                        update_books();
                        MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an author first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_delete_book_Click(object sender, EventArgs e)
        {
            if (list_books.SelectedItem != null && combo_authors.SelectedItem != null && xml_data != null)
            {
                var selected_author = combo_authors.SelectedItem.ToString();
                var selected_book = list_books.SelectedItem.ToString();
                var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == selected_author);
                if (author != null)
                {
                    var book = author.Elements("book").FirstOrDefault(b => b.Value == selected_book);
                    if (book != null)
                    {
                        var result = MessageBox.Show($"Are you sure you want to delete book '{selected_book}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            book.Remove();
                            save_data();
                            update_books();
                            MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_edit_book_Click(object sender, EventArgs e)
        {
            if (list_books.SelectedItem != null && combo_authors.SelectedItem != null && xml_data != null)
            {
                var selected_author = combo_authors.SelectedItem.ToString();
                var selected_book = list_books.SelectedItem.ToString();
                var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == selected_author);
                if (author != null)
                {
                    var book = author.Elements("book").FirstOrDefault(b => b.Value == selected_book);
                    if (book != null)
                    {
                        var new_title = win.ShowDialog("Enter new book title:", "Edit Book");
                        if (!string.IsNullOrWhiteSpace(new_title))
                        {
                            book.Value = new_title;
                            save_data();
                            update_books();
                            MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu_open_Click(object sender, EventArgs e)
        {
            var open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                file_path = open_file_dialog.FileName;
                load_data();
                update_authors();
                update_books();
                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_save_Click(object sender, EventArgs e)
        {
            var save_file_dialog = new SaveFileDialog();
            save_file_dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                file_path = save_file_dialog.FileName;
                save_data();
                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void combo_authors_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_books();
        }

        private void checkbox_filter_CheckedChanged(object sender, EventArgs e)
        {
            update_books();
        }
    }

    public static class win
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label text_label = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox text_box = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(text_label);
            prompt.Controls.Add(text_box);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? text_box.Text : "";
        }
    }
}
