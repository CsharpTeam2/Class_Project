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
            userID = -1;
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
        public DateTime getDueDate()
        {
            return dueDate;
        }
        public string getFirstName()
        {
            return authorFirstName;
        }
        public string getLastName()
        {
            return authorLastName;
        }
        public string getTitle()
        {
            return title;
        }
        public string getCall()
        {
            return callNum;
        }

        public override string ToString()
        {
            string type = null;
            switch (mediaType)
            {
                case 0:
                    type = "Adult";
                    break;
                case 1:
                    type = "Childrens";
                    break;
                case 2:
                    type = "DVD";
                    break;
                case 3:
                    type = "Videotape";
                    break;
            }
            if (isCheckedOut())
            {
                return (String.Format("{0} {1}, {2} {3} {4} {5} Status: Checked Out {6} {7}\n", bookID, authorLastName, authorFirstName, title, callNum, type, userID, dueDate));
            }
            else
            {
                return (String.Format("{0} {1}, {2} {3} {4} {5} Status: Checked In\n", bookID, authorLastName, authorFirstName, title, callNum, type));
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
                string[] strtemp = new string[1];
                strtemp[0] ="No books currently checked out"; 
                return strtemp;
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
            if(isChild())
            return (String.Format("{0} {1}, {2} {3}", userID, lastName, firstName, "CHILD", items));
            else
            return (String.Format("{0} {1}, {2} {3}", userID, lastName, firstName, "ADULT", items));
        }//end ToString overrider

        public int getUserID()
        {
            return userID;
        }//end getUserID

        public int getUserType()
        {
            return userType;
        }//end getType
        public string getUserLastName()
        {
            return lastName;
        }
        public string getUserFirstName()
        {
            return firstName;
        }
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

        public DateTime getToday()
        {
            return today;
        }
        public string checkIn(int bookID)
        {
            string name;
            name = "";
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
                                name = users[userIndex].getUserLastName();
                                users[userIndex].removeBook(bookID); //remove book from users list
                                break;
                            }
                        }
                        books[index].checkIn();
                        return "Checked In, From User:" + name;
                    }//end if checked out
                    else//if it's not checked out then relay message that it is not checked out
                    {
                        return "Book Never Checked Out";
                    }//end else
                    break;
                }//end if 
            }//end for loop
            if (!found) //if we went through the list and didn't find the bookID then it's not in our system, and not checked in
            {
                return "Book does not belong to library";
            }
            return "Book Error";
        }//end checkIn

        public string checkOut(int bookID, int userID, DateTime date)
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
                return "Book Not Found";
            }//end if book not found
            if (books[bookIndex].isCheckedOut())
            {
                //write message book checked out already***
                return "Book Already Checked Out";
            }//end is checked out test
            for (int u = 0; u < userCap; u++)
            {
                if (userID == users[u].getUserID())
                {
                    userFound = true;
                    userIndex = u;
                    break;//if found break and keep the index
                }
            }//end book for loop
            if (!userFound)
            {
                //write message user not found***
                return "User Not Found";
            }//end user not found
            if (users[userIndex].getUserType() == (int)Type.Child && books[bookIndex].getMediaType() != (int)Type.Child) //if the patron is a child and the book is not a children's book they can't check it out
            {
                //write message that user is a child and this is not a children's book***
                return "User Is a child, this book is not a childrens book";
            }//end child checking out non-children's media test
            if (users[userIndex].getUserType() == (int)Type.Child && users[userIndex].getItemCount() >= CHILD_MAX)
            {
                //write message that user has reached check out limit***
                return "User has reached max allowed books";
            }//end child max test
            if (users[userIndex].getItemCount() >= ADULT_MAX)
            {
                //write message that user has reached check out limit ***
                return "User has reached max allowed books";
            }//end adult max test

            //if all checks pass then we can check out the book
            users[userIndex].addBook(books[bookIndex]);
            return "Book checked out, you have until: "+books[bookIndex].checkOut(userID, date).ToString()+" to return";
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
            int i=0;
            string[] str = new string[bookCap];
            for (int b = 0; b < bookCap; b++)
            {
                if (books[b].isOverDue(today))
                {
                    str[i] = books[b].ToString();
                    i++;
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
            }//end for loop
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
        /// <summary>
        /// Function checks to see if there is a duplicate in the system, if there is it returns error, else creates a new book object and returns success message
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="title"></param>
        /// <param name="callNumber"></param>
        /// <param name="medType"></param>
        /// <returns></returns>
        public string addBook(int bookID, string lastName, string firstName, string title, string callNumber, int medType)
        {
            for (int index = 0; index < bookCap; index++)
            {
                if (bookID == books[index].getBookID())
                {
                    return "Book ID already in use, please pick another";
                }
            }
            Book newBook = new Book(bookID, lastName,firstName,title,callNumber,medType);    
            books[bookCap] = newBook;
            bookCap++;
            return "Book Added";
            
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
        /// <summary>
        /// Function checks to see if there is a duplicate in the system, if there is it returns error, else creates a new user object and returns success message
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="uType"></param>
        /// <returns></returns>
        public string addUser(int userID, string lastName, string firstName, int uType)
        {
            for (int index = 0; index < userCap; index++)
            {
                if (userID == users[index].getUserID())
                {
                    return "User ID already in use, please pick another";
                }
            }
            User newUser = new User(userID, lastName, firstName, uType);
            users[userCap] = newUser;
            userCap++; 
            return "User Added";
            
            
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
        /// <summary>
        /// uses the lastname and firstname fields to find a users id in the list of users. 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public int lookUpId(string lastName, string firstName)
        {
            for (int index = 0; index < userCap; index++)
            {
                if (users[index].getUserLastName() == lastName)
                {
                    if (users[index].getUserFirstName() == firstName)
                        return users[index].getUserID();
                }
            }
            return 0;
        }
        public int getBookCap()
        {
            return bookCap;
        }

        public int getUserCap()
        {
            return userCap;
        }
        /// <summary>
        /// creates a string array of all the media items and their characteristics in order to save them to a file.
        /// </summary>
        /// <returns></returns>
        public string[] saveMedia()
        {
            string[] data = new string[bookCap];
            for (int index = 0; index < bookCap; index++)
            {
                string bookId = books[index].getBookID().ToString();
                string lastName = books[index].getLastName();
                string firstName = books[index].getFirstName();
                string title = books[index].getTitle();
                string call = books[index].getCall();
                string type = books[index].getMediaType().ToString();
                if (books[index].getUserID() != -1)
                {
                    string userId = books[index].getUserID().ToString();
                    string date = books[index].getDueDate().ToString();
                    data[index] = (String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", bookId, lastName, firstName, title, call, type,userId,date));
                }
                else
                {
                    data[index] = String.Format("{0};{1};{2};{3};{4};{5}", bookId, lastName, firstName, title, call,type);
                }
            }
            return data;
        }
        /// <summary>
        /// Creates a string array of all the media items and their characteristics in order to save them to a file. 
        /// </summary>
        /// <returns></returns>
        public string[] saveUsers()
        {
            string[] data = new string[userCap];
            for (int index = 0; index<userCap; index++)
            {
                string userId = users[index].getUserID().ToString();
                string lastName = users[index].getUserLastName();
                string firstName = users[index].getUserFirstName();
                string type;
                if (users[index].isChild())
                    type = "1";
                else
                    type = "0";
                data[index] = String.Format("{0};{1};{2};{3}", userId, lastName, firstName, type);
            }
            return data;
        }
    }
}//end namespace Library