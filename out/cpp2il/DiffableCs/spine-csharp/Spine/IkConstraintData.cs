namespace Spine;

public class IkConstraintData : ConstraintData
{
	internal ExposedList<BoneData> bones; //Field offset: 0x20
	internal BoneData target; //Field offset: 0x28
	internal int bendDirection; //Field offset: 0x30
	internal bool compress; //Field offset: 0x34
	internal bool stretch; //Field offset: 0x35
	internal bool uniform; //Field offset: 0x36
	internal float mix; //Field offset: 0x38
	internal float softness; //Field offset: 0x3C

	public int BendDirection
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<BoneData> Bones
	{
		 get { } //Length: 8
	}

	public bool Compress
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Mix
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Softness
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool Stretch
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public BoneData Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool Uniform
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public IkConstraintData(string name) { }

	public int get_BendDirection() { }

	public ExposedList<BoneData> get_Bones() { }

	public bool get_Compress() { }

	public float get_Mix() { }

	public float get_Softness() { }

	public bool get_Stretch() { }

	public BoneData get_Target() { }

	public bool get_Uniform() { }

	public void set_BendDirection(int value) { }

	public void set_Compress(bool value) { }

	public void set_Mix(float value) { }

	public void set_Softness(float value) { }

	public void set_Stretch(bool value) { }

	public void set_Target(BoneData value) { }

	public void set_Uniform(bool value) { }

}

