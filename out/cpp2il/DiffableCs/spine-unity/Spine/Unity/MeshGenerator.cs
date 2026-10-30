namespace Spine.Unity;

public class MeshGenerator
{
	internal struct Settings
	{
		public bool useClipping; //Field offset: 0x0
		[Range(-0.1, 0)]
		public float zSpacing; //Field offset: 0x4
		public bool tintBlack; //Field offset: 0x8
		[FormerlySerializedAs("canvasGroupTintBlack")]
		[Tooltip("Enable when using SkeletonGraphic under a CanvasGroup. When enabled, PMA Vertex Color alpha value is stored at uv2.g instead of color.a to capture CanvasGroup modifying color.a. Also helps to detect correct parameter setting combinations.")]
		public bool canvasGroupCompatible; //Field offset: 0x9
		public bool pmaVertexColors; //Field offset: 0xA
		public bool addNormals; //Field offset: 0xB
		public bool calculateTangents; //Field offset: 0xC
		public bool immutableTriangles; //Field offset: 0xD

		public static Settings Default
		{
			 get { } //Length: 12
		}

		public static Settings get_Default() { }

	}

	private const float BoundsMinDefault = ∞; //Field offset: 0x0
	private const float BoundsMaxDefault = -∞; //Field offset: 0x0
	private static List<Vector3> AttachmentVerts; //Field offset: 0x0
	private static List<Vector2> AttachmentUVs; //Field offset: 0x8
	private static List<Color32> AttachmentColors32; //Field offset: 0x10
	private static List<Int32> AttachmentIndices; //Field offset: 0x18
	public Settings settings; //Field offset: 0x10
	protected readonly ExposedList<Vector3> vertexBuffer; //Field offset: 0x20
	protected readonly ExposedList<Vector2> uvBuffer; //Field offset: 0x28
	protected readonly ExposedList<Color32> colorBuffer; //Field offset: 0x30
	protected readonly ExposedList<ExposedList`1<Int32>> submeshes; //Field offset: 0x38
	private Vector2 meshBoundsMin; //Field offset: 0x40
	private Vector2 meshBoundsMax; //Field offset: 0x48
	private float meshBoundsThickness; //Field offset: 0x50
	private int submeshIndex; //Field offset: 0x54
	private SkeletonClipping clipper; //Field offset: 0x58
	private Single[] tempVerts; //Field offset: 0x60
	private Int32[] regionTriangles; //Field offset: 0x68
	private Vector3[] normals; //Field offset: 0x70
	private Vector4[] tangents; //Field offset: 0x78
	private Vector2[] tempTanBuffer; //Field offset: 0x80
	private ExposedList<Vector2> uv2; //Field offset: 0x88
	private ExposedList<Vector2> uv3; //Field offset: 0x90

	public MeshGeneratorBuffers Buffers
	{
		 get { } //Length: 172
	}

	public SkeletonClipping SkeletonClipping
	{
		 get { } //Length: 8
	}

	public Vector2[] UV2
	{
		 get { } //Length: 52
	}

	public Vector2[] UV3
	{
		 get { } //Length: 52
	}

	public int VertexCount
	{
		 get { } //Length: 28
	}

	private static MeshGenerator() { }

	public MeshGenerator() { }

	private void AddAttachmentTintBlack(float r2, float g2, float b2, float a, int vertexCount) { }

	public void AddSubmesh(SubmeshInstruction instruction, bool updateTriangles = true) { }

	public void Begin() { }

	public void BuildMesh(SkeletonRendererInstruction instruction, bool updateTriangles) { }

	public void BuildMeshWithArrays(SkeletonRendererInstruction instruction, bool updateTriangles) { }

	public void EnsureVertexCapacity(int minimumVertexCount, bool inlcudeTintBlack = false, bool includeTangents = false, bool includeNormals = false) { }

	public void FillLateVertexData(Mesh mesh) { }

	public static void FillMeshLocal(Mesh mesh, RegionAttachment regionAttachment) { }

	public static void FillMeshLocal(Mesh mesh, MeshAttachment meshAttachment, SkeletonData skeletonData) { }

	public void FillTriangles(Mesh mesh) { }

	public void FillVertexData(Mesh mesh) { }

	public static void GenerateSingleSubmeshInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Material material) { }

	public static void GenerateSkeletonRendererInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Dictionary<Slot, Material> customSlotMaterials, List<Slot> separatorSlots, bool generateMeshOverride, bool immutableTriangles = false) { }

	public MeshGeneratorBuffers get_Buffers() { }

	public SkeletonClipping get_SkeletonClipping() { }

	public Vector2[] get_UV2() { }

	public Vector2[] get_UV3() { }

	public int get_VertexCount() { }

	public Bounds GetMeshBounds() { }

	private void PrepareOptionalUVBuffer(ref ExposedList<Vector2>& uvBuffer, int vertexCount) { }

	public static bool RequiresMultipleSubmeshesByDrawOrder(Skeleton skeleton) { }

	private void ResizeOptionalUVBuffer(ref ExposedList<Vector2>& uvBuffer, int vertexCount) { }

	public void ScaleAndOffsetVertexData(float scale, Vector2 offset2D) { }

	public void ScaleVertexData(float scale) { }

	internal static void SolveTangents2DBuffer(Vector4[] tangents, Vector2[] tempTanBuffer, int vertexCount) { }

	internal static void SolveTangents2DEnsureSize(ref Vector4[] tangentBuffer, ref Vector2[] tempTanBuffer, int vertexCount, int vertexBufferLength) { }

	internal static void SolveTangents2DTriangles(Vector2[] tempTanBuffer, Int32[] triangles, int triangleCount, Vector3[] vertices, Vector2[] uvs, int vertexCount) { }

	public int SubmeshIndexCount(int submeshIndex) { }

	public void TrimExcess() { }

	public static void TryReplaceMaterials(ExposedList<SubmeshInstruction> workingSubmeshInstructions, Dictionary<Material, Material> customMaterialOverride) { }

}

