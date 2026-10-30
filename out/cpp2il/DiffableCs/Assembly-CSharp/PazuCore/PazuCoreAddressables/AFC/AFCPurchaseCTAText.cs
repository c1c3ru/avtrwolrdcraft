namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPurchaseCTAText : AFCLocalizedText
{
	[SerializeField]
	private string _noTrialKey; //Field offset: 0x50

	public AFCPurchaseCTAText() { }

	protected virtual void GetLocalizedText() { }

}

