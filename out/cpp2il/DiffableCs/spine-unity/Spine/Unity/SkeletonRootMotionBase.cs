namespace Spine.Unity;

[DefaultExecutionOrder(1)]
public abstract class SkeletonRootMotionBase : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass80_0
	{
		public int constraintIndex; //Field offset: 0x10

		public <>c__DisplayClass80_0() { }

		internal bool <GetConstraintLastPosIndex>b__0(int addedIndex) { }

	}

	internal sealed class RootMotionDelegate : MulticastDelegate
	{

		public RootMotionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonRootMotionBase component, Vector2 translation, float rotation, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonRootMotionBase component, Vector2 translation, float rotation) { }

	}

	internal struct RootMotionInfo
	{
		public Vector2 start; //Field offset: 0x0
		public Vector2 current; //Field offset: 0x8
		public Vector2 mid; //Field offset: 0x10
		public Vector2 end; //Field offset: 0x18
		public bool timeIsPastMid; //Field offset: 0x20

	}

	[SpineBone(null, null, True, False)]
	public string rootMotionBoneName; //Field offset: 0x20
	public bool transformPositionX; //Field offset: 0x28
	public bool transformPositionY; //Field offset: 0x29
	public bool transformRotation; //Field offset: 0x2A
	public float rootMotionScaleX; //Field offset: 0x2C
	public float rootMotionScaleY; //Field offset: 0x30
	public float rootMotionScaleRotation; //Field offset: 0x34
	public float rootMotionTranslateXPerY; //Field offset: 0x38
	public float rootMotionTranslateYPerX; //Field offset: 0x3C
	[Header("Optional")]
	public Rigidbody2D rigidBody2D; //Field offset: 0x40
	public bool applyRigidbody2DGravity; //Field offset: 0x48
	public Rigidbody rigidBody; //Field offset: 0x50
	[CompilerGenerated]
	private RootMotionDelegate ProcessRootMotionOverride; //Field offset: 0x58
	[CompilerGenerated]
	private RootMotionDelegate PhysicsUpdateRootMotionOverride; //Field offset: 0x60
	public bool disableOnOverride; //Field offset: 0x68
	protected ISkeletonComponent skeletonComponent; //Field offset: 0x70
	protected Bone rootMotionBone; //Field offset: 0x78
	protected int rootMotionBoneIndex; //Field offset: 0x80
	protected List<Int32> transformConstraintIndices; //Field offset: 0x88
	protected List<Vector2> transformConstraintLastPos; //Field offset: 0x90
	protected List<Single> transformConstraintLastRotation; //Field offset: 0x98
	protected List<Bone> topLevelBones; //Field offset: 0xA0
	protected Vector2 initialOffset; //Field offset: 0xA8
	protected bool accumulatedUntilFixedUpdate; //Field offset: 0xB0
	protected Vector2 tempSkeletonDisplacement; //Field offset: 0xB4
	protected Vector3 rigidbodyDisplacement; //Field offset: 0xBC
	protected Vector3 previousRigidbodyRootMotion; //Field offset: 0xC8
	protected Vector2 additionalRigidbody2DMovement; //Field offset: 0xD4
	protected Quaternion rigidbodyLocalRotation; //Field offset: 0xDC
	protected float rigidbody2DRotation; //Field offset: 0xEC
	protected float initialOffsetRotation; //Field offset: 0xF0
	protected float tempSkeletonRotation; //Field offset: 0xF4

	public event RootMotionDelegate PhysicsUpdateRootMotionOverride
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event RootMotionDelegate ProcessRootMotionOverride
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public Vector2 AdditionalRigidbody2DMovement
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	protected override float AdditionalScale
	{
		 get { } //Length: 8
	}

	public Vector2 PreviousRigidbodyRootMotion2D
	{
		 get { } //Length: 8
	}

	public Vector3 PreviousRigidbodyRootMotion3D
	{
		 get { } //Length: 12
	}

	public Bone RootMotionBone
	{
		 get { } //Length: 8
	}

	protected bool SkeletonAnimationUsesFixedUpdate
	{
		 get { } //Length: 184
	}

	public ISkeletonAnimation TargetSkeletonAnimationComponent
	{
		 get { } //Length: 76
	}

	public ISkeletonComponent TargetSkeletonComponent
	{
		 get { } //Length: 108
	}

	public bool UsesRigidbody
	{
		 get { } //Length: 152
	}

	protected SkeletonRootMotionBase() { }

	[CompilerGenerated]
	public void add_PhysicsUpdateRootMotionOverride(RootMotionDelegate value) { }

	[CompilerGenerated]
	public void add_ProcessRootMotionOverride(RootMotionDelegate value) { }

	public void AdjustRootMotionToDistance(Vector2 distanceToTarget, int trackIndex = 0, bool adjustX = true, bool adjustY = true, float minX = 0, float maxX = 3,4028235E+38, float minY = 0, float maxY = 3,4028235E+38, bool allowXTranslation = false, bool allowYTranslation = false) { }

	private void ApplyConstraintToPos(Animation animation, TransformConstraint constraint, int constraintIndex, float time, bool useLastConstraintPos, ref Vector2 pos) { }

	private void ApplyConstraintToRotation(Animation animation, TransformConstraint constraint, int constraintIndex, float time, bool useLastConstraintRotation, ref float rotation) { }

	private void ApplyRootMotion(Vector2 skeletonTranslationDelta, float skeletonRotationDelta, Vector2 parentBoneScale, bool skeletonAnimationUsesFixedUpdate) { }

	private void ApplyTransformConstraints() { }

	protected abstract Vector2 CalculateAnimationsMovementDelta() { }

	protected override float CalculateAnimationsRotationDelta() { }

	private void ClearEffectiveBoneOffsets(Vector2 parentBoneScale) { }

	private void ClearRigidbodyTempMovement() { }

	protected void FindRigidbodyComponent() { }

	private void FindTransformConstraintsAffectingBone() { }

	protected override void FixedUpdate() { }

	private void GatherTopLevelBones() { }

	public Vector2 get_AdditionalRigidbody2DMovement() { }

	protected override float get_AdditionalScale() { }

	public Vector2 get_PreviousRigidbodyRootMotion2D() { }

	public Vector3 get_PreviousRigidbodyRootMotion3D() { }

	public Bone get_RootMotionBone() { }

	protected bool get_SkeletonAnimationUsesFixedUpdate() { }

	public ISkeletonAnimation get_TargetSkeletonAnimationComponent() { }

	public ISkeletonComponent get_TargetSkeletonComponent() { }

	public bool get_UsesRigidbody() { }

	public Vector2 GetAnimationRootMotion(Animation animation) { }

	public Vector2 GetAnimationRootMotion(float startTime, float endTime, Animation animation) { }

	public RootMotionInfo GetAnimationRootMotionInfo(Animation animation, float currentTime) { }

	public float GetAnimationRootMotionRotation(Animation animation) { }

	public float GetAnimationRootMotionRotation(float startTime, float endTime, Animation animation) { }

	private int GetConstraintLastPosIndex(int constraintIndex) { }

	public abstract Vector2 GetRemainingRootMotion(int trackIndex = 0) { }

	public abstract RootMotionInfo GetRootMotionInfo(int trackIndex = 0) { }

	private Vector2 GetScaleAffectingRootMotion(out Vector2 parentBoneScale) { }

	private Vector2 GetScaleAffectingRootMotion() { }

	private Vector2 GetSkeletonSpaceMovementDelta(Vector2 boneLocalDelta, out Vector2 parentBoneScale, out Vector2 totalScale) { }

	private float GetSkeletonSpaceRotationDelta(float boneLocalDelta, Vector2 totalScaleAffectingRootMotion) { }

	private Vector2 GetTimelineMovementDelta(float startTime, float endTime, TranslateXTimeline xTimeline, TranslateYTimeline yTimeline, Animation animation) { }

	private void HandleUpdateLocal(ISkeletonAnimation animatedSkeletonComponent) { }

	public override void Initialize() { }

	protected void InitializeOnRebuild(ISkeletonAnimation animatedSkeletonComponent) { }

	protected override void OnDisable() { }

	protected override void PhysicsUpdate(bool skeletonAnimationUsesFixedUpdate) { }

	[CompilerGenerated]
	public void remove_PhysicsUpdateRootMotionOverride(RootMotionDelegate value) { }

	[CompilerGenerated]
	public void remove_ProcessRootMotionOverride(RootMotionDelegate value) { }

	protected override void Reset() { }

	public void set_AdditionalRigidbody2DMovement(Vector2 value) { }

	private void SetEffectiveBoneOffsetsTo(Vector2 displacementSkeletonSpace, float rotationSkeletonSpace, Vector2 parentBoneScale) { }

	public void SetRootMotionBone(string name) { }

	protected override void Start() { }

	private void UpdateLastConstraintPos(TransformConstraint[] transformConstraintsItems) { }

	private void UpdateLastConstraintRotation(TransformConstraint[] transformConstraintsItems) { }

}

