namespace Game.Level.ContextualAnimation;

public class LevelCAMetalDetectorDropAreaHandler : LevelCADropAreaHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public LevelCAConfig config; //Field offset: 0x10
		public LevelCAMetalDetectorDropAreaHandler <>4__this; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20
		public Action <>9__3; //Field offset: 0x28
		public Action <>9__4; //Field offset: 0x30

		public <>c__DisplayClass14_0() { }

		internal void <OnAnimationBegin>b__0() { }

		internal void <OnAnimationBegin>b__1() { }

		internal void <OnAnimationBegin>b__3() { }

		internal void <OnAnimationBegin>b__4() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_1
	{
		public LevelCharacter targetCharacter; //Field offset: 0x10
		public Action <>9__2; //Field offset: 0x18

		public <>c__DisplayClass14_1() { }

		internal void <OnAnimationBegin>b__2() { }

	}

	[SerializeField]
	private float _detectionPointX; //Field offset: 0x80
	[SerializeField]
	private float _endOfDetectorX; //Field offset: 0x84
	[SerializeField]
	private GameObject _greenLights; //Field offset: 0x88
	[SerializeField]
	private GameObject _redLights; //Field offset: 0x90
	[SerializeField]
	protected string _soundName; //Field offset: 0x98
	private bool _isInit; //Field offset: 0xA0
	private string securityDogShirt; //Field offset: 0xA8
	private string securityGuardShirt; //Field offset: 0xB0
	private Dictionary<Int32, Int32> _tweenIDByCharacterID; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC0

	public LevelCAMetalDetectorDropAreaHandler() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	private void Init() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	protected virtual void OnLevelPostInit() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

}

