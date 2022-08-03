using Store.Entities;

namespace Store.Repository;

internal interface ICustomerRepository
{
    Customer Get(string document);
}