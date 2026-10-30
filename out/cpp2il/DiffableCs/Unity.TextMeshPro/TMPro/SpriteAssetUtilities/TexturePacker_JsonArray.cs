namespace TMPro.SpriteAssetUtilities;

public class TexturePacker_JsonArray
{
	internal struct Frame
	{
		public string filename; //Field offset: 0x0
		public SpriteFrame frame; //Field offset: 0x8
		public bool rotated; //Field offset: 0x18
		public bool trimmed; //Field offset: 0x19
		public SpriteFrame spriteSourceSize; //Field offset: 0x1C
		public SpriteSize sourceSize; //Field offset: 0x2C
		public Vector2 pivot; //Field offset: 0x34

	}

	internal struct Meta
	{
		public string app; //Field offset: 0x0
		public string version; //Field offset: 0x8
		public string image; //Field offset: 0x10
		public string format; //Field offset: 0x18
		public SpriteSize size; //Field offset: 0x20
		public float scale; //Field offset: 0x28
		public string smartupdate; //Field offset: 0x30

	}

	internal class SpriteDataObject
	{
		public List<Frame> frames; //Field offset: 0x10
		public Meta meta; //Field offset: 0x18

		public SpriteDataObject() { }

	}

	internal struct SpriteFrame
	{
		public float x; //Field offset: 0x0
		public float y; //Field offset: 0x4
		public float w; //Field offset: 0x8
		public float h; //Field offset: 0xC

		public virtual string ToString() { }

	}

	internal struct SpriteSize
	{
		public float w; //Field offset: 0x0
		public float h; //Field offset: 0x4

		public virtual string ToString() { }

	}


	public TexturePacker_JsonArray() { }

}

