namespace Spine;

public class PhysicsConstraint : IUpdatable
{
	internal readonly PhysicsConstraintData data; //Field offset: 0x10
	public Bone bone; //Field offset: 0x18
	internal float inertia; //Field offset: 0x20
	internal float strength; //Field offset: 0x24
	internal float damping; //Field offset: 0x28
	internal float massInverse; //Field offset: 0x2C
	internal float wind; //Field offset: 0x30
	internal float gravity; //Field offset: 0x34
	internal float mix; //Field offset: 0x38
	private bool reset; //Field offset: 0x3C
	private float ux; //Field offset: 0x40
	private float uy; //Field offset: 0x44
	private float cx; //Field offset: 0x48
	private float cy; //Field offset: 0x4C
	private float tx; //Field offset: 0x50
	private float ty; //Field offset: 0x54
	private float xOffset; //Field offset: 0x58
	private float xVelocity; //Field offset: 0x5C
	private float yOffset; //Field offset: 0x60
	private float yVelocity; //Field offset: 0x64
	private float rotateOffset; //Field offset: 0x68
	private float rotateVelocity; //Field offset: 0x6C
	private float scaleOffset; //Field offset: 0x70
	private float scaleVelocity; //Field offset: 0x74
	internal bool active; //Field offset: 0x78
	private readonly Skeleton skeleton; //Field offset: 0x80
	private float remaining; //Field offset: 0x88
	private float lastTime; //Field offset: 0x8C

	public override bool Active
	{
		 get { } //Length: 8
	}

	public Bone Bone
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Damping
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PhysicsConstraintData Data
	{
		 get { } //Length: 8
	}

	public float Gravity
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Inertia
	{
		 get { } //Length: 8
		 set { } //Length: 8
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

	public float Strength
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Wind
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PhysicsConstraint(PhysicsConstraintData data, Skeleton skeleton) { }

	public PhysicsConstraint(PhysicsConstraint constraint, Skeleton skeleton) { }

	public override bool get_Active() { }

	public Bone get_Bone() { }

	public float get_Damping() { }

	public PhysicsConstraintData get_Data() { }

	public float get_Gravity() { }

	public float get_Inertia() { }

	public float get_MassInverse() { }

	public float get_Mix() { }

	public float get_Strength() { }

	public float get_Wind() { }

	public PhysicsConstraintData getData() { }

	public void Reset() { }

	public void Rotate(float x, float y, float degrees) { }

	public void set_Bone(Bone value) { }

	public void set_Damping(float value) { }

	public void set_Gravity(float value) { }

	public void set_Inertia(float value) { }

	public void set_MassInverse(float value) { }

	public void set_Mix(float value) { }

	public void set_Strength(float value) { }

	public void set_Wind(float value) { }

	public void SetToSetupPose() { }

	public virtual string ToString() { }

	public void Translate(float x, float y) { }

	public override void Update(Physics physics) { }

}

