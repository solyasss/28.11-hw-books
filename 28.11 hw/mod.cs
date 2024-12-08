using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace hw
{
    public class mod : i_model
    {
        private XElement xml_data;
        private string file_path = "data.xml";

        public mod()
        {
            load_data();
        }

        public void set_file_path(string path)
        {
            file_path = path;
            load_data();
        }

        public void load_data()
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

        public void save_data()
        {
            xml_data.Save(file_path);
        }

        public List<string> get_authors()
        {
            return xml_data.Elements("author")
                .Select(a => a.Attribute("name")?.Value)
                .Where(name => !string.IsNullOrEmpty(name))
                .ToList();
        }

        public List<string> get_books_by_author(string author_name)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == author_name);
            if (author != null)
            {
                return author.Elements("book").Select(b => b.Value).ToList();
            }
            return new List<string>();
        }

        public List<string> get_all_books()
        {
            return xml_data.Elements("author").Elements("book").Select(b => b.Value).ToList();
        }

        public void add_author(string name)
        {
            xml_data.Add(new XElement("author", new XAttribute("name", name)));
            save_data();
        }

        public void delete_author(string name)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == name);
            if (author != null)
            {
                author.Remove();
                save_data();
            }
        }

        public void edit_author(string old_name, string new_name)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == old_name);
            if (author != null)
            {
                author.SetAttributeValue("name", new_name);
                save_data();
            }
        }

        public void add_book(string author_name, string book_title)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == author_name);
            if (author != null)
            {
                author.Add(new XElement("book", book_title));
                save_data();
            }
        }

        public void delete_book(string author_name, string book_title)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == author_name);
            if (author != null)
            {
                var book = author.Elements("book").FirstOrDefault(b => b.Value == book_title);
                if (book != null)
                {
                    book.Remove();
                    save_data();
                }
            }
        }

        public void edit_book(string author_name, string old_title, string new_title)
        {
            var author = xml_data.Elements("author").FirstOrDefault(a => a.Attribute("name")?.Value == author_name);
            if (author != null)
            {
                var book = author.Elements("book").FirstOrDefault(b => b.Value == old_title);
                if (book != null)
                {
                    book.Value = new_title;
                    save_data();
                }
            }
        }
    }
}
