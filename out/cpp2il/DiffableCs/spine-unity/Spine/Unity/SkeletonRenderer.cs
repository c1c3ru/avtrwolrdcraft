namespace Spine.Unity;

[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderer-Component")]
[RequireComponent(typeof(MeshRenderer))]
public class SkeletonRenderer : MonoBehaviour, ISkeletonComponent, ISpineComponent, IHasSkeletonDataAsset
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass104_0
	{
		public string startsWith; //Field offset: 0x10

		public <>c__DisplayClass104_0() { }

		internal bool <FindAndApplySeparatorSlots>b__0(string slotName) { }

	}

	internal sealed class InstructionDelegate : MulticastDelegate
	{

		public InstructionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonRendererInstruction instruction, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonRendererInstruction instruction) { }

	}

	internal sealed class SkeletonRendererDelegate : MulticastDelegate
	{

		public SkeletonRendererDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonRenderer skeletonRenderer, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonRenderer skeletonRenderer) { }

	}

	internal class SpriteMaskInteractionMaterials
	{
		public Material[] materialsMaskDisabled; //Field offset: 0x10
		public Material[] materialsInsideMask; //Field offset: 0x18
		public Material[] materialsOutsideMask; //Field offset: 0x20

		public bool AnyMaterialCreated
		{
			 get { } //Length: 76
		}

		public SpriteMaskInteractionMaterials() { }

		public bool get_AnyMaterialCreated() { }

	}

	public const CompareFunction STENCIL_COMP_MASKINTERACTION_VISIBLE_INSIDE = 4; //Field offset: 0x0
	public const CompareFunction STENCIL_COMP_MASKINTERACTION_VISIBLE_OUTSIDE = 5; //Field offset: 0x0
	public const CompareFunction STENCIL_COMP_MASKINTERACTION_NONE = 8; //Field offset: 0x0
	public static readonly int STENCIL_COMP_PARAM_ID; //Field offset: 0x0
	public static readonly int SUBMESH_DUMMY_PARAM_ID; //Field offset: 0x4
	public SkeletonDataAsset skeletonDataAsset; //Field offset: 0x20
	[SpineSkin(null, null, False, False, True, False)]
	public string initialSkinName; //Field offset: 0x28
	public bool initialFlipX; //Field offset: 0x30
	public bool initialFlipY; //Field offset: 0x31
	protected UpdateMode updateMode; //Field offset: 0x34
	public UpdateMode updateWhenInvisible; //Field offset: 0x38
	[FormerlySerializedAs("submeshSeparators")]
	[SerializeField]
	[SpineSlot(null, null, False, True, False)]
	protected String[] separatorSlotNames; //Field offset: 0x40
	public readonly List<Slot> separatorSlots; //Field offset: 0x48
	[Range(-0.1, 0)]
	public float zSpacing; //Field offset: 0x50
	public bool useClipping; //Field offset: 0x54
	public bool immutableTriangles; //Field offset: 0x55
	public bool pmaVertexColors; //Field offset: 0x56
	public bool clearStateOnDisable; //Field offset: 0x57
	public bool tintBlack; //Field offset: 0x58
	public bool singleSubmesh; //Field offset: 0x59
	public bool fixDrawOrder; //Field offset: 0x5A
	[FormerlySerializedAs("calculateNormals")]
	public bool addNormals; //Field offset: 0x5B
	public bool calculateTangents; //Field offset: 0x5C
	public SpriteMaskInteraction maskInteraction; //Field offset: 0x60
	public SpriteMaskInteractionMaterials maskMaterials; //Field offset: 0x68
	public bool disableRenderingOnOverride; //Field offset: 0x70
	[CompilerGenerated]
	private InstructionDelegate generateMeshOverride; //Field offset: 0x78
	[CompilerGenerated]
	private MeshGeneratorDelegate OnPostProcessVertices; //Field offset: 0x80
	private readonly Dictionary<Material, Material> customMaterialOverride; //Field offset: 0x88
	private readonly Dictionary<Slot, Material> customSlotMaterials; //Field offset: 0x90
	private readonly SkeletonRendererInstruction currentInstructions; //Field offset: 0x98
	private readonly MeshGenerator meshGenerator; //Field offset: 0xA0
	private readonly MeshRendererBuffers rendererBuffers; //Field offset: 0xA8
	private MeshRenderer meshRenderer; //Field offset: 0xB0
	private MeshFilter meshFilter; //Field offset: 0xB8
	public bool valid; //Field offset: 0xC0
	public Skeleton skeleton; //Field offset: 0xC8
	[SerializeField]
	protected Vector2 physicsPositionInheritanceFactor; //Field offset: 0xD0
	[SerializeField]
	protected float physicsRotationInheritanceFactor; //Field offset: 0xD8
	[SerializeField]
	protected Transform physicsMovementRelativeTo; //Field offset: 0xE0
	protected Vector3 lastPosition; //Field offset: 0xE8
	protected float lastRotation; //Field offset: 0xF4
	[CompilerGenerated]
	private SkeletonRendererDelegate OnRebuild; //Field offset: 0xF8
	[CompilerGenerated]
	private SkeletonRendererDelegate OnMeshAndMaterialsUpdated; //Field offset: 0x100
	private MaterialPropertyBlock reusedPropertyBlock; //Field offset: 0x108

	private event InstructionDelegate generateMeshOverride
	{
		[CompilerGenerated]
		private add { } //Length: 156
		[CompilerGenerated]
		private remove { } //Length: 156
	}

	public event InstructionDelegate GenerateMeshOverride
	{
		 add { } //Length: 188
		 remove { } //Length: 188
	}

	public event SkeletonRendererDelegate OnMeshAndMaterialsUpdated
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event MeshGeneratorDelegate OnPostProcessVertices
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event SkeletonRendererDelegate OnRebuild
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public SkeletonRendererInstruction CurrentInstructions
	{
		 get { } //Length: 8
	}

	public Dictionary<Material, Material> CustomMaterialOverride
	{
		 get { } //Length: 8
	}

	public Dictionary<Slot, Material> CustomSlotMaterials
	{
		 get { } //Length: 8
	}

	public Transform PhysicsMovementRelativeTo
	{
		 get { } //Length: 8
		 set { } //Length: 172
	}

	public Vector2 PhysicsPositionInheritanceFactor
	{
		 get { } //Length: 8
		 set { } //Length: 188
	}

	public float PhysicsRotationInheritanceFactor
	{
		 get { } //Length: 8
		 set { } //Length: 64
	}

	public String[] SeparatorSlotNames
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override Skeleton Skeleton
	{
		 get { } //Length: 40
	}

	public SkeletonClipping SkeletonClipping
	{
		 get { } //Length: 28
	}

	public override SkeletonDataAsset SkeletonDataAsset
	{
		 get { } //Length: 8
	}

	public UpdateMode UpdateMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static SkeletonRenderer() { }

	public SkeletonRenderer() { }

	[CompilerGenerated]
	private void add_generateMeshOverride(InstructionDelegate value) { }

	public void add_GenerateMeshOverride(InstructionDelegate value) { }

	[CompilerGenerated]
	public void add_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public void add_OnPostProcessVertices(MeshGeneratorDelegate value) { }

	[CompilerGenerated]
	public void add_OnRebuild(SkeletonRendererDelegate value) { }

	public static T AddSpineComponent(GameObject gameObject, SkeletonDataAsset skeletonDataAsset, bool quiet = false) { }

	public override void ApplyTransformMovementToPhysics() { }

	private void AssignSpriteMaskMaterials() { }

	public override void Awake() { }

	public override void ClearState() { }

	public void EnsureMeshGeneratorCapacity(int minimumVertexCount) { }

	public void FindAndApplySeparatorSlots(Func<String, Boolean> slotNamePredicate, bool clearExistingSeparators = true, bool updateStringArray = false) { }

	public void FindAndApplySeparatorSlots(string startsWith, bool clearExistingSeparators = true, bool updateStringArray = false) { }

	public SkeletonRendererInstruction get_CurrentInstructions() { }

	public Dictionary<Material, Material> get_CustomMaterialOverride() { }

	public Dictionary<Slot, Material> get_CustomSlotMaterials() { }

	public Transform get_PhysicsMovementRelativeTo() { }

	public Vector2 get_PhysicsPositionInheritanceFactor() { }

	public float get_PhysicsRotationInheritanceFactor() { }

	public String[] get_SeparatorSlotNames() { }

	public override Skeleton get_Skeleton() { }

	public SkeletonClipping get_SkeletonClipping() { }

	public override SkeletonDataAsset get_SkeletonDataAsset() { }

	public UpdateMode get_UpdateMode() { }

	protected Vector3 GetPhysicsTransformPosition() { }

	protected float GetPhysicsTransformRotation() { }

	private void HandleOnDemandLoading() { }

	public override void Initialize(bool overwrite, bool quiet = false) { }

	private bool InitSpriteMaskMaterialsForMaskType(CompareFunction maskFunction, ref Material[] materialsToFill) { }

	private bool InitSpriteMaskMaterialsInsideMask() { }

	private bool InitSpriteMaskMaterialsOutsideMask() { }

	public override void LateUpdate() { }

	public override void LateUpdateMesh() { }

	public static T NewSpineGameObject(SkeletonDataAsset skeletonDataAsset, bool quiet = false) { }

	public void OnBecameInvisible() { }

	public override void OnBecameVisible() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	public void ReapplySeparatorSlotNames() { }

	[CompilerGenerated]
	private void remove_generateMeshOverride(InstructionDelegate value) { }

	public void remove_GenerateMeshOverride(InstructionDelegate value) { }

	[CompilerGenerated]
	public void remove_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public void remove_OnPostProcessVertices(MeshGeneratorDelegate value) { }

	[CompilerGenerated]
	public void remove_OnRebuild(SkeletonRendererDelegate value) { }

	public void ResetLastPosition() { }

	public void ResetLastPositionAndRotation() { }

	public void ResetLastRotation() { }

	public void set_PhysicsMovementRelativeTo(Transform value) { }

	public void set_PhysicsPositionInheritanceFactor(Vector2 value) { }

	public void set_PhysicsRotationInheritanceFactor(float value) { }

	public void set_SeparatorSlotNames(String[] value) { }

	public void set_UpdateMode(UpdateMode value) { }

	private void SetMaterialSettingsToFixDrawOrder() { }

	public void SetMeshSettings(Settings settings) { }

	protected override void UpdateWorldTransform(Physics physics) { }

}

