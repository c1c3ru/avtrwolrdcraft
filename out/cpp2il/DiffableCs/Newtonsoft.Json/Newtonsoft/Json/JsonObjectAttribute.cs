namespace Newtonsoft.Json;

[AttributeUsage(1036, AllowMultiple = False)]
public sealed class JsonObjectAttribute : JsonContainerAttribute
{
	private MemberSerialization _memberSerialization; //Field offset: 0x68
	internal Nullable<MissingMemberHandling> _missingMemberHandling; //Field offset: 0x6C
	internal Nullable<Required> _itemRequired; //Field offset: 0x74
	internal Nullable<NullValueHandling> _itemNullValueHandling; //Field offset: 0x7C

	public NullValueHandling ItemNullValueHandling
	{
		 get { } //Length: 60
		 set { } //Length: 104
	}

	public Required ItemRequired
	{
		 get { } //Length: 60
		 set { } //Length: 104
	}

	public MemberSerialization MemberSerialization
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public MissingMemberHandling MissingMemberHandling
	{
		 get { } //Length: 60
		 set { } //Length: 104
	}

	public JsonObjectAttribute() { }

	public JsonObjectAttribute(MemberSerialization memberSerialization) { }

	[NullableContext(1)]
	public JsonObjectAttribute(string id) { }

	public NullValueHandling get_ItemNullValueHandling() { }

	public Required get_ItemRequired() { }

	public MemberSerialization get_MemberSerialization() { }

	public MissingMemberHandling get_MissingMemberHandling() { }

	public void set_ItemNullValueHandling(NullValueHandling value) { }

	public void set_ItemRequired(Required value) { }

	public void set_MemberSerialization(MemberSerialization value) { }

	public void set_MissingMemberHandling(MissingMemberHandling value) { }

}

