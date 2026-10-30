namespace Spine;

public class BoneData
{
	internal int index; //Field offset: 0x10
	internal string name; //Field offset: 0x18
	internal BoneData parent; //Field offset: 0x20
	internal float length; //Field offset: 0x28
	internal float x; //Field offset: 0x2C
	internal float y; //Field offset: 0x30
	internal float rotation; //Field offset: 0x34
	internal float scaleX; //Field offset: 0x38
	internal float scaleY; //Field offset: 0x3C
	internal float shearX; //Field offset: 0x40
	internal float shearY; //Field offset: 0x44
	internal Inherit inherit; //Field offset: 0x48
	internal bool skinRequired; //Field offset: 0x4C

	public int Index
	{
		 get { } //Length: 8
	}

	public Inherit Inherit
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Length
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public string Name
	{
		 get { } //Length: 8
	}

	public BoneData Parent
	{
		 get { } //Length: 8
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

	public float ShearX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ShearY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool SkinRequired
	{
		 get { } //Length: 8
		 set { } //Length: 12
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

	public BoneData(int index, string name, BoneData parent) { }

	public int get_Index() { }

	public Inherit get_Inherit() { }

	public float get_Length() { }

	public string get_Name() { }

	public BoneData get_Parent() { }

	public float get_Rotation() { }

	public float get_ScaleX() { }

	public float get_ScaleY() { }

	public float get_ShearX() { }

	public float get_ShearY() { }

	public bool get_SkinRequired() { }

	public float get_X() { }

	public float get_Y() { }

	public void set_Inherit(Inherit value) { }

	public void set_Length(float value) { }

	public void set_Rotation(float value) { }

	public void set_ScaleX(float value) { }

	public void set_ScaleY(float value) { }

	public void set_ShearX(float value) { }

	public void set_ShearY(float value) { }

	public void set_SkinRequired(bool value) { }

	public void set_X(float value) { }

	public void set_Y(float value) { }

	public virtual string ToString() { }

}

