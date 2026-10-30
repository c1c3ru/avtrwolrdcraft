namespace Spine;

public class TransformConstraintData : ConstraintData
{
	internal ExposedList<BoneData> bones; //Field offset: 0x20
	internal BoneData target; //Field offset: 0x28
	internal float mixRotate; //Field offset: 0x30
	internal float mixX; //Field offset: 0x34
	internal float mixY; //Field offset: 0x38
	internal float mixScaleX; //Field offset: 0x3C
	internal float mixScaleY; //Field offset: 0x40
	internal float mixShearY; //Field offset: 0x44
	internal float offsetRotation; //Field offset: 0x48
	internal float offsetX; //Field offset: 0x4C
	internal float offsetY; //Field offset: 0x50
	internal float offsetScaleX; //Field offset: 0x54
	internal float offsetScaleY; //Field offset: 0x58
	internal float offsetShearY; //Field offset: 0x5C
	internal bool relative; //Field offset: 0x60
	internal bool local; //Field offset: 0x61

	public ExposedList<BoneData> Bones
	{
		 get { } //Length: 8
	}

	public bool Local
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float MixRotate
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixScaleX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixScaleY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixShearY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float MixY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetRotation
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetScaleX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetScaleY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetShearY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float OffsetY
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool Relative
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public BoneData Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TransformConstraintData(string name) { }

	public ExposedList<BoneData> get_Bones() { }

	public bool get_Local() { }

	public float get_MixRotate() { }

	public float get_MixScaleX() { }

	public float get_MixScaleY() { }

	public float get_MixShearY() { }

	public float get_MixX() { }

	public float get_MixY() { }

	public float get_OffsetRotation() { }

	public float get_OffsetScaleX() { }

	public float get_OffsetScaleY() { }

	public float get_OffsetShearY() { }

	public float get_OffsetX() { }

	public float get_OffsetY() { }

	public bool get_Relative() { }

	public BoneData get_Target() { }

	public void set_Local(bool value) { }

	public void set_MixRotate(float value) { }

	public void set_MixScaleX(float value) { }

	public void set_MixScaleY(float value) { }

	public void set_MixShearY(float value) { }

	public void set_MixX(float value) { }

	public void set_MixY(float value) { }

	public void set_OffsetRotation(float value) { }

	public void set_OffsetScaleX(float value) { }

	public void set_OffsetScaleY(float value) { }

	public void set_OffsetShearY(float value) { }

	public void set_OffsetX(float value) { }

	public void set_OffsetY(float value) { }

	public void set_Relative(bool value) { }

	public void set_Target(BoneData value) { }

}

