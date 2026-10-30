namespace Spine;

public class MeshAttachment : VertexAttachment, IHasTextureRegion
{
	internal TextureRegion region; //Field offset: 0x40
	internal string path; //Field offset: 0x48
	internal Single[] regionUVs; //Field offset: 0x50
	internal Single[] uvs; //Field offset: 0x58
	internal Int32[] triangles; //Field offset: 0x60
	internal float r; //Field offset: 0x68
	internal float g; //Field offset: 0x6C
	internal float b; //Field offset: 0x70
	internal float a; //Field offset: 0x74
	internal int hullLength; //Field offset: 0x78
	private MeshAttachment parentMesh; //Field offset: 0x80
	private Sequence sequence; //Field offset: 0x88
	[CompilerGenerated]
	private Int32[] <Edges>k__BackingField; //Field offset: 0x90
	[CompilerGenerated]
	private float <Width>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private float <Height>k__BackingField; //Field offset: 0x9C

	public override float A
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override float B
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Int32[] Edges
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override float G
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Height
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public int HullLength
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public MeshAttachment ParentMesh
	{
		 get { } //Length: 8
		 set { } //Length: 144
	}

	public override string Path
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override float R
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override TextureRegion Region
	{
		 get { } //Length: 8
		 set { } //Length: 120
	}

	public Single[] RegionUVs
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override Sequence Sequence
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Int32[] Triangles
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Single[] UVs
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Width
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	protected MeshAttachment(MeshAttachment other) { }

	public MeshAttachment(string name) { }

	public virtual void ComputeWorldVertices(Slot slot, int start, int count, Single[] worldVertices, int offset, int stride = 2) { }

	public virtual Attachment Copy() { }

	public override float get_A() { }

	public override float get_B() { }

	[CompilerGenerated]
	public Int32[] get_Edges() { }

	public override float get_G() { }

	[CompilerGenerated]
	public float get_Height() { }

	public int get_HullLength() { }

	public MeshAttachment get_ParentMesh() { }

	public override string get_Path() { }

	public override float get_R() { }

	public override TextureRegion get_Region() { }

	public Single[] get_RegionUVs() { }

	public override Sequence get_Sequence() { }

	public Int32[] get_Triangles() { }

	public Single[] get_UVs() { }

	[CompilerGenerated]
	public float get_Width() { }

	public MeshAttachment NewLinkedMesh() { }

	public override void set_A(float value) { }

	public override void set_B(float value) { }

	[CompilerGenerated]
	public void set_Edges(Int32[] value) { }

	public override void set_G(float value) { }

	[CompilerGenerated]
	public void set_Height(float value) { }

	public void set_HullLength(int value) { }

	public void set_ParentMesh(MeshAttachment value) { }

	public override void set_Path(string value) { }

	public override void set_R(float value) { }

	public override void set_Region(TextureRegion value) { }

	public void set_RegionUVs(Single[] value) { }

	public override void set_Sequence(Sequence value) { }

	public void set_Triangles(Int32[] value) { }

	public void set_UVs(Single[] value) { }

	[CompilerGenerated]
	public void set_Width(float value) { }

	public override void UpdateRegion() { }

}

