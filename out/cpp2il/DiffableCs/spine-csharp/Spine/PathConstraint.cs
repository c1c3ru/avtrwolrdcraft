namespace Spine;

public class PathConstraint : IUpdatable
{
	private const int NONE = -1; //Field offset: 0x0
	private const int BEFORE = -2; //Field offset: 0x0
	private const int AFTER = -3; //Field offset: 0x0
	private const float Epsilon = 1E-05; //Field offset: 0x0
	internal readonly PathConstraintData data; //Field offset: 0x10
	internal readonly ExposedList<Bone> bones; //Field offset: 0x18
	internal Slot target; //Field offset: 0x20
	internal float position; //Field offset: 0x28
	internal float spacing; //Field offset: 0x2C
	internal float mixRotate; //Field offset: 0x30
	internal float mixX; //Field offset: 0x34
	internal float mixY; //Field offset: 0x38
	internal bool active; //Field offset: 0x3C
	internal readonly ExposedList<Single> spaces; //Field offset: 0x40
	internal readonly ExposedList<Single> positions; //Field offset: 0x48
	internal readonly ExposedList<Single> world; //Field offset: 0x50
	internal readonly ExposedList<Single> curves; //Field offset: 0x58
	internal readonly ExposedList<Single> lengths; //Field offset: 0x60
	internal readonly Single[] segments; //Field offset: 0x68

	public override bool Active
	{
		 get { } //Length: 8
	}

	public ExposedList<Bone> Bones
	{
		 get { } //Length: 8
	}

	public PathConstraintData Data
	{
		 get { } //Length: 8
	}

	public float MixRotate
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

	public float Position
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Spacing
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Slot Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PathConstraint(PathConstraintData data, Skeleton skeleton) { }

	public PathConstraint(PathConstraint constraint, Skeleton skeleton) { }

	private static void AddAfterPosition(float p, Single[] temp, int i, Single[] output, int o) { }

	private static void AddBeforePosition(float p, Single[] temp, int i, Single[] output, int o) { }

	private static void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, Single[] output, int o, bool tangents) { }

	public static void ArraysFill(Single[] a, int fromIndex, int toIndex, float val) { }

	private Single[] ComputeWorldPositions(PathAttachment path, int spacesCount, bool tangents) { }

	public override bool get_Active() { }

	public ExposedList<Bone> get_Bones() { }

	public PathConstraintData get_Data() { }

	public float get_MixRotate() { }

	public float get_MixX() { }

	public float get_MixY() { }

	public float get_Position() { }

	public float get_Spacing() { }

	public Slot get_Target() { }

	public void set_MixRotate(float value) { }

	public void set_MixX(float value) { }

	public void set_MixY(float value) { }

	public void set_Position(float value) { }

	public void set_Spacing(float value) { }

	public void set_Target(Slot value) { }

	public void SetToSetupPose() { }

	public virtual string ToString() { }

	public override void Update(Physics physics) { }

}

