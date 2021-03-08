import java.util.Scanner;


public class Main
{

    // set the address book file to be on the same directory as the java executable
    private static final String ADDRESS_BOOK_FILE = System.getProperty("user.dir") +  "/address_book.txt";

    //    declaring global separator
    static String SEPARATOR = ";";

    //    declaring variables
    private static Scanner in = new Scanner(System.in);


    public static void main(String[] args)
    {
        in.useDelimiter("\n");  // to let scanner allow input strings to have spaces or other characters
        Initialize();
    }

    private static void Initialize()
    {

        AddressBook addressBook = new AddressBook(ADDRESS_BOOK_FILE);

        //vars declaration
        int choice, searchChoice;
        Contact contact, editedContact;
        String termToFind;


        while (true)
        {

            System.out.println();
            System.out.println("-------------------------");
            System.out.println("|         Menu          |");
            System.out.println("-------------------------");

            System.out.println("1) View all contacts.\n2) Add a contact.\n3) Search a contact.\n4) Edit a contact.\n5) Remove a contact.\n6) Exit.\n");
            System.out.print("Enter your option: ");
            while (!in.hasNextInt())
            {
                System.out.println("Please enter an integer: \n");
                in.next();
            }
            choice = in.nextInt();

            switch (choice)
            {
                case 1:

                    addressBook.viewContacts();

                    break;

                case 2:

                    contact = UserInput();

                    if (addressBook.addContact(contact))

                    {
                        System.out.println("|- Contact added: " + contact);
                    }
                    else
                    {
                        System.out.println("|- Could not add contact.");
                    }

                    break;

                case 3:

                    System.out.print("Search by: 1) Last Name 2) Phone Number : ");

                    while (!in.hasNextInt())
                    {
                        System.out.println("Please enter an integer: \n");

                        in.next();
                    }
                    searchChoice = in.nextInt();

                    switch (searchChoice)
                    {
                        case 1:

                            System.out.print("Enter Last Name to find: ");

                            termToFind = in.next();

                            contact = addressBook.findContactByName(termToFind);

                            if (contact != null)

                            {
                                System.out.println("|- Found: " + contact);
                            }

                            else
                            {
                                System.out.println("|- Could not find a contact by name: " + termToFind);
                            }

                            break;

                        case 2:

                            System.out.print("Enter Phone Number to find: ");

                            termToFind = in.next();

                            contact = addressBook.findContactByPhone(termToFind);

                            if (contact != null)
                            {
                                System.out.println("|- Found: " + contact);
                            }

                            else
                            {
                                System.out.println("|- Could not find a contact by phone number : " + termToFind);
                            }
                            break;

                        default:
                            System.out.println("Enter an integer between 1 and 2.");

                            break;
                    }
                    break;
                case 4:

                    System.out.print("Enter Last Name to Edit: ");

                    termToFind = in.next();

                    contact = addressBook.findContactByName(termToFind);

                    if (contact != null)
                    {
                        System.out.println("|- Found: " + contact);

                        System.out.println("Edit the details of the contact:");

                        editedContact = UserInput();

                        if (addressBook.editContact(contact, editedContact))
                        {
                            System.out.println("|- Contact is updated: " + editedContact);
                        }
                        else
                        {
                            System.out.println("|- Could not update contact.");
                        }

                    }
                    else
                    {
                        System.out.println("|- Could not find a contact by name : " + termToFind);
                    }
                    break;

                case 5:

                    System.out.print("Enter Last Name to Remove: ");

                    termToFind = in.next();

                    if (addressBook.deleteContact(termToFind))
                    {
                        System.out.println("|- Contact by this name : " + termToFind + " was deleted.");

                    }
                    else
                    {
                        System.out.println("|- Could not find a contact by this name : " + termToFind);
                    }
                    break;

                case 6:

                    System.out.println("|- Application terminated.");

                    System.exit(0);

                default:

                    System.out.println("Enter an integer between 1 and 6.");

                    break;
            }
        }
    }


    private static Contact UserInput()
    {

        //   Taking user input.

        Contact contact = new Contact();

        System.out.print("Enter first name: ");

        String fName = in.next();

        while (!fName.matches("^[a-zA-z]+$"))  //Validating user input
        {
            System.out.println("First name contains invalid characters. \nYou typed " + fName + "\nTry again");
            fName = in.next();
        }

        contact.setfName(fName);

        System.out.print("Enter last name: ");

        String lName = in.next();

        while (!lName.matches("^[a-zA-z]+$"))   //Validating user input
        {
            System.out.println("Last name contains invalid characters. \nYou typed " + lName + "\nTry again");
            lName = in.next();
        }

        contact.setlName(lName);

        System.out.print("Enter phone number: ");

        String phoneNum = in.next();

        while (!phoneNum.matches("^[\\d]{10}$"))   //Validating user input
        {
            System.out.println("Phone number invalid. \nYou typed " + phoneNum + "\nTry again");
            phoneNum = in.next();
        }

        contact.setPhoneNum(phoneNum);

        System.out.print("Enter email: ");

        String Email = in.next();

        while (!Email.matches("^[\\w\\d]+@[\\d\\w]+\\.[\\w]{2,3}$"))   //Validating user input
        {
            System.out.println("Email invalid. \nYou typed " + Email + "\nTry again");
            Email = in.next();
        }

        contact.setEmail(Email);

        System.out.print("Enter address: ");
        contact.setAddress(in.next());

        return contact;

    }


}
