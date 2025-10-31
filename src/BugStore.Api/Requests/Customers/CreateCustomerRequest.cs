namespace BugStore.Api.Requests.Customers;

public class CreateCustomerRequest(string name, string email, string phone, DateTime birthDate){
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;
    public DateTime BirthDate { get; set; } = birthDate;
}