namespace PWC.AvatarSpineAnimationsPreview;

public class AvatarSpineAnimationsPreviewManager : AvatarMakerManager
{
	[CompilerGenerated]
	private sealed class <Start>d__9 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public AvatarSpineAnimationsPreviewManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <Start>d__9(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	private AvatarSpineAnimationsPreviewDropdownMenu _dropdownMenu; //Field offset: 0xB0
	[SerializeField]
	private SpineType _spineType; //Field offset: 0xB8
	[SerializeField]
	private int _currentCharacterID; //Field offset: 0xBC
	[CompilerGenerated]
	private SkeletonAnimation <SkeletonAnimation>k__BackingField; //Field offset: 0xC0

	public static AvatarSpineAnimationsPreviewManager Instance
	{
		 get { } //Length: 156
	}

	public private SkeletonAnimation SkeletonAnimation
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public AvatarSpineAnimationsPreviewManager() { }

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator <>n__0() { }

	private void CreateGreenScreen() { }

	public static AvatarSpineAnimationsPreviewManager get_Instance() { }

	[CompilerGenerated]
	public SkeletonAnimation get_SkeletonAnimation() { }

	protected virtual string GetAvatarPrefabPath() { }

	protected virtual string GetMenuPrefabPath() { }

	protected virtual void Init() { }

	[CompilerGenerated]
	private void set_SkeletonAnimation(SkeletonAnimation value) { }

	private void SetSpineProperties() { }

	[IteratorStateMachine(typeof(<Start>d__9))]
	protected virtual IEnumerator Start() { }

}

