namespace Spine;

public class RegionAttachment : Attachment, IHasTextureRegion
{
	public const int BLX = 0; //Field offset: 0x0
	public const int BLY = 1; //Field offset: 0x0
	public const int ULX = 2; //Field offset: 0x0
	public const int ULY = 3; //Field offset: 0x0
	public const int URX = 4; //Field offset: 0x0
	public const int URY = 5; //Field offset: 0x0
	public const int BRX = 6; //Field offset: 0x0
	public const int BRY = 7; //Field offset: 0x0
	internal TextureRegion region; //Field offset: 0x18
	internal float x; //Field offset: 0x20
	internal float y; //Field offset: 0x24
	internal float rotation; //Field offset: 0x28
	internal float scaleX; //Field offset: 0x2C
	internal float scaleY; //Field offset: 0x30
	internal float width; //Field offset: 0x34
	internal float height; //Field offset: 0x38
	internal Single[] offset; //Field offset: 0x40
	internal Single[] uvs; //Field offset: 0x48
	internal float r; //Field offset: 0x50
	internal float g; //Field offset: 0x54
	internal float b; //Field offset: 0x58
	internal float a; //Field offset: 0x5C
	internal Sequence sequence; //Field offset: 0x60
	[CompilerGenerated]
	private string <Path>k__BackingField; //Field offset: 0x68

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

	public override float G
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Height
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Single[] Offset
	{
		 get { } //Length: 8
	}

	public override string Path
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
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
		 set { } //Length: 8
	}

	public float Rotation
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ScaleX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ScaleY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override Sequence Sequence
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Single[] UVs
	{
		 get { } //Length: 8
	}

	public float Width
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float X
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Y
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public RegionAttachment(RegionAttachment other) { }

	public RegionAttachment(string name) { }

	public void ComputeWorldVertices(Slot slot, Single[] worldVertices, int offset, int stride = 2) { }

	public virtual Attachment Copy() { }

	public override float get_A() { }

	public override float get_B() { }

	public override float get_G() { }

	public float get_Height() { }

	public Single[] get_Offset() { }

	[CompilerGenerated]
	public override string get_Path() { }

	public override float get_R() { }

	public override TextureRegion get_Region() { }

	public float get_Rotation() { }

	public float get_ScaleX() { }

	public float get_ScaleY() { }

	public override Sequence get_Sequence() { }

	public Single[] get_UVs() { }

	public float get_Width() { }

	public float get_X() { }

	public float get_Y() { }

	public override void set_A(float value) { }

	public override void set_B(float value) { }

	public override void set_G(float value) { }

	public void set_Height(float value) { }

	[CompilerGenerated]
	public override void set_Path(string value) { }

	public override void set_R(float value) { }

	public override void set_Region(TextureRegion value) { }

	public void set_Rotation(float value) { }

	public void set_ScaleX(float value) { }

	public void set_ScaleY(float value) { }

	public override void set_Sequence(Sequence value) { }

	public void set_Width(float value) { }

	public void set_X(float value) { }

	public void set_Y(float value) { }

	public override void UpdateRegion() { }

}

