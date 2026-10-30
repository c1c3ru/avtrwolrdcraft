namespace PazuCore.PazuCoreAddressables.AFC;

[RequireComponent(typeof(HorizontalOrVerticalLayoutGroup))]
public class AFCLayoutGroupSpacingToScreen : AFCScreenHandlerBase
{
	[SerializeField]
	private float _tablet; //Field offset: 0x24
	[FormerlySerializedAs("_tall")]
	[SerializeField]
	private float _long; //Field offset: 0x28
	[FormerlySerializedAs("_veryTall")]
	[SerializeField]
	private float _veryLong; //Field offset: 0x2C
	private HorizontalOrVerticalLayoutGroup _layoutGroup; //Field offset: 0x30

	public AFCLayoutGroupSpacingToScreen() { }

	protected virtual void Awake() { }

	protected virtual void HandleLong() { }

	protected virtual void HandleTablet() { }

	protected virtual void HandleVeryLong() { }

	private void SetSpacing(float spacing) { }

}

