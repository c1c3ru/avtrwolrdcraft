namespace Spine;

public class TransformConstraint : IUpdatable
{
	internal readonly TransformConstraintData data; //Field offset: 0x10
	internal readonly ExposedList<Bone> bones; //Field offset: 0x18
	internal Bone target; //Field offset: 0x20
	internal float mixRotate; //Field offset: 0x28
	internal float mixX; //Field offset: 0x2C
	internal float mixY; //Field offset: 0x30
	internal float mixScaleX; //Field offset: 0x34
	internal float mixScaleY; //Field offset: 0x38
	internal float mixShearY; //Field offset: 0x3C
	internal bool active; //Field offset: 0x40

	public override bool Active
	{
		 get { } //Length: 8
	}

	public ExposedList<Bone> Bones
	{
		 get { } //Length: 8
	}

	public TransformConstraintData Data
	{
		 get { } //Length: 8
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

	public Bone Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TransformConstraint(TransformConstraintData data, Skeleton skeleton) { }

	public TransformConstraint(TransformConstraint constraint, Skeleton skeleton) { }

	private void ApplyAbsoluteLocal() { }

	private void ApplyAbsoluteWorld() { }

	private void ApplyRelativeLocal() { }

	private void ApplyRelativeWorld() { }

	public override bool get_Active() { }

	public ExposedList<Bone> get_Bones() { }

	public TransformConstraintData get_Data() { }

	public float get_MixRotate() { }

	public float get_MixScaleX() { }

	public float get_MixScaleY() { }

	public float get_MixShearY() { }

	public float get_MixX() { }

	public float get_MixY() { }

	public Bone get_Target() { }

	public void set_MixRotate(float value) { }

	public void set_MixScaleX(float value) { }

	public void set_MixScaleY(float value) { }

	public void set_MixShearY(float value) { }

	public void set_MixX(float value) { }

	public void set_MixY(float value) { }

	public void set_Target(Bone value) { }

	public void SetToSetupPose() { }

	public virtual string ToString() { }

	public override void Update(Physics physics) { }

}

