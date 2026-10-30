namespace Spine;

public class SkeletonBinary : SkeletonLoader
{
	private class LinkedMesh
	{
		internal string parent; //Field offset: 0x10
		internal int skinIndex; //Field offset: 0x18
		internal int slotIndex; //Field offset: 0x1C
		internal MeshAttachment mesh; //Field offset: 0x20
		internal bool inheritTimelines; //Field offset: 0x28

		public LinkedMesh(MeshAttachment mesh, int skinIndex, int slotIndex, string parent, bool inheritTimelines) { }

	}

	public class SkeletonInput
	{
		private Byte[] chars; //Field offset: 0x10
		private Byte[] bytesBigEndian; //Field offset: 0x18
		internal String[] strings; //Field offset: 0x20
		private Stream input; //Field offset: 0x28

		public SkeletonInput(Stream input) { }

		public string GetVersionString() { }

		public string GetVersionStringOld3X() { }

		public int Read() { }

		public bool ReadBoolean() { }

		public float ReadFloat() { }

		public void ReadFully(Byte[] buffer, int offset, int length) { }

		public int ReadInt() { }

		public int ReadInt(bool optimizePositive) { }

		public long ReadLong() { }

		public sbyte ReadSByte() { }

		public string ReadString() { }

		public string ReadStringRef() { }

		public byte ReadUByte() { }

	}

	public class Vertices
	{
		public int length; //Field offset: 0x10
		public Int32[] bones; //Field offset: 0x18
		public Single[] vertices; //Field offset: 0x20

		public Vertices() { }

	}

	public const int BONE_ROTATE = 0; //Field offset: 0x0
	public const int CURVE_STEPPED = 1; //Field offset: 0x0
	public const int CURVE_LINEAR = 0; //Field offset: 0x0
	public const int PHYSICS_RESET = 8; //Field offset: 0x0
	public const int PHYSICS_MIX = 7; //Field offset: 0x0
	public const int PHYSICS_GRAVITY = 6; //Field offset: 0x0
	public const int PHYSICS_WIND = 5; //Field offset: 0x0
	public const int PHYSICS_MASS = 4; //Field offset: 0x0
	public const int PHYSICS_DAMPING = 2; //Field offset: 0x0
	public const int PHYSICS_STRENGTH = 1; //Field offset: 0x0
	public const int PHYSICS_INERTIA = 0; //Field offset: 0x0
	public const int PATH_MIX = 2; //Field offset: 0x0
	public const int PATH_SPACING = 1; //Field offset: 0x0
	public const int PATH_POSITION = 0; //Field offset: 0x0
	public const int ATTACHMENT_SEQUENCE = 1; //Field offset: 0x0
	public const int ATTACHMENT_DEFORM = 0; //Field offset: 0x0
	public const int SLOT_ALPHA = 5; //Field offset: 0x0
	public const int SLOT_RGB2 = 4; //Field offset: 0x0
	public const int BONE_TRANSLATE = 1; //Field offset: 0x0
	public const int BONE_TRANSLATEX = 2; //Field offset: 0x0
	public const int BONE_TRANSLATEY = 3; //Field offset: 0x0
	public const int BONE_SCALE = 4; //Field offset: 0x0
	public const int BONE_SCALEX = 5; //Field offset: 0x0
	public const int BONE_SCALEY = 6; //Field offset: 0x0
	public const int CURVE_BEZIER = 2; //Field offset: 0x0
	public const int BONE_SHEAR = 7; //Field offset: 0x0
	public const int BONE_SHEARY = 9; //Field offset: 0x0
	public const int BONE_INHERIT = 10; //Field offset: 0x0
	public const int SLOT_ATTACHMENT = 0; //Field offset: 0x0
	public const int SLOT_RGBA = 1; //Field offset: 0x0
	public const int SLOT_RGB = 2; //Field offset: 0x0
	public const int SLOT_RGBA2 = 3; //Field offset: 0x0
	public const int BONE_SHEARX = 8; //Field offset: 0x0
	private readonly List<LinkedMesh> linkedMeshes; //Field offset: 0x20

	public SkeletonBinary(AttachmentLoader attachmentLoader) { }

	public SkeletonBinary(Atlas[] atlasArray) { }

	public static string GetVersionString(Stream file) { }

	private Animation ReadAnimation(string name, SkeletonInput input, SkeletonData skeletonData) { }

	private Attachment ReadAttachment(SkeletonInput input, SkeletonData skeletonData, Skin skin, int slotIndex, string attachmentName, bool nonessential) { }

	private Single[] ReadFloatArray(SkeletonInput input, int n, float scale) { }

	private Sequence ReadSequence(SkeletonInput input) { }

	private Int32[] ReadShortArray(SkeletonInput input, int n) { }

	public virtual SkeletonData ReadSkeletonData(string path) { }

	public SkeletonData ReadSkeletonData(Stream file) { }

	private Skin ReadSkin(SkeletonInput input, SkeletonData skeletonData, bool defaultSkin, bool nonessential) { }

	private void ReadTimeline(SkeletonInput input, ExposedList<Timeline> timelines, CurveTimeline1 timeline, float scale) { }

	private void ReadTimeline(SkeletonInput input, ExposedList<Timeline> timelines, CurveTimeline2 timeline, float scale) { }

	private Vertices ReadVertices(SkeletonInput input, bool weighted) { }

	private void SetBezier(SkeletonInput input, CurveTimeline timeline, int bezier, int frame, int value, float time1, float time2, float value1, float value2, float scale) { }

}

