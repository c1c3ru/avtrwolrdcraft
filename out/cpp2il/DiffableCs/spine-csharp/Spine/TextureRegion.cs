namespace Spine;

public class TextureRegion
{
	public int width; //Field offset: 0x10
	public int height; //Field offset: 0x14
	public float u; //Field offset: 0x18
	public float v; //Field offset: 0x1C
	public float u2; //Field offset: 0x20
	public float v2; //Field offset: 0x24

	public override int OriginalHeight
	{
		 get { } //Length: 8
	}

	public override int OriginalWidth
	{
		 get { } //Length: 8
	}

	public TextureRegion() { }

	public override int get_OriginalHeight() { }

	public override int get_OriginalWidth() { }

}

