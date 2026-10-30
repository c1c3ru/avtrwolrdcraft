namespace PWC.Achievements;

public class AWACloudClaimResponse : AWACloudWorthResponse
{
	public readonly int currencyBalance; //Field offset: 0x60

	public AWACloudClaimResponse(string responseText) { }

}

