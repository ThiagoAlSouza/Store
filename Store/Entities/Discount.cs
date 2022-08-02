namespace Store.Entities;

public class Discount : BaseEntity
{
    #region Constructors

    public Discount(decimal amount, DateTime expireDate)
    {
        Amount = amount;
        ExpireDate = expireDate;
    }

    #endregion

    #region Properties

    public decimal Amount { get; private set; }
    public DateTime ExpireDate { get; private set; }

    #endregion

    #region Methods

    public bool IsValid()
    {
        return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
    }

    public decimal Value()
    {
        if (IsValid())
            return Amount;
        
        return 0;
    }

    #endregion
}