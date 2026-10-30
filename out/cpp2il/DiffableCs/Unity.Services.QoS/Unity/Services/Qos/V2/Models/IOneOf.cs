namespace Unity.Services.Qos.V2.Models;

internal interface IOneOf
{

	public Type Type
	{
		 get { } //Length: 0
	}

	public object Value
	{
		 get { } //Length: 0
	}

	public Type get_Type() { }

	public object get_Value() { }

}

