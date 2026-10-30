namespace Spine;

public class Sequence
{
	private static int nextID; //Field offset: 0x0
	private static readonly object nextIdLock; //Field offset: 0x8
	internal readonly int id; //Field offset: 0x10
	internal readonly TextureRegion[] regions; //Field offset: 0x18
	internal int start; //Field offset: 0x20
	internal int digits; //Field offset: 0x24
	internal int setupIndex; //Field offset: 0x28

	public int Digits
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Id
	{
		 get { } //Length: 8
	}

	public TextureRegion[] Regions
	{
		 get { } //Length: 8
	}

	public int SetupIndex
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int Start
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static Sequence() { }

	public Sequence(int count) { }

	public Sequence(Sequence other) { }

	public void Apply(Slot slot, IHasTextureRegion attachment) { }

	public int get_Digits() { }

	public int get_Id() { }

	public TextureRegion[] get_Regions() { }

	public int get_SetupIndex() { }

	public int get_Start() { }

	public string GetPath(string basePath, int index) { }

	public void set_Digits(int value) { }

	public void set_SetupIndex(int value) { }

	public void set_Start(int value) { }

}

