namespace SimpleUI.ScrollExtensions;

public class SizeDeltaFocusEffect : BaseFocusEffect
{
	public RectTransform rectTransform; //Field offset: 0x48
	public bool useX; //Field offset: 0x50
	public bool useY; //Field offset: 0x51
	private Vector2 effectVector; //Field offset: 0x54
	public Vector2 referenceSize; //Field offset: 0x5C

	public SizeDeltaFocusEffect() { }

	protected virtual void SetEffect(float strength) { }

}

