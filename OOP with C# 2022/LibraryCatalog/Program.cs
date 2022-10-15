using System;

namespace LibraryCatalog
{
    class MainClass
    {
        public static void Main()
        {
            int command;
            UserProfile user;

            do
            {
                Console.WriteLine("(0)Exit  (1)User  ");
                try
                {
                    command = int.Parse(Console.ReadLine());
                } catch (Exception ex)
                {
                    command = -1;
                    Console.WriteLine("Invalid input!");
                }

                Console.WriteLine();

                switch (command)
                {
                    case 0: Console.WriteLine("Bye!"); break;
                    case 1:
                        Console.WriteLine("(0)Enter as a user   (1)Create a user   (2)Delete a user");
                        try
                        {
                            command = int.Parse(Console.ReadLine());
                        }catch(Exception ex)
                        {
                            command = -1;
                            Console.WriteLine("Invalid input!");
                        }

                        switch (command)
                        {
                            case 0: 
                                user = User.EnterAsUser();

                                do
                                {
                                    Console.WriteLine("(0)Exit (1)AddBook (2)DeleteBook (3)CheckMyBooks (4)CheckOthersBooks");
                                    try
                                    {
                                        command = int.Parse(Console.ReadLine());
                                    }catch (Exception ex)
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }

                                    switch (command)
                                    {
                                        case 0: Console.WriteLine("U are logged out");break;
                                        case 1:
                                            Console.Write("How many books u want to add? ");
                                            try
                                            {
                                                command = int.Parse(Console.ReadLine());
                                            } catch( Exception ex) { }

                                            for (int i = 0; i < command; i++)
                                            {
                                                Console.Write("Book name: ");
                                                string name = Console.ReadLine();
                                                Console.Write("Author: ");
                                                string author = Console.ReadLine();
                                                Book book = new Book(name, author);
                                                user.AddBook(book);
                                            }
                                           
                                            break;
                                        case 2:
                                            Console.Write("Book name: ");
                                            string nameToDelete = Console.ReadLine();
                                            Console.Write("Author: ");
                                            string authorToDelete = Console.ReadLine();
                                            Book bookToDelete = new Book(nameToDelete, authorToDelete);
                                            user.DeleteBook(bookToDelete);
                                            break;
                                        case 3:
                                            user.CheckBooks();
                                            break;
                                        case 4:
                                            user.CheckOthersBooks();
                                            break;
                                    }

                                } while (command != 0);

                                break;
                            case 1: User.CreateUser(); break;
                            case 2: User.DeleteUser(); break;
                            default: Console.WriteLine("Invalid input!"); break;
                        }

                        command = -1;
                        break;
                    default: Console.WriteLine("Invalid command!"); break;
                }

                Console.WriteLine();

            } while (command != 0);
        }
    }
}
