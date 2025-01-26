namespace BLL.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
        : base()
    {

    }
    public NotFoundException(string message)
        : base(message)
    {

    }
    public NotFoundException(int id)
        : base($"There is nothing found by id {id}")
    {

    }
}
