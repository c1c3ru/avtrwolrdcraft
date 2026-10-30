namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCPositionToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private Vector2 _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private Vector2 _long; //Field offset: 0x2C
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private Vector2 _veryLong; //Field offset: 0x34

	public AFCPositionToScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetPosition(Vector2 position) { }

}

