namespace Spine;

public class Atlas : IEnumerable<AtlasRegion>, IEnumerable
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public AtlasPage page; //Field offset: 0x10
		public String[] entry; //Field offset: 0x18
		public AtlasRegion region; //Field offset: 0x20

		public <>c__DisplayClass10_0() { }

		internal void <.ctor>b__0() { }

		internal void <.ctor>b__1() { }

		internal void <.ctor>b__10() { }

		internal void <.ctor>b__11() { }

		internal void <.ctor>b__12() { }

		internal void <.ctor>b__2() { }

		internal void <.ctor>b__3() { }

		internal void <.ctor>b__4() { }

		internal void <.ctor>b__5() { }

		internal void <.ctor>b__6() { }

		internal void <.ctor>b__7() { }

		internal void <.ctor>b__8() { }

		internal void <.ctor>b__9() { }

	}

	private readonly List<AtlasPage> pages; //Field offset: 0x10
	private List<AtlasRegion> regions; //Field offset: 0x18
	private TextureLoader textureLoader; //Field offset: 0x20

	public List<AtlasPage> Pages
	{
		 get { } //Length: 8
	}

	public List<AtlasRegion> Regions
	{
		 get { } //Length: 8
	}

	public Atlas(List<AtlasPage> pages, List<AtlasRegion> regions) { }

	public Atlas(TextReader reader, string imagesDir, TextureLoader textureLoader) { }

	public void Dispose() { }

	public AtlasRegion FindRegion(string name) { }

	public void FlipV() { }

	public List<AtlasPage> get_Pages() { }

	public List<AtlasRegion> get_Regions() { }

	public override IEnumerator<AtlasRegion> GetEnumerator() { }

	private static int ReadEntry(String[] entry, string line) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

