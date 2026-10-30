namespace PazuCore.PazuCloud;

public class GetNotConsumedProductsResponse : Response
{
	public readonly Dictionary<Int32, String> content; //Field offset: 0x58

	public GetNotConsumedProductsResponse(string responseText) { }

}

