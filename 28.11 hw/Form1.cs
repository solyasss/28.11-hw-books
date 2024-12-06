using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace authors_and_books
{
    public partial class form1 : Form, i_view
    {
        public event EventHandler author_selected = delegate { };
        public event EventHandler filter_changed = delegate { };
        public event EventHandler add_author_clicked = delegate { };
        public event EventHandler edit_author_clicked = delegate { };
        public event EventHandler delete_author_clicked = delegate { };
        public event EventHandler add_book_clicked = delegate { };
        public event EventHandler edit_book_clicked = delegate { };
        public event EventHandler delete_book_clicked = delegate { };
        public event EventHandler open_clicked = delegate { };
        public event EventHandler save_clicked = delegate { };
        public event EventHandler exit_clicked = delegate { };

        private presenter presenter;

        public form1()
        {
            InitializeComponent();
            combo_authors.SelectedIndexChanged += (s, e) => author_selected(this, EventArgs.Empty);
            checkbox_filter.CheckedChanged += (s, e) => filter_changed(this, EventArgs.Empty);

            menu_add_author.Click += (s, e) => add_author_clicked(this, EventArgs.Empty);
            menu_edit_author.Click += (s, e) => edit_author_clicked(this, EventArgs.Empty);
            menu_delete_author.Click += (s, e) => delete_author_clicked(this, EventArgs.Empty);
            menu_add_book.Click += (s, e) => add_book_clicked(this, EventArgs.Empty);
            menu_edit_book.Click += (s, e) => edit_book_clicked(this, EventArgs.Empty);
            menu_delete_book.Click += (s, e) => delete_book_clicked(this, EventArgs.Empty);
            menu_open.Click += (s, e) => open_clicked(this, EventArgs.Empty);
            menu_save.Click += (s, e) => save_clicked(this, EventArgs.Empty);
            menu_exit.Click += (s, e) => exit_clicked(this, EventArgs.Empty);

            presenter = new presenter(this);
            presenter.initialize();
        }

        public void update_authors(List<string> authors)
        {
            combo_authors.Items.Clear();
            combo_authors.Items.AddRange(authors.ToArray());
        }

        public void update_books(List<string> books)
        {
            list_books.Items.Clear();
            list_books.Items.AddRange(books.ToArray());
        }

        public string selected_author
        {
            get { return combo_authors.SelectedItem?.ToString(); }
        }

        public string selected_book
        {
            get { return list_books.SelectedItem?.ToString(); }
        }

        public bool is_filter_enabled
        {
            get { return checkbox_filter.Checked; }
        }

        public void show_message(string message, string caption = "Info")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool show_confirm(string message, string caption)
        {
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        
            public string show_input_dialog(string text, string caption)
            {
                using (Form prompt = new Form())
                {
                    prompt.Width = 500;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = caption;
                    prompt.StartPosition = FormStartPosition.CenterScreen;

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
    }

