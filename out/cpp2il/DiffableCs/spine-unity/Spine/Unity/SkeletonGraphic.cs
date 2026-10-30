namespace Spine.Unity;

[AddComponentMenu("Spine/SkeletonGraphic (Unity UI Canvas)")]
[DisallowMultipleComponent]
[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonGraphic-Component")]
[RequireComponent(typeof(CanvasRenderer), typeof(RectTransform))]
public class SkeletonGraphic : MaskableGraphic, ISkeletonComponent, ISpineComponent, IAnimationStateComponent, ISkeletonAnimation, IHasSkeletonDataAsset
{
	internal sealed class InstructionDelegate : MulticastDelegate
	{

		public InstructionDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonRendererInstruction instruction, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonRendererInstruction instruction) { }

	}

	internal enum LayoutMode
	{
		None = 0,
		WidthControlsHeight = 1,
		HeightControlsWidth = 2,
		FitInParent = 3,
		EnvelopeParent = 4,
	}

	internal sealed class MeshAssignmentDelegateMultiple : MulticastDelegate
	{

		public MeshAssignmentDelegateMultiple(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(int meshCount, Mesh[] meshes, Material[] graphicMaterials, Texture[] textures, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(int meshCount, Mesh[] meshes, Material[] graphicMaterials, Texture[] textures) { }

	}

	internal sealed class MeshAssignmentDelegateSingle : MulticastDelegate
	{

		public MeshAssignmentDelegateSingle(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(Mesh mesh, Material graphicMaterial, Texture texture, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(Mesh mesh, Material graphicMaterial, Texture texture) { }

	}

	internal sealed class SkeletonRendererDelegate : MulticastDelegate
	{

		public SkeletonRendererDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(SkeletonGraphic skeletonGraphic, AsyncCallback callback, object object) { }

		public override void EndInvoke(IAsyncResult result) { }

		public override void Invoke(SkeletonGraphic skeletonGraphic) { }

	}

	protected const bool EditReferenceRect = False; //Field offset: 0x0
	public const string SeparatorPartGameObjectName = "Part"; //Field offset: 0x0
	public SkeletonDataAsset skeletonDataAsset; //Field offset: 0xD8
	public Material additiveMaterial; //Field offset: 0xE0
	public Material multiplyMaterial; //Field offset: 0xE8
	public Material screenMaterial; //Field offset: 0xF0
	[FormerlySerializedAs("m_Color")]
	[SerializeField]
	protected Color m_SkeletonColor; //Field offset: 0xF8
	[SpineSkin(null, "skeletonDataAsset", False, False, True, False)]
	public string initialSkinName; //Field offset: 0x108
	public bool initialFlipX; //Field offset: 0x110
	public bool initialFlipY; //Field offset: 0x111
	[SpineAnimation(null, "skeletonDataAsset", True, False, False)]
	public string startingAnimation; //Field offset: 0x118
	public bool startingLoop; //Field offset: 0x120
	public float timeScale; //Field offset: 0x124
	public bool freeze; //Field offset: 0x128
	protected float meshScale; //Field offset: 0x12C
	protected Vector2 meshOffset; //Field offset: 0x130
	public LayoutMode layoutScaleMode; //Field offset: 0x138
	[SerializeField]
	protected Vector2 referenceSize; //Field offset: 0x13C
	[SerializeField]
	protected Vector2 pivotOffset; //Field offset: 0x144
	[SerializeField]
	protected float referenceScale; //Field offset: 0x14C
	[SerializeField]
	protected float layoutScale; //Field offset: 0x150
	protected UpdateMode updateMode; //Field offset: 0x154
	public UpdateMode updateWhenInvisible; //Field offset: 0x158
	public bool allowMultipleCanvasRenderers; //Field offset: 0x15C
	public List<CanvasRenderer> canvasRenderers; //Field offset: 0x160
	protected List<SkeletonSubmeshGraphic> submeshGraphics; //Field offset: 0x168
	protected int usedRenderersCount; //Field offset: 0x170
	[SerializeField]
	[SpineSlot(null, null, False, True, False)]
	protected String[] separatorSlotNames; //Field offset: 0x178
	public readonly List<Slot> separatorSlots; //Field offset: 0x180
	public bool enableSeparatorSlots; //Field offset: 0x188
	[SerializeField]
	protected List<Transform> separatorParts; //Field offset: 0x190
	public bool updateSeparatorPartLocation; //Field offset: 0x198
	public bool updateSeparatorPartScale; //Field offset: 0x199
	private bool wasUpdatedAfterInit; //Field offset: 0x19A
	private Texture baseTexture; //Field offset: 0x1A0
	public bool disableMeshAssignmentOnOverride; //Field offset: 0x1A8
	[CompilerGenerated]
	private MeshAssignmentDelegateSingle assignMeshOverrideSingle; //Field offset: 0x1B0
	[CompilerGenerated]
	private MeshAssignmentDelegateMultiple assignMeshOverrideMultiple; //Field offset: 0x1B8
	private readonly Dictionary<Texture, Texture> customTextureOverride; //Field offset: 0x1C0
	private readonly Dictionary<Texture, Material> customMaterialOverride; //Field offset: 0x1C8
	private Texture overrideTexture; //Field offset: 0x1D0
	protected Skeleton skeleton; //Field offset: 0x1D8
	[CompilerGenerated]
	private SkeletonRendererDelegate OnRebuild; //Field offset: 0x1E0
	[CompilerGenerated]
	private InstructionDelegate OnInstructionsPrepared; //Field offset: 0x1E8
	[CompilerGenerated]
	private SkeletonRendererDelegate OnMeshAndMaterialsUpdated; //Field offset: 0x1F0
	protected AnimationState state; //Field offset: 0x1F8
	[SerializeField]
	protected Vector2 physicsPositionInheritanceFactor; //Field offset: 0x200
	[SerializeField]
	protected float physicsRotationInheritanceFactor; //Field offset: 0x208
	[SerializeField]
	protected Transform physicsMovementRelativeTo; //Field offset: 0x210
	protected Vector2 lastPosition; //Field offset: 0x218
	protected float lastRotation; //Field offset: 0x220
	[SerializeField]
	protected MeshGenerator meshGenerator; //Field offset: 0x228
	private DoubleBuffered<SmartMesh> meshBuffers; //Field offset: 0x230
	private SkeletonRendererInstruction currentInstructions; //Field offset: 0x238
	private readonly ExposedList<Mesh> meshes; //Field offset: 0x240
	private readonly ExposedList<Material> usedMaterials; //Field offset: 0x248
	private readonly ExposedList<Texture> usedTextures; //Field offset: 0x250
	[CompilerGenerated]
	private ISkeletonAnimationDelegate OnAnimationRebuild; //Field offset: 0x258
	[CompilerGenerated]
	private UpdateBonesDelegate BeforeApply; //Field offset: 0x260
	[CompilerGenerated]
	private UpdateBonesDelegate UpdateLocal; //Field offset: 0x268
	[CompilerGenerated]
	private UpdateBonesDelegate UpdateWorld; //Field offset: 0x270
	[CompilerGenerated]
	private UpdateBonesDelegate UpdateComplete; //Field offset: 0x278
	[SerializeField]
	protected UpdateTiming updateTiming; //Field offset: 0x280
	[SerializeField]
	protected bool unscaledTime; //Field offset: 0x284
	[CompilerGenerated]
	private MeshGeneratorDelegate OnPostProcessVertices; //Field offset: 0x288

	private event MeshAssignmentDelegateMultiple assignMeshOverrideMultiple
	{
		[CompilerGenerated]
		private add { } //Length: 160
		[CompilerGenerated]
		private remove { } //Length: 160
	}

	public event MeshAssignmentDelegateMultiple AssignMeshOverrideMultipleRenderers
	{
		 add { } //Length: 52
		 remove { } //Length: 52
	}

	private event MeshAssignmentDelegateSingle assignMeshOverrideSingle
	{
		[CompilerGenerated]
		private add { } //Length: 160
		[CompilerGenerated]
		private remove { } //Length: 160
	}

	public event MeshAssignmentDelegateSingle AssignMeshOverrideSingleRenderer
	{
		 add { } //Length: 52
		 remove { } //Length: 52
	}

	public event UpdateBonesDelegate BeforeApply
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public override event ISkeletonAnimationDelegate OnAnimationRebuild
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event InstructionDelegate OnInstructionsPrepared
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
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
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public event SkeletonRendererDelegate OnRebuild
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public override event UpdateBonesDelegate UpdateComplete
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public override event UpdateBonesDelegate UpdateLocal
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public override event UpdateBonesDelegate UpdateWorld
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public override AnimationState AnimationState
	{
		 get { } //Length: 28
	}

	public virtual Color color
	{
		 get { } //Length: 16
		 set { } //Length: 16
	}

	public Dictionary<Texture, Material> CustomMaterialOverride
	{
		 get { } //Length: 8
	}

	public Dictionary<Texture, Texture> CustomTextureOverride
	{
		 get { } //Length: 8
	}

	public bool IsValid
	{
		 get { } //Length: 16
	}

	public virtual Texture mainTexture
	{
		 get { } //Length: 120
	}

	public ExposedList<Material> MaterialsMultipleCanvasRenderers
	{
		 get { } //Length: 8
	}

	public ExposedList<Mesh> MeshesMultipleCanvasRenderers
	{
		 get { } //Length: 8
	}

	public MeshGenerator MeshGenerator
	{
		 get { } //Length: 8
	}

	public Vector2 MeshOffset
	{
		 get { } //Length: 12
	}

	public float MeshScale
	{
		 get { } //Length: 8
	}

	public Texture OverrideTexture
	{
		 get { } //Length: 8
		 set { } //Length: 92
	}

	public Transform PhysicsMovementRelativeTo
	{
		 get { } //Length: 8
		 set { } //Length: 168
	}

	public Vector2 PhysicsPositionInheritanceFactor
	{
		 get { } //Length: 12
		 set { } //Length: 196
	}

	public float PhysicsRotationInheritanceFactor
	{
		 get { } //Length: 8
		 set { } //Length: 64
	}

	public List<Transform> SeparatorParts
	{
		 get { } //Length: 8
	}

	public override Skeleton Skeleton
	{
		 get { } //Length: 28
		 set { } //Length: 16
	}

	public SkeletonClipping SkeletonClipping
	{
		 get { } //Length: 28
	}

	public SkeletonData SkeletonData
	{
		 get { } //Length: 44
	}

	public override SkeletonDataAsset SkeletonDataAsset
	{
		 get { } //Length: 8
	}

	public ExposedList<Texture> TexturesMultipleCanvasRenderers
	{
		 get { } //Length: 8
	}

	public override bool UnscaledTime
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public UpdateMode UpdateMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override UpdateTiming UpdateTiming
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SkeletonGraphic() { }

	[CompilerGenerated]
	private void add_assignMeshOverrideMultiple(MeshAssignmentDelegateMultiple value) { }

	public void add_AssignMeshOverrideMultipleRenderers(MeshAssignmentDelegateMultiple value) { }

	[CompilerGenerated]
	private void add_assignMeshOverrideSingle(MeshAssignmentDelegateSingle value) { }

	public void add_AssignMeshOverrideSingleRenderer(MeshAssignmentDelegateSingle value) { }

	[CompilerGenerated]
	public void add_BeforeApply(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void add_OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	[CompilerGenerated]
	public void add_OnInstructionsPrepared(InstructionDelegate value) { }

	[CompilerGenerated]
	public void add_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public void add_OnPostProcessVertices(MeshGeneratorDelegate value) { }

	[CompilerGenerated]
	public void add_OnRebuild(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public override void add_UpdateComplete(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void add_UpdateLocal(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void add_UpdateWorld(UpdateBonesDelegate value) { }

	public static SkeletonGraphic AddSkeletonGraphicComponent(GameObject gameObject, SkeletonDataAsset skeletonDataAsset, Material material) { }

	public override void AfterAnimationApplied() { }

	public override void ApplyAnimation() { }

	public override void ApplyTransformMovementToPhysics() { }

	protected virtual void Awake() { }

	public void Clear() { }

	protected void DestroyMeshes() { }

	protected void DisableUnusedCanvasRenderers(int usedCount, bool isInRebuild = false) { }

	protected void DisposeMeshBuffers() { }

	protected void EnsureCanvasRendererCount(int targetCount) { }

	protected void EnsureMeshesCount(int targetCount) { }

	protected void EnsureSeparatorPartCount() { }

	protected void EnsureUsedTexturesAndMaterialsCount(int targetCount) { }

	protected override void FixedUpdate() { }

	public override AnimationState get_AnimationState() { }

	public virtual Color get_color() { }

	public Dictionary<Texture, Material> get_CustomMaterialOverride() { }

	public Dictionary<Texture, Texture> get_CustomTextureOverride() { }

	public bool get_IsValid() { }

	public virtual Texture get_mainTexture() { }

	public ExposedList<Material> get_MaterialsMultipleCanvasRenderers() { }

	public ExposedList<Mesh> get_MeshesMultipleCanvasRenderers() { }

	public MeshGenerator get_MeshGenerator() { }

	public Vector2 get_MeshOffset() { }

	public float get_MeshScale() { }

	public Texture get_OverrideTexture() { }

	public Transform get_PhysicsMovementRelativeTo() { }

	public Vector2 get_PhysicsPositionInheritanceFactor() { }

	public float get_PhysicsRotationInheritanceFactor() { }

	public List<Transform> get_SeparatorParts() { }

	public override Skeleton get_Skeleton() { }

	public SkeletonClipping get_SkeletonClipping() { }

	public SkeletonData get_SkeletonData() { }

	public override SkeletonDataAsset get_SkeletonDataAsset() { }

	public ExposedList<Texture> get_TexturesMultipleCanvasRenderers() { }

	public override bool get_UnscaledTime() { }

	public UpdateMode get_UpdateMode() { }

	public override UpdateTiming get_UpdateTiming() { }

	private Vector2 GetCurrentRectSize() { }

	protected LayoutMode GetEffectiveLayoutMode(LayoutMode mode) { }

	public Mesh GetLastMesh() { }

	protected float GetLayoutScale(LayoutMode mode) { }

	protected Vector2 GetPhysicsTransformPosition() { }

	protected float GetPhysicsTransformRotation() { }

	private void HandleOnDemandLoading() { }

	public bool HasMultipleSubmeshInstructions() { }

	public void Initialize(bool overwrite) { }

	protected void InitMeshBuffers() { }

	public void LateUpdate() { }

	protected bool MatchRectTransformMultipleRenderers() { }

	protected bool MatchRectTransformSingleRenderer() { }

	public bool MatchRectTransformWithBounds() { }

	public static SkeletonGraphic NewSkeletonGraphicGameObject(SkeletonDataAsset skeletonDataAsset, Transform parent, Material material) { }

	public void OnBecameInvisible() { }

	public void OnBecameVisible() { }

	protected void OnCullStateChanged(bool culled) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	public void PrepareInstructionsAndRenderers(bool isInRebuild = false) { }

	protected void PrepareRendererGameObjects(SkeletonRendererInstruction currentInstructions, bool isInRebuild = false) { }

	public void ReapplySeparatorSlotNames() { }

	public virtual void Rebuild(CanvasUpdate update) { }

	[CompilerGenerated]
	private void remove_assignMeshOverrideMultiple(MeshAssignmentDelegateMultiple value) { }

	public void remove_AssignMeshOverrideMultipleRenderers(MeshAssignmentDelegateMultiple value) { }

	[CompilerGenerated]
	private void remove_assignMeshOverrideSingle(MeshAssignmentDelegateSingle value) { }

	public void remove_AssignMeshOverrideSingleRenderer(MeshAssignmentDelegateSingle value) { }

	[CompilerGenerated]
	public void remove_BeforeApply(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void remove_OnAnimationRebuild(ISkeletonAnimationDelegate value) { }

	[CompilerGenerated]
	public void remove_OnInstructionsPrepared(InstructionDelegate value) { }

	[CompilerGenerated]
	public void remove_OnMeshAndMaterialsUpdated(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public void remove_OnPostProcessVertices(MeshGeneratorDelegate value) { }

	[CompilerGenerated]
	public void remove_OnRebuild(SkeletonRendererDelegate value) { }

	[CompilerGenerated]
	public override void remove_UpdateComplete(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void remove_UpdateLocal(UpdateBonesDelegate value) { }

	[CompilerGenerated]
	public override void remove_UpdateWorld(UpdateBonesDelegate value) { }

	public void ResetLastPosition() { }

	public void ResetLastPositionAndRotation() { }

	public void ResetLastRotation() { }

	public virtual void set_color(Color value) { }

	public void set_OverrideTexture(Texture value) { }

	public void set_PhysicsMovementRelativeTo(Transform value) { }

	public void set_PhysicsPositionInheritanceFactor(Vector2 value) { }

	public void set_PhysicsRotationInheritanceFactor(float value) { }

	public void set_Skeleton(Skeleton value) { }

	public override void set_UnscaledTime(bool value) { }

	public void set_UpdateMode(UpdateMode value) { }

	public override void set_UpdateTiming(UpdateTiming value) { }

	private void SetRectTransformBounds(Bounds combinedBounds) { }

	public static void SetRectTransformSize(Graphic target, Vector2 size) { }

	public static void SetRectTransformSize(RectTransform targetRectTransform, Vector2 size) { }

	public void SetScaledPivotOffset(Vector2 pivotOffsetScaled) { }

	protected void SyncSubmeshGraphicsWithCanvasRenderers() { }

	public void TrimRenderers() { }

	public override void Update(float deltaTime) { }

	public override void Update() { }

	protected void UpdateAnimationStatus(float deltaTime) { }

	protected void UpdateMaterialsMultipleCanvasRenderers(SkeletonRendererInstruction currentInstructions) { }

	public void UpdateMesh() { }

	protected void UpdateMeshMultipleCanvasRenderers(SkeletonRendererInstruction currentInstructions) { }

	protected void UpdateMeshSingleCanvasRenderer(SkeletonRendererInstruction currentInstructions) { }

	public void UpdateMeshToInstructions() { }

	protected void UpdateSeparatorPartParents() { }

	protected void UpdateWorldTransform(Physics physics) { }

}

