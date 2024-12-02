using System.Windows.Forms;

namespace authors_and_books
{
    partial class form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            combo_authors = new ComboBox();
            list_books = new ListBox();
            checkbox_filter = new CheckBox();
            menu_strip = new MenuStrip();
            file_menu = new ToolStripMenuItem();
            menu_open = new ToolStripMenuItem();
            menu_save = new ToolStripMenuItem();
            menu_exit = new ToolStripMenuItem();
            options_menu = new ToolStripMenuItem();
            menu_add_author = new ToolStripMenuItem();
            menu_edit_author = new ToolStripMenuItem();
            menu_delete_author = new ToolStripMenuItem();
            menu_add_book = new ToolStripMenuItem();
            menu_edit_book = new ToolStripMenuItem();
            menu_delete_book = new ToolStripMenuItem();
            menu_strip.SuspendLayout();
            SuspendLayout();
            // 
            // combo_authors
            // 
            combo_authors.FormattingEnabled = true;
            combo_authors.Location = new Point(20, 50);
            combo_authors.Name = "combo_authors";
            combo_authors.Size = new Size(400, 28);
            combo_authors.TabIndex = 0;
            combo_authors.SelectedIndexChanged += combo_authors_SelectedIndexChanged;
            // 
            // list_books
            // 
            list_books.FormattingEnabled = true;
            list_books.Location = new Point(20, 100);
            list_books.Name = "list_books";
            list_books.Size = new Size(400, 184);
            list_books.TabIndex = 1;
            // 
            // checkbox_filter
            // 
            checkbox_filter.AutoSize = true;
            checkbox_filter.Location = new Point(20, 320);
            checkbox_filter.Name = "checkbox_filter";
            checkbox_filter.Size = new Size(64, 24);
            checkbox_filter.TabIndex = 2;
            checkbox_filter.Text = "Filter";
            checkbox_filter.UseVisualStyleBackColor = true;
            checkbox_filter.CheckedChanged += checkbox_filter_CheckedChanged;
            // 
            // menu_strip
            // 
            menu_strip.ImageScalingSize = new Size(20, 20);
            menu_strip.Items.AddRange(new ToolStripItem[] { file_menu, options_menu });
            menu_strip.Location = new Point(0, 0);
            menu_strip.Name = "menu_strip";
            menu_strip.Size = new Size(800, 28);
            menu_strip.TabIndex = 3;
            menu_strip.Text = "menu_strip";
            // 
            // file_menu
            // 
            file_menu.DropDownItems.AddRange(new ToolStripItem[] { menu_open, menu_save, menu_exit });
            file_menu.Name = "file_menu";
            file_menu.Size = new Size(46, 24);
            file_menu.Text = "File";
            // 
            // menu_open
            // 
            menu_open.Name = "menu_open";
            menu_open.Size = new Size(128, 26);
            menu_open.Text = "Open";
            menu_open.Click += menu_open_Click;
            // 
            // menu_save
            // 
            menu_save.Name = "menu_save";
            menu_save.Size = new Size(128, 26);
            menu_save.Text = "Save";
            menu_save.Click += menu_save_Click;
            // 
            // menu_exit
            // 
            menu_exit.Name = "menu_exit";
            menu_exit.Size = new Size(128, 26);
            menu_exit.Text = "Exit";
            menu_exit.Click += menu_exit_Click;
            // 
            // options_menu
            // 
            options_menu.DropDownItems.AddRange(new ToolStripItem[] { menu_add_author, menu_edit_author, menu_delete_author, menu_add_book, menu_edit_book, menu_delete_book });
            options_menu.Name = "options_menu";
            options_menu.Size = new Size(75, 24);
            options_menu.Text = "Options";
            // 
            // menu_add_author
            // 
            menu_add_author.Name = "menu_add_author";
            menu_add_author.Size = new Size(224, 26);
            menu_add_author.Text = "Add Author";
            menu_add_author.Click += menu_add_author_Click;
            // 
            // menu_edit_author
            // 
            menu_edit_author.Name = "menu_edit_author";
            menu_edit_author.Size = new Size(224, 26);
            menu_edit_author.Text = "Edit Author";
            menu_edit_author.Click += menu_edit_author_Click;
            // 
            // menu_delete_author
            // 
            menu_delete_author.Name = "menu_delete_author";
            menu_delete_author.Size = new Size(224, 26);
            menu_delete_author.Text = "Delete Author";
            menu_delete_author.Click += menu_delete_author_Click;
            // 
            // menu_add_book
            // 
            menu_add_book.Name = "menu_add_book";
            menu_add_book.Size = new Size(224, 26);
            menu_add_book.Text = "Add Book";
            menu_add_book.Click += menu_add_book_Click;
            // 
            // menu_edit_book
            // 
            menu_edit_book.Name = "menu_edit_book";
            menu_edit_book.Size = new Size(224, 26);
            menu_edit_book.Text = "Edit Book";
            menu_edit_book.Click += menu_edit_book_Click;
            // 
            // menu_delete_book
            // 
            menu_delete_book.Name = "menu_delete_book";
            menu_delete_book.Size = new Size(224, 26);
            menu_delete_book.Text = "Delete Book";
            menu_delete_book.Click += menu_delete_book_Click;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkbox_filter);
            Controls.Add(list_books);
            Controls.Add(combo_authors);
            Controls.Add(menu_strip);
            MainMenuStrip = menu_strip;
            MaximizeBox = false;
            Name = "form1";
            Text = "Authors and Books";
            menu_strip.ResumeLayout(false);
            menu_strip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox combo_authors;
        private ListBox list_books;
        private CheckBox checkbox_filter;
        private MenuStrip menu_strip;
        private ToolStripMenuItem file_menu;
        private ToolStripMenuItem menu_open;
        private ToolStripMenuItem menu_save;
        private ToolStripMenuItem menu_exit;
        private ToolStripMenuItem options_menu;
        private ToolStripMenuItem menu_add_author;
        private ToolStripMenuItem menu_edit_author;
        private ToolStripMenuItem menu_delete_author;
        private ToolStripMenuItem menu_add_book;
        private ToolStripMenuItem menu_edit_book;
        private ToolStripMenuItem menu_delete_book;
    }
}
