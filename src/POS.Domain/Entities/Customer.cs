using POS.Domain.ValueObjects;

namespace POS.Domain.Entities;

public class Customer
{
    public UserId CustomerId { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Phone Phone { get; private set; }
    public Address Address { get; private set; }

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

