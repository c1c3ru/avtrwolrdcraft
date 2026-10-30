namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCListPositionCtrlBoxDensityPerScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private float _tablet; //Field offset: 0x24
	[SerializeField]
	private float _long; //Field offset: 0x28
	[SerializeField]
	private float _veryLong; //Field offset: 0x2C
	[SerializeField]
	private ListPositionCtrl _listPositionCtrl; //Field offset: 0x30

	public AFCListPositionCtrlBoxDensityPerScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetDensity(float density) { }

}

