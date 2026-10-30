namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(LayoutGroup))]
public class AFCLayoutGroupPaddingToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private RectOffset _tablet; //Field offset: 0x28
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private RectOffset _long; //Field offset: 0x30
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private RectOffset _veryLong; //Field offset: 0x38
	private LayoutGroup _layoutGroup; //Field offset: 0x40

	public AFCLayoutGroupPaddingToScreen() { }

	protected virtual void Awake() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetPadding(RectOffset padding) { }

}

