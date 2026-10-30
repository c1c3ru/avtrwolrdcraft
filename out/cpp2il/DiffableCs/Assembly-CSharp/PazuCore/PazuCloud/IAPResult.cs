namespace PazuCore.PazuCloud;

public class IAPResult
{
	internal enum ActionType
	{
		Buy = 0,
		Restore = 1,
	}

	internal enum ErrorType
	{
		None = 0,
		InMiddleOfAnOtherTransaction = 1,
		IAPDisabled = 2,
		ProductNotFound = 3,
		SeeTextField = 4,
		NoInternetConnection = 5,
		FailedToVerifyReceipt = 6,
		NoReceiptData = 7,
		ProductAlreadyPurchased = 8,
	}

	internal enum Type
	{
		Success = 0,
		Failure = 1,
		Canceled = 2,
		Pending = 3,
	}

	public Type type; //Field offset: 0x10
	public ActionType actionType; //Field offset: 0x14
	public ErrorType errorType; //Field offset: 0x18
	public ClientMessage clientMessage; //Field offset: 0x20
	public bool useTextAsLocalizationTextKey; //Field offset: 0x28
	public bool dontShowLocalMessage; //Field offset: 0x29

	public IAPResult() { }

	public IAPResult(Type type, ActionType actionType) { }

	public static IAPResult CreateFailureFromClientMessage(ActionType actionType, ClientMessage clientError) { }

}

