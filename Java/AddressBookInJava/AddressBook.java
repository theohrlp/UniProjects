import java.io.*;
import java.util.ArrayList;

class AddressBook
{
    //vars declaration
    private ArrayList<Contact> contacts;

    private String fileName;

    AddressBook(String _fileName)
    {

        fileName = _fileName;

        contacts = new ArrayList<>();

        createOrLoadAddressBook();

    }

    private void createOrLoadAddressBook()
    {

        //Create or Find Address book

        File addressBookFile = new File(fileName);

        try
        {
            if (!addressBookFile.exists())
            {
                System.out.println("We need to make a new address book.");
                if (addressBookFile.createNewFile())
                    System.out.println("Address book has been created.");
                else
                    throw new IOException("Could not create file");
            }
            else
            {
                System.out.println("Address book already exists.");
                importContacts();
                if (contacts.size() > 0)
                    System.out.println(contacts.size() + " contacts have been loaded.");
                else
                    System.out.println("The Address book is currently empty.");
            }
        }

        catch (IOException e)
        {

            System.out.println("Could not create AddressBook File!!!");
        }
    }


    void viewContacts()
    {
        //iterates ArrayList contacts and prints every contact

        if (contacts.size() > 0)
        {
            for (Contact contact : contacts)
            {
                System.out.println(contact);
            }
        }
        else
        {
            System.out.println("|- Your address book is empty!");
        }

    }

    boolean addContact(Contact contact)
    {

        contacts.add(contact);

        return appendContact(contact);

    }

    Contact findContactByName(String lastName)
    {
        //iterates ArrayList contacts, searching for the given name

        for (Contact contact : contacts)
        {
            if (contact.hasLastName(lastName))
            {
                return contact;
            }
        }

        return null;

    }

    Contact findContactByPhone(String phoneNumber)
    {
        //iterates ArrayList contacts, searching for the given phone number

        for (Contact contact : contacts)
        {
            if (contact.hasPhoneNumber(phoneNumber))
            {
                return contact;
            }
        }

        return null;

    }

    boolean editContact(Contact originalContact, Contact editedContact)
    {

        contacts.remove(originalContact);

        contacts.add(editedContact);

        return saveAllContacts();

    }

    boolean deleteContact(String lastName)
    {

        Contact aContact = findContactByName(lastName);

        if (aContact != null)
        {
            contacts.remove(aContact);
            saveAllContacts();
            return true;
        }
        else
        {
            return false;
        }

    }

    private boolean saveAllContacts()
    {
        // writes the contacts to the disk

        FileWriter fileWriter;
        try
        {
            fileWriter = new FileWriter(fileName, false);

            for (Contact contact : contacts)
            {
                fileWriter.write(contact.serialize());
                fileWriter.write("\n");
            }

            fileWriter.close();

        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

        return true;
    }

    private boolean appendContact(Contact contact)
    {
        // write the contact to the disk with append = true

        FileWriter fileWriter;
        try
        {
            fileWriter = new FileWriter(fileName, true);

            fileWriter.write("\n");

            fileWriter.write(contact.serialize());

            fileWriter.close();

        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

        return true;
    }


    private void importContacts()
    {

        BufferedReader br = null;
        Contact contact;

        try
        {
            br = new BufferedReader(new FileReader(fileName));

            String line;

            while ((line = br.readLine()) != null)
            {
                if (!line.isEmpty())
                { // check for blank lines and skip them
                    String[] contactFields = line.split(Main.SEPARATOR);
                    contact = new Contact(contactFields[0], contactFields[1], contactFields[2], contactFields[3], contactFields[4]);
                    contacts.add(contact);
                }
            }

        }
        catch (IOException e)
        {
            e.printStackTrace();

        }
        finally
        {
            try
            {
                if (br != null)
                {
                    br.close();
                }
            }
            catch (IOException ex)
            {
                ex.printStackTrace();
            }
        }

    }

}
