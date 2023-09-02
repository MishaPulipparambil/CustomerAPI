using CustomerAPI.DTO;

public class CustomerDto
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string PhoneNumber { get; set; }
    public bool IsMailingAddressSame { get; set; }

    public AddressInfoDto BillingAddress { get; set; }
    public AddressInfoDto MailingAddress { get; set; }

}