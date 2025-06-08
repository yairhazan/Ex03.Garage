namespace Ex03.GarageLogic;
public class ContactDetails
{
    public string m_OwnerName { get; set; }
    public string m_OwnerPhone { get; set; }

    public ContactDetails(string i_OwnerName, string i_OwnerPhone)
    {
        m_OwnerName = i_OwnerName;
        m_OwnerPhone = i_OwnerPhone;
    }
}