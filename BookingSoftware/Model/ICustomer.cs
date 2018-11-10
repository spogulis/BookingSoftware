namespace BookingSoftware.Model
{
    public interface ICustomer
    {
        string Address { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        int PhoneNumber { get; set; }
    }
}