namespace Game.Store;

public class StoreTweenToolipHandle
{
	private readonly GameObject _target; //Field offset: 0x10
	private readonly Action _onCompleteAction; //Field offset: 0x18
	private readonly float _duration; //Field offset: 0x20
	private int _tweenId; //Field offset: 0x24

	public StoreTweenToolipHandle(GameObject target, Action onCompleteAction = null, float duration = 3) { }

	[CompilerGenerated]
	private void <Tween>b__8_0() { }

	[CompilerGenerated]
	private void <Tween>b__8_1() { }

	[CompilerGenerated]
	private void <Tween>b__8_2() { }

	public void Hide() { }

	public bool IsVisible() { }

	public bool TryCancel() { }

	public void Tween() { }

}

