namespace Spine;

public class AtlasRegion : TextureRegion
{
	public AtlasPage page; //Field offset: 0x28
	public string name; //Field offset: 0x30
	public int x; //Field offset: 0x38
	public int y; //Field offset: 0x3C
	public float offsetX; //Field offset: 0x40
	public float offsetY; //Field offset: 0x44
	public int originalWidth; //Field offset: 0x48
	public int originalHeight; //Field offset: 0x4C
	public int degrees; //Field offset: 0x50
	public bool rotate; //Field offset: 0x54
	public int index; //Field offset: 0x58
	public String[] names; //Field offset: 0x60
	public Int32[][] values; //Field offset: 0x68

	public virtual int OriginalHeight
	{
		 get { } //Length: 8
	}

	public virtual int OriginalWidth
	{
		 get { } //Length: 8
	}

	public int packedHeight
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int packedWidth
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public AtlasRegion() { }

	public AtlasRegion Clone() { }

	public virtual int get_OriginalHeight() { }

	public virtual int get_OriginalWidth() { }

	public int get_packedHeight() { }

	public int get_packedWidth() { }

	public void set_packedHeight(int value) { }

	public void set_packedWidth(int value) { }

}

