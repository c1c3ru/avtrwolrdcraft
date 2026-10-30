namespace Game.Store;

public class StoreTooltipButton : ButtonBase
{
	[SerializeField]
	private RectTransform _bubble; //Field offset: 0x20
	[SerializeField]
	private bool _shouldStickToScrollRect; //Field offset: 0x28
	private Vector2 _anchoredPosition; //Field offset: 0x2C
	private StoreTweenToolipHandle _tweenTooltipHandle; //Field offset: 0x38

	public StoreTooltipButton() { }

	[CompilerGenerated]
	private void <OnClick>b__5_0() { }

	protected virtual void Awake() { }

	protected virtual void OnClick() { }

}

