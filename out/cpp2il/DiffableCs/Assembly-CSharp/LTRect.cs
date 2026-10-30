//Type is in global namespace

public class LTRect
{
	public static bool colorTouched; //Field offset: 0x0
	public Rect _rect; //Field offset: 0x10
	public float alpha; //Field offset: 0x20
	public float rotation; //Field offset: 0x24
	public Vector2 pivot; //Field offset: 0x28
	public Vector2 margin; //Field offset: 0x30
	public Rect relativeRect; //Field offset: 0x38
	public bool rotateEnabled; //Field offset: 0x48
	[HideInInspector]
	public bool rotateFinished; //Field offset: 0x49
	public bool alphaEnabled; //Field offset: 0x4A
	public string labelStr; //Field offset: 0x50
	public Element_Type type; //Field offset: 0x58
	public GUIStyle style; //Field offset: 0x60
	public bool useColor; //Field offset: 0x68
	public Color color; //Field offset: 0x6C
	public bool fontScaleToFit; //Field offset: 0x7C
	public bool useSimpleScale; //Field offset: 0x7D
	public bool sizeByHeight; //Field offset: 0x7E
	public Texture texture; //Field offset: 0x80
	private int _id; //Field offset: 0x88
	[HideInInspector]
	public int counter; //Field offset: 0x8C

	public bool hasInitiliazed
	{
		 get { } //Length: 16
	}

	public float height
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public int id
	{
		 get { } //Length: 12
	}

	public Rect rect
	{
		 get { } //Length: 520
		 set { } //Length: 12
	}

	public float width
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float x
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float y
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LTRect() { }

	public LTRect(Rect rect) { }

	public LTRect(float x, float y, float width, float height) { }

	public LTRect(float x, float y, float width, float height, float alpha) { }

	public LTRect(float x, float y, float width, float height, float alpha, float rotation) { }

	public bool get_hasInitiliazed() { }

	public float get_height() { }

	public int get_id() { }

	public Rect get_rect() { }

	public float get_width() { }

	public float get_x() { }

	public float get_y() { }

	public void reset() { }

	public void resetForRotation() { }

	public void set_height(float value) { }

	public void set_rect(Rect value) { }

	public void set_width(float value) { }

	public void set_x(float value) { }

	public void set_y(float value) { }

	public LTRect setAlpha(float alpha) { }

	public LTRect setColor(Color color) { }

	public LTRect setFontScaleToFit(bool fontScaleToFit) { }

	public void setId(int id, int counter) { }

	public LTRect setLabel(string str) { }

	public LTRect setSizeByHeight(bool sizeByHeight) { }

	public LTRect setStyle(GUIStyle style) { }

	public LTRect setUseSimpleScale(bool useSimpleScale, Rect relativeRect) { }

	public LTRect setUseSimpleScale(bool useSimpleScale) { }

	public virtual string ToString() { }

}

