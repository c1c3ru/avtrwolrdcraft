namespace RotaryHeart.Lib.SerializableDictionary;

[AttributeUsage(AttributeTargets::Field (256))]
public class IDAttribute : Attribute
{
	private string _id; //Field offset: 0x10

	public string Id
	{
		 get { } //Length: 8
	}

	public IDAttribute(string id) { }

	public string get_Id() { }

}

