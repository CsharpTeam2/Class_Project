using System;
namespace Library_Project
{
 
    enum Type {Adult, Child, Dvd, Videotape}
    
    public class Book
    {
        int bookID;
        string authorLastName;
        string authorFirstName;
        string title;
        string callNum;
        int mediaType;
        int userID;
        DateTime dueDate;

        public Book(int book_ID, string authLastName, string authFirstName, string _Title, string callNumber, int medType)
        {
            bookID = book_ID;
            authorLastName = authLastName;
            authorFirstName = authFirstName;
            title = _Title;
            callNum = callNumber;
            mediaType = medType;
        }//end constructor

        public void checkIn()
        {
            if (isCheckedOut())
            {
                userID = -1;
                dueDate = DateTime.MinValue;
            }
        }//end checkIn

        public DateTime checkOut (int user_ID, DateTime today)
        {
            int days = 0; //days until due date
            userID = user_ID;
            switch (mediaType)
            {
                case (int)Type.Adult:
                    days = 14;
                    break;
                case (int)Type.Child:
                    days =7;
                    break;
                case (int)Type.Dvd:
                    days = 2;
                    break;
                case (int)Type.Videotape:
                    days = 3;
                    break;
            }//end switch
            dueDate = today.AddDays(days);
            return dueDate;
        }//end checkOut

        public bool isCheckedOut()
        {
            if (userID == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//end isCheckedOut

        public bool isOverDue(DateTime today)
        {
            if(isCheckedOut() && dueDate < today)   //if the book is checked out and if we've passed the due date then it is overdue
            {
                return true;
            }
            else                                    //if not then it's not overdue
            {
                return false;
            }
        }//end isOverDue

        public int getBookID()
        {
            return bookID;
        }//end getBookID

        public int getUserID()
        {
            return userID;
        }//end getUserID;

        public int getMediaType()
        {
            return mediaType;
        }//end getMediaType

        public override string ToString()
        {
            if (isCheckedOut())
            {
                return (String.Format("{0} {1}, {2} {3} {4} Status: Checked Out {5} {6}\n", bookID, authorLastName, authorFirstName, title, callNum, userID, dueDate));
            }
            else
            {
                return (String.Format("{0} {1}, {2} {3} {4}; Status: Checked In\n", bookID, authorLastName, authorFirstName, title, callNum));
            }
        }// end print override
    }//end Book class

    public class User
    {
        int userID;
        string lastName;
        string firstName;
        int userType;
        int items;
        Book[] books = new Book[6];

        public User(int uID, string lName, string fName, int uType)
        {
            userID = uID;
            lastName = lName;
            firstName = fName;
            userType = uType;
            items = 0;
        }//end constructor

        public bool isChild()
        {
            if (userType == (int)Type.Child)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end isChild

        public int getItemCount()
        {
            return items;
        }//end getItemCount

        public void addBook(Book book)
        {
            books[items] = book;
            items++;
        }//end addBook

        public void removeBook(int bookID)
        {
            bool found = false;
            for (int index = 0; index < items; index++)
            {
                if (!found)//if we haven't located the book in the array then keep looking for it
                {
                    if (bookID == books[index].getBookID())
                    {
                        found = true;
                        if (index < items - 1) //if its not the last book in the list we want to move the books after it up a space, so this starts the process
                        {
                            books[index] = books[index + 1];
                        }
                        else//if it's the last one in the list we'll just set it to null
                        {
                            books[index] = null;
                        }
                    }
                }
                else
                {
                    if (index < items - 1) //if its not the last book in the list we want to move the books after it up a space
                    {
                        books[index] = books[index + 1];
                    }
                    else//if it's the last one in the list we'll just set it to null
                    {
                        books[index] = null;
                    }
                }
            }//end for loop
            if (!found)
            {
                //write message book not found***
            }
            else
            {
                items--;
            }
        }//end removeBook
        public string[] listBooks()
        {
            string[] str = new string[items];
            if (items == 0)
            {
                str[0] ="No books currently checked out"; 
                return str;
            }
            else
            {
                for (int index = 0; index < items; index++)
                {
                    str[index] = books[index].ToString();
                }
                return str;
            }
        }//end listBooks

        public override string ToString()
        {
            return (String.Format("{0} {1}, {2} {3} {4}", userID, lastName, firstName, userType, items) + listBooks());
        }//end ToString overrider

        public int getUserID()
        {
            return userID;
        }//end getUserID

        public int getUserType()
        {
            return userType;
        }//end getType
     }//end user class

    public class Library
    {
        const int CHILD_MAX = 3;
        const int ADULT_MAX = 6;
        const int ARRAY_MAX = 100;
        Book[] books;
        User[] users;
        DateTime today;
        User currentUser;
        int bookCap;
        int userCap;

        public Library()
        {
            books = new Book[ARRAY_MAX];
            users = new User[ARRAY_MAX];
            today = DateTime.Now;
            bookCap = 0;
            userCap = 0;
        }//end constructor

       
        public void checkIn(int bookID)
        {
            bool found = false;
            for (int index = 0; index < bookCap; index++)
            {
                if (bookID == books[index].getBookID()) //if we find the book ID in the list of books then check it in
                {
                    found = true;
                    if (books[index].isCheckedOut()) //if the book is checked out then checkit back in
                    {
                        for (int userIndex = 0; userIndex < userCap; userIndex++)//find the user that has the book
                        {
                            if (books[index].getUserID() == users[userIndex].getUserID())
                            {
                                users[userIndex].removeBook(bookID); //remove book from users list
                                break;
                            }
                        }
                        books[index].checkIn();
                    }//end if checked out
                    else//if it's not checked out then relay message that it is not checked out
                    {
                        //***
                    }//end else
                    break;
                }//end if 
            }//end for loop
            if (!found) //if we went through the list and didn't find the bookID then it's not in our system, and not checked in
            {
                //print message that not found***
            }
        }//end checkIn

        public DateTime checkOut(int bookID, int userID)
        {
            int bookIndex = 0;
            int userIndex = 0;
            bool bookFound = false;
            bool userFound = false;
            for (int b = 0; b < bookCap; b++)
            {
                if (bookID == books[b].getBookID())
                {
                    bookIndex = b;
                    bookFound = true;
                    break;//if found break and keep the index
                }
            }//end book for loop
            if (!bookFound)
            {
                //write message book not found***
                return today;
            }//end if book not found
            if (books[bookIndex].isCheckedOut())
            {
                //write message book checked out already***
                return today;
            }//end is checked out test
            for (int u = 0; u < userCap; u++)
            {
                if (userID == users[u].getUserID())
                {
                    userFound = true;
                    break;//if found break and keep the index
                }
            }//end book for loop
            if (!userFound)
            {
                //write message user not found***
                return today;
            }//end user not found
            if (users[userIndex].getUserType() == (int)Type.Child && books[bookIndex].getMediaType() != (int)Type.Child) //if the patron is a child and the book is not a children's book they can't check it out
            {
                //write message that user is a child and this is not a children's book***
                return today;
            }//end child checking out non-children's media test
            if (users[userIndex].getUserType() == (int)Type.Child && users[userIndex].getItemCount() >= CHILD_MAX)
            {
                //write message that user has reached check out limit***
                return today;
            }//end child max test
            if (users[userIndex].getItemCount() >= ADULT_MAX)
            {
                //write message that user has reached check out limit ***
                return today;
            }//end adult max test

            //if all checks pass then we can check out the book
            users[userIndex].addBook(books[bookIndex]);
            return books[bookIndex].checkOut(userID, today);
        }//end checkOut

        public void incrementDate()
        {
            today = today.AddDays(1);
        }//end incrementDate

        public string[] listAllBooks()
        {
            string[] str = new string[bookCap]; 
            //str[0]= bookCap.ToString();
            for(int b = 0; b < bookCap; b++)
            {
                str[b] = books[b].ToString();
            }//end for loop
            return str;
        }//end listAllBooks

        public string[] listOverdueBooks() 
        {
            string[] str = new string[bookCap];
            for (int b = 0; b < bookCap; b++)
            {
                if (books[b].isOverDue(today))
                {
                    str[b] = books[b].ToString();
                }
            }//end for loop
            return str;
        }//end listOverdueBooks
        public string[] listPatrons()
        {
             string[] str = new string[userCap]; 
            //str[0]= bookCap.ToString();
            for(int b = 0; b < userCap; b++)
            {
                str[b] = users[b].ToString();
            }//end for loop
            return str;
        }//end listPartons
      
        public string[] listPatronBooks(int userID)
        {
            bool found = false;
            int uIndex = 0;
            string[] str = new string[ADULT_MAX];
            for (int u = 0; u < userCap; u++)
            {
                if(users[u].getUserID() == userID)
                {
                    uIndex = u;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                return users[uIndex].listBooks();
            }// if found print out the users books
            else
            {
                str[0] = "Patron not found";
                return str;
            }//if not found return string saying it wasn't found
            
        }//end listPatronBooks

        public void addBook(Book newBook)
        {
            books[bookCap] = newBook;
            bookCap++;
        }//end addbook

        public void removeBook(int bookID)
        {
            bool found = false;
            for (int index = 0; index < bookCap; index++)
            {
                if (!found)//if we haven't located the book in the array then keep looking for it
                {
                    if (bookID == books[index].getBookID())
                    {
                        found = true;
                        if (index < bookCap - 1) //if its not the last book in the list we want to move the books after it up a space, so this starts the process
                        {
                            books[index] = books[index + 1];
                        }
                        else//if it's the last one in the list we'll just set it to null
                        {
                            books[index] = null;
                        }
                    }
                }
                else
                {
                    if (index < bookCap - 1) //if its not the last book in the list we want to move the books after it up a space
                    {
                        books[index] = books[index + 1];
                    }
                    else//if it's the last one in the list we'll just set it to null
                    {
                        books[index] = null;
                    }
                }
            }//end for loop
            if (!found)
            {
                //write message book not found***
            }
            else
            {
                bookCap--;
            }
        }//end removeBook

        public void addUser(User newUser)
        {
            users[userCap] = newUser;
            userCap++;
        }//end addUser

        public void removeUser(int userID)
        {
            bool found = false;
            for (int index = 0; index < userCap; index++)
            {
                if (!found)//if we haven't located the user in the array then keep looking for it
                {
                    if (userID == users[index].getUserID())
                    {
                        found = true;
                        if (index < userCap - 1) //if its not the last user in the list we want to move the users after it up a space, so this starts the process
                        {
                            users[index] = users[index + 1];
                        }
                        else//if it's the last one in the list we'll just set it to null
                        {
                            users[index] = null;
                        }
                    }
                }
                else
                {
                    if (index < userCap - 1) //if its not the last user in the list we want to move the users after it up a space
                    {
                        users[index] = users[index + 1];
                    }
                    else//if it's the last one in the list we'll just set it to null
                    {
                        users[index] = null;
                    }
                }
            }//end for loop
            if (!found)
            {
                //write message user not found***
            }
            else
            {
                userCap--;
            }
        }//end remove user

        public void quit()
        {

        }//end quit

        public void advanceToDate(DateTime date)
        {
            today = date;
        }//end advanceToDate
    }
}//end namespace Library