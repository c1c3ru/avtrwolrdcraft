namespace Spine;

public class PhysicsConstraintData : ConstraintData
{
	internal BoneData bone; //Field offset: 0x20
	internal float x; //Field offset: 0x28
	internal float y; //Field offset: 0x2C
	internal float rotate; //Field offset: 0x30
	internal float scaleX; //Field offset: 0x34
	internal float shearX; //Field offset: 0x38
	internal float limit; //Field offset: 0x3C
	internal float step; //Field offset: 0x40
	internal float inertia; //Field offset: 0x44
	internal float strength; //Field offset: 0x48
	internal float damping; //Field offset: 0x4C
	internal float massInverse; //Field offset: 0x50
	internal float wind; //Field offset: 0x54
	internal float gravity; //Field offset: 0x58
	internal float mix; //Field offset: 0x5C
	internal bool inertiaGlobal; //Field offset: 0x60
	internal bool strengthGlobal; //Field offset: 0x61
	internal bool dampingGlobal; //Field offset: 0x62
	internal bool massGlobal; //Field offset: 0x63
	internal bool windGlobal; //Field offset: 0x64
	internal bool gravityGlobal; //Field offset: 0x65
	internal bool mixGlobal; //Field offset: 0x66

	public BoneData Bone
	{
		 get { } //Length: 8
	}

	public float Damping
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool DampingGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Gravity
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool GravityGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Inertia
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool InertiaGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Limit
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool MassGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float MassInverse
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Mix
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool MixGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Rotate
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ScaleX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float ShearX
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Step
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Strength
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool StrengthGlobal
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public float Wind
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool WindGlobal
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

	public PhysicsConstraintData(string name) { }

	public BoneData get_Bone() { }

	public float get_Damping() { }

	public bool get_DampingGlobal() { }

	public float get_Gravity() { }

	public bool get_GravityGlobal() { }

	public float get_Inertia() { }

	public bool get_InertiaGlobal() { }

	public float get_Limit() { }

	public bool get_MassGlobal() { }

	public float get_MassInverse() { }

	public float get_Mix() { }

	public bool get_MixGlobal() { }

	public float get_Rotate() { }

	public float get_ScaleX() { }

	public float get_ShearX() { }

	public float get_Step() { }

	public float get_Strength() { }

	public bool get_StrengthGlobal() { }

	public float get_Wind() { }

	public bool get_WindGlobal() { }

	public float get_X() { }

	public float get_Y() { }

	public void set_Damping(float value) { }

	public void set_DampingGlobal(bool value) { }

	public void set_Gravity(float value) { }

	public void set_GravityGlobal(bool value) { }

	public void set_Inertia(float value) { }

	public void set_InertiaGlobal(bool value) { }

	public void set_Limit(float value) { }

	public void set_MassGlobal(bool value) { }

	public void set_MassInverse(float value) { }

	public void set_Mix(float value) { }

	public void set_MixGlobal(bool value) { }

	public void set_Rotate(float value) { }

	public void set_ScaleX(float value) { }

	public void set_ShearX(float value) { }

	public void set_Step(float value) { }

	public void set_Strength(float value) { }

	public void set_StrengthGlobal(bool value) { }

	public void set_Wind(float value) { }

	public void set_WindGlobal(bool value) { }

	public void set_X(float value) { }

	public void set_Y(float value) { }

}

