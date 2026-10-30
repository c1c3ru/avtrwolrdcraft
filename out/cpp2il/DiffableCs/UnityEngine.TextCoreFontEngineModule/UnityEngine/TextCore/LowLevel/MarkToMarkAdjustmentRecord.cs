namespace UnityEngine.TextCore.LowLevel;

[UsedByNativeCode]
internal struct MarkToMarkAdjustmentRecord
{
	[NativeName("baseMarkGlyphID")]
	[SerializeField]
	private uint m_BaseMarkGlyphID; //Field offset: 0x0
	[NativeName("baseMarkAnchor")]
	[SerializeField]
	private GlyphAnchorPoint m_BaseMarkGlyphAnchorPoint; //Field offset: 0x4
	[NativeName("combiningMarkGlyphID")]
	[SerializeField]
	private uint m_CombiningMarkGlyphID; //Field offset: 0xC
	[NativeName("combiningMarkPositionAdjustment")]
	[SerializeField]
	private MarkPositionAdjustment m_CombiningMarkPositionAdjustment; //Field offset: 0x10

	public GlyphAnchorPoint baseMarkGlyphAnchorPoint
	{
		 get { } //Length: 8
	}

	public uint baseMarkGlyphID
	{
		 get { } //Length: 8
	}

	public uint combiningMarkGlyphID
	{
		 get { } //Length: 8
	}

	public MarkPositionAdjustment combiningMarkPositionAdjustment
	{
		 get { } //Length: 8
	}

	public GlyphAnchorPoint get_baseMarkGlyphAnchorPoint() { }

	public uint get_baseMarkGlyphID() { }

	public uint get_combiningMarkGlyphID() { }

	public MarkPositionAdjustment get_combiningMarkPositionAdjustment() { }

}

