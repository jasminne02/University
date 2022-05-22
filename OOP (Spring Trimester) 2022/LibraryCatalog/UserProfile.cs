using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog
{
    class UserProfile
    {
        private string name;
        private List<Book> books = new List<Book>();

        public string Name { get { return name; } }
        public List<Book> Books { get { return books; } }

        public UserProfile(string name)
        {
            this.name = name;
        }

        public void CheckBooks()
        {
            for(int i = 0; i < books.Count; i++)
            {
                if(i == books.Count-1)
                {
                    Console.Write(books[i].Name + " by " + books[i].Author);
                }
                else
                {
                    Console.Write(books[i].Name + " by " + books[i].Author + " , ");
                }
            }

            Console.WriteLine();
        }

        public void CheckOthersBooks()
        {
            Console.Write("Users : ");
            foreach (UserProfile u in User.UserProfiles)
            {
                if(u.Name != name)
                {
                    Console.Write(u.Name + " ");
                }
            }
            Console.Write("Chose a user: ");
            string user = Console.ReadLine();

            foreach(UserProfile u in User.UserProfiles)
            {
                if(u.Name == user)
                {
                    foreach(Book b in u.Books)
                    {
                        Console.WriteLine(b.Name + " by " + b.Author);
                    }
                }
            }
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }
    }
}
