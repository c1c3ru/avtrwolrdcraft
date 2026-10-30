namespace Newtonsoft.Json;

[AttributeUsage(1028, AllowMultiple = False)]
public sealed class JsonArrayAttribute : JsonContainerAttribute
{
	private bool _allowNullItems; //Field offset: 0x68

	public bool AllowNullItems
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public JsonArrayAttribute() { }

	public JsonArrayAttribute(bool allowNullItems) { }

	[NullableContext(1)]
	public JsonArrayAttribute(string id) { }

	public bool get_AllowNullItems() { }

	public void set_AllowNullItems(bool value) { }

}

