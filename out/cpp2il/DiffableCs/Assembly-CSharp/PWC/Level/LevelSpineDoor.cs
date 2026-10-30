namespace PWC.Level;

public class LevelSpineDoor : LevelDoor
{
	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0x90
	[SerializeField]
	protected string _openAnimationName; //Field offset: 0x98
	[SerializeField]
	protected string _closeAnimationName; //Field offset: 0xA0
	[SerializeField]
	protected string _openIdleAnimationName; //Field offset: 0xA8
	[SerializeField]
	protected string _closeIdleAnimationName; //Field offset: 0xB0
	protected bool _isAnimationInProgress; //Field offset: 0xB8
	[CompilerGenerated]
	private Action<Boolean> OnBeginAnimationAction; //Field offset: 0xC0
	[CompilerGenerated]
	private Action<Boolean> OnEndAnimationAction; //Field offset: 0xC8

	public event Action<Boolean> OnBeginAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Boolean> OnEndAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelSpineDoor() { }

	[CompilerGenerated]
	private void <ForceAnimation>b__17_0(TrackEntry x) { }

	[CompilerGenerated]
	private void <PlayAnimation>b__13_0(TrackEntry x) { }

	[CompilerGenerated]
	private void <PlayAnimation>b__13_1(TrackEntry x) { }

	[CompilerGenerated]
	public void add_OnBeginAnimationAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public void add_OnEndAnimationAction(Action<Boolean> value) { }

	public void ForceAnimation(bool isOpen) { }

	public void ForceState(bool isOpen) { }

	protected override void OnBeginAnimation() { }

	protected override void OnEndAnimation() { }

	protected override void PlayAnimation(bool silent = false) { }

	[CompilerGenerated]
	public void remove_OnBeginAnimationAction(Action<Boolean> value) { }

	[CompilerGenerated]
	public void remove_OnEndAnimationAction(Action<Boolean> value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual void ToggleState(bool silent = false) { }

}

