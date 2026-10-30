namespace TMPro;

public class TMP_SpriteGlyph : Glyph
{
	public Sprite sprite; //Field offset: 0x48

	public TMP_SpriteGlyph() { }

	public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex) { }

	public TMP_SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex, Sprite sprite) { }

}

