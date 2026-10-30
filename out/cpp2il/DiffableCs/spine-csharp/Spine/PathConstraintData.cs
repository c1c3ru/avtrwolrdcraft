namespace Spine;

public class PathConstraintData : ConstraintData
{
	internal ExposedList<BoneData> bones; //Field offset: 0x20
	internal SlotData target; //Field offset: 0x28
	internal PositionMode positionMode; //Field offset: 0x30
	internal SpacingMode spacingMode; //Field offset: 0x34
	internal RotateMode rotateMode; //Field offset: 0x38
	internal float offsetRotation; //Field offset: 0x3C
	internal float position; //Field offset: 0x40
	internal float spacing; //Field offset: 0x44
	internal float mixRotate; //Field offset: 0x48
	internal float mixX; //Field offset: 0x4C
	internal float mixY; //Field offset: 0x50

	public ExposedList<BoneData> Bones
	{
		 get { } //Length: 8
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

	public float Position
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PositionMode PositionMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float RotateMix
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public RotateMode RotateMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float Spacing
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SpacingMode SpacingMode
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public SlotData Target
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PathConstraintData(string name) { }

	public ExposedList<BoneData> get_Bones() { }

	public float get_MixX() { }

	public float get_MixY() { }

	public float get_OffsetRotation() { }

	public float get_Position() { }

	public PositionMode get_PositionMode() { }

	public float get_RotateMix() { }

	public RotateMode get_RotateMode() { }

	public float get_Spacing() { }

	public SpacingMode get_SpacingMode() { }

	public SlotData get_Target() { }

	public void set_MixX(float value) { }

	public void set_MixY(float value) { }

	public void set_OffsetRotation(float value) { }

	public void set_Position(float value) { }

	public void set_PositionMode(PositionMode value) { }

	public void set_RotateMix(float value) { }

	public void set_RotateMode(RotateMode value) { }

	public void set_Spacing(float value) { }

	public void set_SpacingMode(SpacingMode value) { }

	public void set_Target(SlotData value) { }

}

