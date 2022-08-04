using Store.Commands;

namespace Store.Utils;

public static class ExtractGuids
{
    #region Methods

    public static IEnumerable<Guid> Extract(IList<CreateOrderItemCommand> items)
    {
        var guids = new List<Guid>();

        foreach (var item in items)
            guids.Add(item.Product);

        return guids;
    }

    #endregion
}