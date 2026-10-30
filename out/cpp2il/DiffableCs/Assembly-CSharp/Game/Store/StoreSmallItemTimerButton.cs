namespace Game.Store;

public class StoreSmallItemTimerButton : ButtonBase
{
	[SerializeField]
	private StorePackItem _packItem; //Field offset: 0x20
	[SerializeField]
	private RectTransform _target; //Field offset: 0x28
	[SerializeField]
	private Vector2 _hiddenPosition; //Field offset: 0x30
	[SerializeField]
	private Vector2 _visiblePosition; //Field offset: 0x38
	private bool _isVisible; //Field offset: 0x40
	private int _tweenId; //Field offset: 0x44

	public StoreSmallItemTimerButton() { }

	[CompilerGenerated]
	private void <ToggleView>b__10_0(Vector2 value) { }

	[CompilerGenerated]
	private void <ToggleView>b__10_1() { }

	[CompilerGenerated]
	private void <ToggleView>b__10_2() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

	private void OnDestroy() { }

	private void ToggleView() { }

	private bool TryOverrideItemClick(StorePackItemBase item) { }

}

