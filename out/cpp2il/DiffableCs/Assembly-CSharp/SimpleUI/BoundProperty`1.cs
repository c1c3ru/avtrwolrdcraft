namespace SimpleUI;

public class BoundProperty : UnityEvent<T>
{
	private T PropertyValue; //Field offset: 0x0

	public T Value
	{
		 get { } //Length: 8
		 set { } //Length: 24
	}

	public BoundProperty`1() { }

	public BoundProperty`1(T initialValue) { }

	public T get_Value() { }

	public static T op_Implicit(BoundProperty<T> property) { }

	public void set_Value(T value) { }

	public void SetValueWithoutCallbacks(T value) { }

}

