namespace Spine;

public class Slot
{
	internal SlotData data; //Field offset: 0x10
	internal Bone bone; //Field offset: 0x18
	internal float r; //Field offset: 0x20
	internal float g; //Field offset: 0x24
	internal float b; //Field offset: 0x28
	internal float a; //Field offset: 0x2C
	internal float r2; //Field offset: 0x30
	internal float g2; //Field offset: 0x34
	internal float b2; //Field offset: 0x38
	internal bool hasSecondColor; //Field offset: 0x3C
	internal Attachment attachment; //Field offset: 0x40
	internal int sequenceIndex; //Field offset: 0x48
	internal ExposedList<Single> deform; //Field offset: 0x50
	internal int attachmentState; //Field offset: 0x58

	public float A
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Attachment Attachment
	{
		 get { } //Length: 8
		 set { } //Length: 252
	}

	public float B
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float B2
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Bone Bone
	{
		 get { } //Length: 8
	}

	public SlotData Data
	{
		 get { } //Length: 8
	}

	public ExposedList<Single> Deform
	{
		 get { } //Length: 8
		 set { } //Length: 124
	}

	public float G
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float G2
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool HasSecondColor
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	public float R
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float R2
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int SequenceIndex
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public Skeleton Skeleton
	{
		 get { } //Length: 28
	}

	public Slot(SlotData data, Bone bone) { }

	public Slot(Slot slot, Bone bone) { }

	public void ClampColor() { }

	public void ClampSecondColor() { }

	public float get_A() { }

	public Attachment get_Attachment() { }

	public float get_B() { }

	public float get_B2() { }

	public Bone get_Bone() { }

	public SlotData get_Data() { }

	public ExposedList<Single> get_Deform() { }

	public float get_G() { }

	public float get_G2() { }

	public bool get_HasSecondColor() { }

	public float get_R() { }

	public float get_R2() { }

	public int get_SequenceIndex() { }

	public Skeleton get_Skeleton() { }

	public void set_A(float value) { }

	public void set_Attachment(Attachment value) { }

	public void set_B(float value) { }

	public void set_B2(float value) { }

	public void set_Deform(ExposedList<Single> value) { }

	public void set_G(float value) { }

	public void set_G2(float value) { }

	public void set_HasSecondColor(bool value) { }

	public void set_R(float value) { }

	public void set_R2(float value) { }

	public void set_SequenceIndex(int value) { }

	public void SetToSetupPose() { }

	public virtual string ToString() { }

}

