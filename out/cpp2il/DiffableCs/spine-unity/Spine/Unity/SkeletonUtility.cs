namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtility")]
[RequireComponent(typeof(ISkeletonAnimation))]
public sealed class SkeletonUtility : MonoBehaviour
{
	internal sealed class SkeletonUtilityDelegate : MulticastDelegate
	{

		public SkeletonUtilityDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke() { }

	}

	[CompilerGenerated]
	private SkeletonUtilityDelegate OnReset; //Field offset: 0x20
	public Transform boneRoot; //Field offset: 0x28
	public bool flipBy180DegreeRotation; //Field offset: 0x30
	[HideInInspector]
	public SkeletonRenderer skeletonRenderer; //Field offset: 0x38
	[HideInInspector]
	public SkeletonGraphic skeletonGraphic; //Field offset: 0x40
	public ISkeletonAnimation skeletonAnimation; //Field offset: 0x48
	private ISkeletonComponent skeletonComponent; //Field offset: 0x50
	public List<SkeletonUtilityBone> boneComponents; //Field offset: 0x58
	public List<SkeletonUtilityConstraint> constraintComponents; //Field offset: 0x60
	private float positionScale; //Field offset: 0x68
	private float lastPositionScale; //Field offset: 0x6C
	private Vector2 positionOffset; //Field offset: 0x70
	private bool hasOverrideBones; //Field offset: 0x78
	private bool hasConstraints; //Field offset: 0x79
	private bool needToReprocessBones; //Field offset: 0x7A

	public event SkeletonUtilityDelegate OnReset
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public bool IsValid
	{
		 get { } //Length: 200
	}

	public Vector2 PositionOffset
	{
		 get { } //Length: 8
	}

	public float PositionScale
	{
		 get { } //Length: 8
	}

	public Skeleton Skeleton
	{
		 get { } //Length: 188
	}

	public ISkeletonComponent SkeletonComponent
	{
		 get { } //Length: 228
	}

	public SkeletonUtility() { }

	[CompilerGenerated]
	public void add_OnReset(SkeletonUtilityDelegate value) { }

	public static Rigidbody2D AddBoneRigidbody2D(GameObject gameObject, bool isKinematic = true, float gravityScale = 0) { }

	public static PolygonCollider2D AddBoundingBoxAsComponent(BoundingBoxAttachment box, Slot slot, GameObject gameObject, bool isTrigger = true) { }

	public static PolygonCollider2D AddBoundingBoxGameObject(Skeleton skeleton, string skinName, string slotName, string attachmentName, Transform parent, bool isTrigger = true) { }

	public static PolygonCollider2D AddBoundingBoxGameObject(string name, BoundingBoxAttachment box, Slot slot, Transform parent, bool isTrigger = true) { }

	public void CollectBones() { }

	public bool get_IsValid() { }

	public Vector2 get_PositionOffset() { }

	public float get_PositionScale() { }

	public Skeleton get_Skeleton() { }

	public ISkeletonComponent get_SkeletonComponent() { }

	public Transform GetBoneRoot() { }

	public static Bounds GetBoundingBoxBounds(BoundingBoxAttachment boundingBox, float depth = 0) { }

	private void HandleRendererReset(SkeletonRenderer r) { }

	private void HandleRendererReset(SkeletonGraphic g) { }

	private void OnDisable() { }

	private void OnEnable() { }

	public void RegisterBone(SkeletonUtilityBone bone) { }

	public void RegisterConstraint(SkeletonUtilityConstraint constraint) { }

	[CompilerGenerated]
	public void remove_OnReset(SkeletonUtilityDelegate value) { }

	private void ResubscribeDependentEvents() { }

	public void ResubscribeEvents() { }

	private void ResubscribeIndependentEvents() { }

	public static void SetColliderPointsLocal(PolygonCollider2D collider, Slot slot, BoundingBoxAttachment box, float scale = 1) { }

	public GameObject SpawnBone(Bone bone, Transform parent, Mode mode, bool pos, bool rot, bool sca) { }

	public GameObject SpawnBoneRecursively(Bone bone, Transform parent, Mode mode, bool pos, bool rot, bool sca) { }

	public GameObject SpawnHierarchy(Mode mode, bool pos, bool rot, bool sca) { }

	public GameObject SpawnRoot(Mode mode, bool pos, bool rot, bool sca) { }

	private void Start() { }

	public void UnregisterBone(SkeletonUtilityBone bone) { }

	public void UnregisterConstraint(SkeletonUtilityConstraint constraint) { }

	private void Update() { }

	private void UpdateAllBones(UpdatePhase phase) { }

	private void UpdateComplete(ISkeletonAnimation anim) { }

	private void UpdateLocal(ISkeletonAnimation anim) { }

	private void UpdateToMeshScaleAndOffset(MeshGeneratorBuffers ignoredParameter) { }

	private void UpdateWorld(ISkeletonAnimation anim) { }

}

