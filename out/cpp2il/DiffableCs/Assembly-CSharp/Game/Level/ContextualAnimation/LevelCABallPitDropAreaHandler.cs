namespace Game.Level.ContextualAnimation;

public class LevelCABallPitDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelCABallPitDropAreaHandler <>4__this; //Field offset: 0x10
		public LevelCharacter character; //Field offset: 0x18
		public Action <>9__0; //Field offset: 0x20

		public <>c__DisplayClass7_0() { }

		internal void <MakeTimedPerticles>b__0() { }

	}

	[SerializeField]
	private LevelBallPitDropArea _dropArea; //Field offset: 0x80
	[SerializeField]
	private Sprite _thumb; //Field offset: 0x88
	private readonly Single[][] _particlesTimesPerAnimation; //Field offset: 0x90
	private readonly Stack<Int32> _tweenIDStack; //Field offset: 0x98
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xA0

	public LevelCABallPitDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void MakeTimedPerticles(int animationIndex, LevelCharacter character) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

