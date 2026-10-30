namespace Game.Level;

public class LevelBroomDragActionHandler : LevelDragActionItemHandlerBase
{
	[SerializeField]
	private GameObject _parentForAnimation; //Field offset: 0xA0
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xA8
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xB0

	public LevelBroomDragActionHandler() { }

	[CompilerGenerated]
	private void <Animate>b__6_1() { }

	[CompilerGenerated]
	private void <Animate>b__6_2() { }

	[CompilerGenerated]
	private void <Animate>b__6_3() { }

	[CompilerGenerated]
	private void <Animate>b__6_4() { }

	[CompilerGenerated]
	private void <Animate>g__Rotate|6_0() { }

	private void Animate(bool value) { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

}

