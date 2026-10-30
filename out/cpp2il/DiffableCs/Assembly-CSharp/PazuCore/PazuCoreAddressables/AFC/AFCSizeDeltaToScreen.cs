namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCSizeDeltaToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private Vector2 _long; //Field offset: 0x2C
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private Vector2 _veryLong; //Field offset: 0x34

	public AFCSizeDeltaToScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetSizeDelta(Vector2 sizeDelta) { }

}

