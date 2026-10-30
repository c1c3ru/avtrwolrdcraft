namespace Unity.Services.Lobbies.Http;

[JsonConverter(typeof(JsonObjectConverter))]
[Preserve]
public class JsonObject : IDeserializable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Object, IDeserializable> <>9__6_0; //Field offset: 0x8
		public static Func<Object, IDeserializable> <>9__7_1; //Field offset: 0x10
		public static Func<List`1<Object>, List`1<IDeserializable>> <>9__7_0; //Field offset: 0x18
		public static Func<KeyValuePair`2<String, Object>, String> <>9__8_0; //Field offset: 0x20
		public static Func<KeyValuePair`2<String, Object>, IDeserializable> <>9__8_1; //Field offset: 0x28
		public static Func<KeyValuePair`2<String, List`1<Object>>, String> <>9__9_0; //Field offset: 0x30
		public static Func<KeyValuePair`2<String, List`1<Object>>, List`1<IDeserializable>> <>9__9_1; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal IDeserializable <GetNewJsonObjectResponse>b__6_0(object v) { }

		internal List<IDeserializable> <GetNewJsonObjectResponse>b__7_0(List<Object> l) { }

		internal IDeserializable <GetNewJsonObjectResponse>b__7_1(object v) { }

		internal string <GetNewJsonObjectResponse>b__8_0(KeyValuePair<String, Object> kv) { }

		internal IDeserializable <GetNewJsonObjectResponse>b__8_1(KeyValuePair<String, Object> kv) { }

		internal string <GetNewJsonObjectResponse>b__9_0(KeyValuePair<String, List`1<Object>> kv) { }

		internal List<IDeserializable> <GetNewJsonObjectResponse>b__9_1(KeyValuePair<String, List`1<Object>> kv) { }

	}

	[Preserve]
	internal object obj; //Field offset: 0x10

	[Preserve]
	internal JsonObject(object obj) { }

	public override T GetAs(DeserializationSettings deserializationSettings = null) { }

	public T GetAs() { }

	public override string GetAsString() { }

	public static IDeserializable GetNewJsonObjectResponse(object o) { }

	public static List<IDeserializable> GetNewJsonObjectResponse(List<Object> o) { }

	public static List<List`1<IDeserializable>> GetNewJsonObjectResponse(List<List`1<Object>> o) { }

	public static Dictionary<String, IDeserializable> GetNewJsonObjectResponse(Dictionary<String, Object> o) { }

	public static Dictionary<String, List`1<IDeserializable>> GetNewJsonObjectResponse(Dictionary<String, List`1<Object>> o) { }

	private void ValidateFieldInfos(T objectToCheck, List<String> errors) { }

	private List<String> ValidateObject(T objectToCheck, List<String> errors = null) { }

	private void ValidatePropertyInfos(T objectToCheck, List<String> errors) { }

	private void ValidateValue(object value, string objectName, string memberType, string memberName, List<String> errors) { }

}

