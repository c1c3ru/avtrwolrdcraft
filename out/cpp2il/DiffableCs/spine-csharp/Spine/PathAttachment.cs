namespace Spine;

public class PathAttachment : VertexAttachment
{
	internal Single[] lengths; //Field offset: 0x40
	internal bool closed; //Field offset: 0x48
	internal bool constantSpeed; //Field offset: 0x49

	public bool Closed
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool ConstantSpeed
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public Single[] Lengths
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public PathAttachment(string name) { }

	protected PathAttachment(PathAttachment other) { }

	public virtual Attachment Copy() { }

	public bool get_Closed() { }

	public bool get_ConstantSpeed() { }

	public Single[] get_Lengths() { }

	public void set_Closed(bool value) { }

	public void set_ConstantSpeed(bool value) { }

	public void set_Lengths(Single[] value) { }

}

