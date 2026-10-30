namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCLibrarySectionScaleToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private ScrollRect _scrollRect; //Field offset: 0x28
	[SerializeField]
	private float _tablet; //Field offset: 0x30
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private float _long; //Field offset: 0x34
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private float _veryLong; //Field offset: 0x38

	public AFCLibrarySectionScaleToScreen() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void ScaleBy(float scaleFactor) { }

}

