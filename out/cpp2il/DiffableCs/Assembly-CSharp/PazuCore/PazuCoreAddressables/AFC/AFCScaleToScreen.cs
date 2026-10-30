namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCScaleToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private float _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private float _long; //Field offset: 0x28
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private float _veryLong; //Field offset: 0x2C

	public AFCScaleToScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetScale(float scale) { }

}

