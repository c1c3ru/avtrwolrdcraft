namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(Text))]
public class AFCFontSizeToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private int _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private int _long; //Field offset: 0x28
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private int _veryLong; //Field offset: 0x2C

	public AFCFontSizeToScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetFontSize(int fontSize) { }

}

