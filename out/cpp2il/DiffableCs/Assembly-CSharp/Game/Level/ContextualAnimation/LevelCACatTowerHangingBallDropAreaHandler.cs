namespace Game.Level.ContextualAnimation;

public class LevelCACatTowerHangingBallDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelCACatTowerHangingBallDropAreaHandler <>4__this; //Field offset: 0x10
		public bool catIsFlipped; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass7_0() { }

		internal void <AnimateHangingBall>b__0() { }

		internal void <AnimateHangingBall>b__1() { }

	}

	[SerializeField]
	private GameObject _hangingBall; //Field offset: 0x80
	private int _tweenID; //Field offset: 0x88
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x90

	public LevelCACatTowerHangingBallDropAreaHandler() { }

	private void AnimateHangingBall(bool isWeak, bool catIsFlipped) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

