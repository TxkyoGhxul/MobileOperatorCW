namespace Application.Common.Exceptions;
public class NotFoundException : Exception
{
	public NotFoundException(string name, object key) : base($"Entity \"{name}\" with ID: ({key}) not found.") { }
}
