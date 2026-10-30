namespace BWYW;

public class TasksListAttribute : PropertyAttribute
{
	private Type type; //Field offset: 0x10

	public Type Type
	{
		 get { } //Length: 8
	}

	public TasksListAttribute(Type type) { }

	public Type get_Type() { }

}

