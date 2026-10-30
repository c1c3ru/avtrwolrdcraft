namespace Spine.Unity;

[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonMecanim-Component")]
[RequireComponent(typeof(Animator))]
public class SkeletonMecanim : SkeletonRenderer, ISkeletonAnimation, ISpineComponent
{
	internal class MecanimTranslator
	{
		private class AnimationClipEqualityComparer : IEqualityComparer<AnimationClip>
		{
			internal static readonly IEqualityComparer<AnimationClip> Instance; //Field offset: 0x0

			private static AnimationClipEqualityComparer() { }

			public AnimationClipEqualityComparer() { }

			public override bool Equals(AnimationClip x, AnimationClip y) { }

			public override int GetHashCode(AnimationClip o) { }

		}

		internal class ClipInfos
		{
			public bool isInterruptionActive; //Field offset: 0x10
			public bool isLastFrameOfInterruption; //Field offset: 0x11
			public int clipInfoCount; //Field offset: 0x14
			public int nextClipInfoCount; //Field offset: 0x18
			public int interruptingClipInfoCount; //Field offset: 0x1C
			public readonly List<AnimatorClipInfo> clipInfos; //Field offset: 0x20
			public readonly List<AnimatorClipInfo> nextClipInfos; //Field offset: 0x28
			public readonly List<AnimatorClipInfo> interruptingClipInfos; //Field offset: 0x30
			public Single[] clipResolvedWeights; //Field offset: 0x38
			public Single[] nextClipResolvedWeights; //Field offset: 0x40
			public Single[] interruptingClipResolvedWeights; //Field offset: 0x48
			public AnimatorStateInfo stateInfo; //Field offset: 0x50
			public AnimatorStateInfo nextStateInfo; //Field offset: 0x74
			public AnimatorStateInfo interruptingStateInfo; //Field offset: 0x98
			public float interruptingClipTimeAddition; //Field offset: 0xBC

			public ClipInfos() { }

		}

		private class IntEqualityComparer : IEqualityComparer<Int32>
		{
			internal static readonly IEqualityComparer<Int32> Instance; //Field offset: 0x0

			private static IntEqualityComparer() { }

			public IntEqualityComparer() { }

			public override bool Equals(int x, int y) { }

			public override int GetHashCode(int o) { }

		}

		internal enum MixMode
		{
			AlwaysMix = 0,
			MixNext = 1,
			Hard = 2,
			Match = 3,
		}

		internal sealed class OnClipAppliedDelegate : MulticastDelegate
		{

			public OnClipAppliedDelegate(object object, IntPtr method) { }

			public override IAsyncResult BeginInvoke(Animation clip, int layerIndex, float weight, float time, float lastTime, bool playsBackward, AsyncCallback callback, object object) { }

			public override void EndInvoke(IAsyncResult result) { }

			public override void Invoke(Animation clip, int layerIndex, float weight, float time, float lastTime, bool playsBackward) { }

		}

		private const float WeightEpsilon = 0,0001; //Field offset: 0x0
		public bool autoReset; //Field offset: 0x10
		public bool useCustomMixMode; //Field offset: 0x11
		public MixMode[] layerMixModes; //Field offset: 0x18
		public MixBlend[] layerBlendModes; //Field offset: 0x20
		[CompilerGenerated]
		private OnClipAppliedDelegate _OnClipApplied; //Field offset: 0x28
		private readonly Dictionary<Int32, Animation> animationTable; //Field offset: 0x30
		private readonly Dictionary<AnimationClip, Int32> clipNameHashCodeTable; //Field offset: 0x38
		private readonly List<Animation> previousAnimations; //Field offset: 0x40
		protected ClipInfos[] layerClipInfos; //Field offset: 0x48
		private Animator animator; //Field offset: 0x50

		protected event OnClipAppliedDelegate _OnClipApplied
		{
			[CompilerGenerated]
			 add { } //Length: 156
			[CompilerGenerated]
			 remove { } //Length: 156
		}

		public event OnClipAppliedDelegate OnClipApplied
		{
			 add { } //Length: 4
			 remove { } //Length: 4
		}

		public Animator Animator
		{
			 get { } //Length: 8
		}

		public int MecanimLayerCount
		{
			 get { } //Length: 132
		}

		public String[] MecanimLayerNames
		{
			 get { } //Length: 316
		}

		public MecanimTranslator() { }

		[CompilerGenerated]
		protected void add__OnClipApplied(OnClipAppliedDelegate value) { }

		public void add_OnClipApplied(OnClipAppliedDelegate value) { }

		private static float AnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed) { }

		public void Apply(Skeleton skeleton) { }

		private bool ApplyAnimation(Skeleton skeleton, AnimatorClipInfo info, AnimatorStateInfo stateInfo, int layerIndex, float layerWeight, MixBlend layerBlendMode, bool useCustomClipWeight = false, float customClipWeight = 1) { }

		private bool ApplyInterruptionAnimation(Skeleton skeleton, bool interpolateWeightTo1, AnimatorClipInfo info, AnimatorStateInfo stateInfo, int layerIndex, float layerWeight, MixBlend layerBlendMode, float interruptingClipTimeAddition, bool useCustomClipWeight = false, float customClipWeight = 1) { }

		private void ClearClipInfosForLayers() { }

		public Animator get_Animator() { }

		public int get_MecanimLayerCount() { }

		public String[] get_MecanimLayerNames() { }

		public KeyValuePair<Animation, Single> GetActiveAnimationAndTime(int layer) { }

		private Animation GetAnimation(AnimationClip clip) { }

		private void GetAnimatorClipInfos(int layer, out bool isInterruptionActive, out int clipInfoCount, out int nextClipInfoCount, out int interruptingClipInfoCount, out IList<AnimatorClipInfo>& clipInfo, out IList<AnimatorClipInfo>& nextClipInfo, out IList<AnimatorClipInfo>& interruptingClipInfo, out bool shallInterpolateWeightTo1) { }

		private void GetAnimatorStateInfos(int layer, out bool isInterruptionActive, out AnimatorStateInfo stateInfo, out AnimatorStateInfo nextStateInfo, out AnimatorStateInfo interruptingStateInfo, out float interruptingClipTimeAddition) { }

		private MixMode GetMixMode(int layer, MixBlend layerBlendMode) { }

		private void GetStateUpdatesFromAnimator(int layer) { }

		private void InitClipInfosForLayers() { }

		public void Initialize(Animator animator, SkeletonDataAsset skeletonDataAsset) { }

		protected void MatchWeights(ClipInfos clipInfos, bool hasNext, bool isInterruptionActive, int clipInfoCount, int nextClipInfoCount, int interruptingClipInfoCount, IList<AnimatorClipInfo> clipInfo, IList<AnimatorClipInfo> nextClipInfo, IList<AnimatorClipInfo> interruptingClipInfo) { }

		private void OnClipAppliedCallback(Animation clip, AnimatorStateInfo stateInfo, int layerIndex, float time, bool isLooping, float weight) { }

		[CompilerGenerated]
		protected void remove__OnClipApplied(OnClipAppliedDelegate value) { }

		public void remove_OnClipApplied(OnClipAppliedDelegate value) { }

		private static float ToSpineAnimationTime(float normalizedTime, float clipLength, bool loop, bool reversed) { }

	}

	[SerializeField]
	protected MecanimTranslator translator; //Field offset: 0x110
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

	public MecanimTranslator Translator
	{
		 get { } //Length: 8
	}

	public override UpdateTiming UpdateTiming
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SkeletonMecanim() { }

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

	public override void AfterAnimationApplied() { }

	public override void ApplyAnimation() { }

	public override void FixedUpdate() { }

	public MecanimTranslator get_Translator() { }

	public override UpdateTiming get_UpdateTiming() { }

	public virtual void Initialize(bool overwrite, bool quiet = false) { }

	public virtual void LateUpdate() { }

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

	public override void set_UpdateTiming(UpdateTiming value) { }

	public override void Update(float deltaTime) { }

	public override void Update() { }

	protected void UpdateAnimation(float deltaTime) { }

}

