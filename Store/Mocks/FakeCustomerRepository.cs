using Store.Entities;
using Store.Repository;

namespace Store.Mocks;

public class FakeCustomerRepository : ICustomerRepository
{
    public Customer Get(string document)
    {
        if (document == "4321")
            return new Customer("Thiago", "thiagoalsouza98@outlook.com");
        
        return null;
    }
}