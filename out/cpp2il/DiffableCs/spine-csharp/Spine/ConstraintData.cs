namespace Spine;

public abstract class ConstraintData
{
	internal readonly string name; //Field offset: 0x10
	internal int order; //Field offset: 0x18
	internal bool skinRequired; //Field offset: 0x1C

	public string Name
	{
		 get { } //Length: 8
	}

	public int Order
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool SkinRequired
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public ConstraintData(string name) { }

	public string get_Name() { }

	public int get_Order() { }

	public bool get_SkinRequired() { }

	public void set_Order(int value) { }

	public void set_SkinRequired(bool value) { }

	public virtual string ToString() { }

}

