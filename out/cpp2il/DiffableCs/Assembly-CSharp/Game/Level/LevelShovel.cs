namespace Game.Level;

public class LevelShovel : LevelSimpleDragActionItemBase
{
	[SerializeField]
	private GameObject _sprite; //Field offset: 0x358
	protected LevelDigArea _currentDigArea; //Field offset: 0x360
	private int _tweenId; //Field offset: 0x368
	private bool _isEndDrag; //Field offset: 0x36C

	public LevelShovel() { }

	[CompilerGenerated]
	private void <Animate>b__8_0() { }

	[CompilerGenerated]
	private void <Animate>b__8_1() { }

	[CompilerGenerated]
	private void <Animate>b__8_2() { }

	protected override void Animate(bool value) { }

	private void CancelTween() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer) { }

}

