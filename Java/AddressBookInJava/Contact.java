
class Contact
{
    //vars declaration
    private String fName;
    private String lName;
    private String PhoneNum;
    private String Email;
    private String Address;

    Contact()
    {

    }

    Contact(String fName, String lName, String PhoneNum, String Email, String Address)
    {
        this.fName = fName;
        this.lName = lName;
        this.PhoneNum = PhoneNum;
        this.Email = Email;
        this.Address = Address;
    }

    //Getters And Setters

    void setfName(String fName)
    {
        this.fName = fName;
    }


    void setlName(String lName)
    {
        this.lName = lName;
    }


    void setPhoneNum(String PhoneNum)
    {
        this.PhoneNum = PhoneNum;
    }


    void setEmail(String Email)
    {
        this.Email = Email;
    }


    void setAddress(String Address)
    {
        this.Address = Address;
    }

    boolean hasLastName(String name)
    {
        return lName.contains(name);
    }

    boolean hasPhoneNumber(String phoneNumber)
    {
        return PhoneNum.contains(phoneNumber);
    }

    @Override
    public String toString()
    {
        return fName + " " + lName + ", " + PhoneNum + ", " + Email + ", " + Address;
    }

    String serialize()
    {
        return fName + Main.SEPARATOR + lName + Main.SEPARATOR + PhoneNum + Main.SEPARATOR + Email + Main.SEPARATOR + Address;
    }
}
