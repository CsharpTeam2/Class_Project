namespace Library
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
                //write message book not found
            }
            else
            {
                items--;
            }
        }//end removeBook
        public string listBooks()
        {
            string str = "";
            if (items == 0)
            {
                return "No books currently checked out";
            }
            else
            {
                for (int index = 0; index < items; index++)
                {
                    str += books[index].ToString();
                }
                return str;
            }
        }
        public override string ToString()
        {
            return (String.Format("{0} {1}, {2} {3} {4}", userID, lastName, firstName, userType, items) + listBooks());
        }
     }//end user class
}//end namespace Library