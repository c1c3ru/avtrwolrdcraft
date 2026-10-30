namespace Unity.Services.Qos.V2.Http;

internal static class ResponseHandler
{

	private static HttpException CreateHttpException(HttpClientResponse response, Type responseType) { }

	private static HttpException CreateOneOfException(HttpClientResponse response, Type responseType) { }

	private static List<IDeserializable> DeserializeListOfJsonObjects(List<Object> objectList) { }

	private static string GetDeserializedJson(Byte[] data) { }

	public static void HandleAsyncResponse(HttpClientResponse response, Dictionary<String, Type> statusCodeToTypeMap) { }

	public static T HandleAsyncResponse(HttpClientResponse response, Dictionary<String, Type> statusCodeToTypeMap) { }

	public static T TryDeserializeResponse(HttpClientResponse response) { }

	public static object TryDeserializeResponse(HttpClientResponse response, Type type) { }

}

