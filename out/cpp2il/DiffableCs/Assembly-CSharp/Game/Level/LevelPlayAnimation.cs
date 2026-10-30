namespace Game.Level;

public class LevelPlayAnimation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public LevelPlayAnimation <>4__this; //Field offset: 0x10
		public String[] nextAnimationNames; //Field offset: 0x18
		public LevelCharacter character; //Field offset: 0x20

		public <>c__DisplayClass2_0() { }

		internal void <PlayAnimations>b__0(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelBaby baby; //Field offset: 0x10
		public string previousAnimationName; //Field offset: 0x18
		public bool previousAnimationLoop; //Field offset: 0x20
		public LevelPlayAnimation <>4__this; //Field offset: 0x28
		public String[] nextAnimationNames; //Field offset: 0x30

		public <>c__DisplayClass4_0() { }

		internal void <PlayAnimations>b__0(TrackEntry track) { }

		internal void <PlayAnimations>b__1(TrackEntry track) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelToddler toddler; //Field offset: 0x10
		public string previousAnimationName; //Field offset: 0x18
		public bool previousAnimationLoop; //Field offset: 0x20
		public LevelPlayAnimation <>4__this; //Field offset: 0x28
		public String[] nextAnimationNames; //Field offset: 0x30

		public <>c__DisplayClass6_0() { }

		internal void <PlayAnimations>b__0(TrackEntry track) { }

		internal void <PlayAnimations>b__1(TrackEntry track) { }

	}

	[SerializeField]
	private List<String> _animations; //Field offset: 0x20

	public LevelPlayAnimation() { }

	public void Play(ILevelAvatar avatar) { }

	private void PlayAnimations(string animationName, LevelCharacter character, String[] nextAnimationNames) { }

	private void PlayAnimations(string animationName, LevelBaby baby, String[] nextAnimationNames) { }

	private void PlayAnimations(string animationName, LevelBaby baby, string previousAnimationName, bool previousAnimationLoop, String[] nextAnimationNames) { }

	private void PlayAnimations(string animationName, LevelToddler toddler, String[] nextAnimationNames) { }

	private void PlayAnimations(string animationName, LevelToddler toddler, string previousAnimationName, bool previousAnimationLoop, String[] nextAnimationNames) { }

}

