namespace Game.Level;

public class LevelShovelHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private GameObject _sprite; //Field offset: 0xA0
	protected LevelDigArea _currentDigArea; //Field offset: 0xA8
	private int _tweenId; //Field offset: 0xB0
	private bool _isEndDrag; //Field offset: 0xB4

	public LevelShovelHandler() { }

	[CompilerGenerated]
	private void <Animate>b__8_0() { }

	[CompilerGenerated]
	private void <Animate>b__8_1() { }

	[CompilerGenerated]
	private void <Animate>b__8_2() { }

	protected override void Animate(bool value) { }

	private void CancelTween() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

