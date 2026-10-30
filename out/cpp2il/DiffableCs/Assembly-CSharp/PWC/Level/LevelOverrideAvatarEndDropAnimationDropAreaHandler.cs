namespace PWC.Level;

public class LevelOverrideAvatarEndDropAnimationDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TrackEntry, Boolean> <>9__12_1; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OverrideCharacterEndDropAnimation>b__12_1(TrackEntry trackEntry) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public ILevelAnimatable animatable; //Field offset: 0x10
		public ILevelAvatar avatar; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <OverrideCharacterEndDropAnimation>b__0(TrackEntry x) { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x28
	[SerializeField]
	private SkeletonDataAsset _skeletonDataAsset; //Field offset: 0x30
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private string _animationName; //Field offset: 0x38
	[SerializeField]
	private bool _isLoop; //Field offset: 0x40
	[SerializeField]
	private bool _isAnimateOnPostInit; //Field offset: 0x41
	private bool _noMixDuration; //Field offset: 0x42

	public LevelOverrideAvatarEndDropAnimationDropAreaHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private bool OverrideCharacterEndDropAnimation(ILevelAvatar avatar) { }

	public void SetAnimationName(string animationName) { }

	public void SetNextNoMixDuration() { }

}

