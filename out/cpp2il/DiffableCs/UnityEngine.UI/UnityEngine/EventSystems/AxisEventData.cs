namespace UnityEngine.EventSystems;

public class AxisEventData : BaseEventData
{
	[CompilerGenerated]
	private Vector2 <moveVector>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private MoveDirection <moveDir>k__BackingField; //Field offset: 0x28

	public MoveDirection moveDir
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public Vector2 moveVector
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public AxisEventData(EventSystem eventSystem) { }

	[CompilerGenerated]
	public MoveDirection get_moveDir() { }

	[CompilerGenerated]
	public Vector2 get_moveVector() { }

	[CompilerGenerated]
	public void set_moveDir(MoveDirection value) { }

	[CompilerGenerated]
	public void set_moveVector(Vector2 value) { }

}

