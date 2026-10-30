namespace Spine;

public class IkConstraint : IUpdatable
{
	internal readonly IkConstraintData data; //Field offset: 0x10
	internal readonly ExposedList<Bone> bones; //Field offset: 0x18
	internal Bone target; //Field offset: 0x20
	internal int bendDirection; //Field offset: 0x28
	internal bool compress; //Field offset: 0x2C
	internal bool stretch; //Field offset: 0x2D
	internal float mix; //Field offset: 0x30
	internal float softness; //Field offset: 0x34
	internal bool active; //Field offset: 0x38

	public override bool Active
	{
		 get { } //Length: 8
	}

	public int BendDirection
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ExposedList<Bone> Bones
	{
		 get { } //Length: 8
	}

	public bool Compress
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public IkConstraintData Data
	{
		 get { } //Length: 8
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

	public Bone Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public IkConstraint(IkConstraintData data, Skeleton skeleton) { }

	public IkConstraint(IkConstraint constraint, Skeleton skeleton) { }

	public static void Apply(Bone bone, float targetX, float targetY, bool compress, bool stretch, bool uniform, float alpha) { }

	public static void Apply(Bone parent, Bone child, float targetX, float targetY, int bendDir, bool stretch, bool uniform, float softness, float alpha) { }

	public override bool get_Active() { }

	public int get_BendDirection() { }

	public ExposedList<Bone> get_Bones() { }

	public bool get_Compress() { }

	public IkConstraintData get_Data() { }

	public float get_Mix() { }

	public float get_Softness() { }

	public bool get_Stretch() { }

	public Bone get_Target() { }

	public void set_BendDirection(int value) { }

	public void set_Compress(bool value) { }

	public void set_Mix(float value) { }

	public void set_Softness(float value) { }

	public void set_Stretch(bool value) { }

	public void set_Target(Bone value) { }

	public void SetToSetupPose() { }

	public virtual string ToString() { }

	public override void Update(Physics physics) { }

}

