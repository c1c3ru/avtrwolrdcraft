namespace Spine.Unity;

[AddComponentMenu("Spine/SkeletonAnimation")]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonAnimation-Component")]
public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, ISpineComponent, IAnimationStateComponent
{
	public AnimationState state; //Field offset: 0x110
	private bool wasUpdatedAfterInit; //Field offset: 0x118
	[CompilerGenerated]
	private ISkeletonAnimationDelegate _OnAnimationRebuild; //Field offset: 0x120
	[CompilerGenerated]
	private UpdateBonesDelegate _BeforeApply; //Field offset: 0x128
	[CompilerGenerated]
	private UpdateBonesDelegate _UpdateLocal; //Field offset: 0x130
	[CompilerGenerated]
	private UpdateBonesDelegate _UpdateWorld; //Field offset: 0x138
	[CompilerGenerated]
	private UpdateBonesDelegate _UpdateComplete; //Field offset: 0x140
	[SerializeField]
	protected UpdateTiming updateTiming; //Field offset: 0x148
	[SerializeField]
	protected bool unscaledTime; //Field offset: 0x14C
	[SerializeField]
	[SpineAnimation(null, null, True, False, False)]
	private string _animationName; //Field offset: 0x150
	public bool loop; //Field offset: 0x158
	public float timeScale; //Field offset: 0x15C

	protected event UpdateBonesDelegate _BeforeApply
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	protected event ISkeletonAnimationDelegate _OnAnimationRebuild
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	protected event UpdateBonesDelegate _UpdateComplete
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	protected event UpdateBonesDelegate _UpdateLocal
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	protected event UpdateBonesDelegate _UpdateWorld
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event UpdateBonesDelegate BeforeApply
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public override event ISkeletonAnimationDelegate OnAnimationRebuild
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public override event UpdateBonesDelegate UpdateComplete
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public override event UpdateBonesDelegate UpdateLocal
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public override event UpdateBonesDelegate UpdateWorld
	{
		 add { } //Length: 4
		 remove { } //Length: 4
	}

	public string AnimationName
	{
		 get { } //Length: 72
		 set { } //Length: 244
	}

	public override AnimationState AnimationState
	{
		 get { } //Length: 40
	}

	public override bool UnscaledTime
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public override UpdateTiming UpdateTiming
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SkeletonAnimation() { }

	[CompilerGenerated]
	protected void add__BeforeApply(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void add__OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	[CompilerGenerated]
	protected void add__UpdateComplete(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void add__UpdateLocal(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void add__UpdateWorld(UpdateBonesDelegate value) { }

	public void add_BeforeApply(UpdateBonesDelegate value) { }

	public override void add_OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	public override void add_UpdateComplete(UpdateBonesDelegate value) { }

	public override void add_UpdateLocal(UpdateBonesDelegate value) { }

	public override void add_UpdateWorld(UpdateBonesDelegate value) { }

	public static SkeletonAnimation AddToGameObject(GameObject gameObject, SkeletonDataAsset skeletonDataAsset, bool quiet = false) { }

	public void AfterAnimationApplied() { }

	public override void ApplyAnimation() { }

	public virtual void ClearState() { }

	protected override void FixedUpdate() { }

	public string get_AnimationName() { }

	public override AnimationState get_AnimationState() { }

	public override bool get_UnscaledTime() { }

	public override UpdateTiming get_UpdateTiming() { }

	public virtual void Initialize(bool overwrite, bool quiet = false) { }

	public virtual void LateUpdate() { }

	public static SkeletonAnimation NewSkeletonAnimationGameObject(SkeletonDataAsset skeletonDataAsset, bool quiet = false) { }

	protected override void OnAnimationDisposed(TrackEntry entry) { }

	public virtual void OnBecameVisible() { }

	[CompilerGenerated]
	protected void remove__BeforeApply(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void remove__OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	[CompilerGenerated]
	protected void remove__UpdateComplete(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void remove__UpdateLocal(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	protected void remove__UpdateWorld(UpdateBonesDelegate value) { }

	public void remove_BeforeApply(UpdateBonesDelegate value) { }

	public override void remove_OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	public override void remove_UpdateComplete(UpdateBonesDelegate value) { }

	public override void remove_UpdateLocal(UpdateBonesDelegate value) { }

	public override void remove_UpdateWorld(UpdateBonesDelegate value) { }

	public void set_AnimationName(string value) { }

	public override void set_UnscaledTime(bool value) { }

	public override void set_UpdateTiming(UpdateTiming value) { }

	public void Update(float deltaTime) { }

	protected override void Update() { }

	protected void UpdateAnimationStatus(float deltaTime) { }

}

