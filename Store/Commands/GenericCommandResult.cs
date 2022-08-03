using Store.Commands.Interfaces;

namespace Store.Commands;

public class GenericCommandResult : ICommandResult
{
    #region Contructor

    public GenericCommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    #endregion

    #region Properties

    public bool Success { get; set; }
    public string Message { get; set; }
    public Object Data { get; set; }

    #endregion
}