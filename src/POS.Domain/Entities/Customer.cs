namespace POS.Domain.Entities;

public class Customer
{
    public Guid CustomerId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }

    protected Customer()
    {
    }

    public Customer(Guid customerId, string firstName, string lastName,
        string phone, string address)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Address = address;
    }

}

