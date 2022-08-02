namespace Store.Entities;

public class Customer
{
    #region Contructors

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    #endregion

    #region Properties

    public string Name { get; private set; }
    public string Email { get; private set; }

    #endregion
}