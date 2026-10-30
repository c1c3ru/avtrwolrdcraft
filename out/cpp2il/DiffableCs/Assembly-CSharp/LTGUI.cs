//Type is in global namespace

public class LTGUI
{
	internal enum Element_Type
	{
		Texture = 0,
		Label = 1,
	}

	public static int RECT_LEVELS; //Field offset: 0x0
	public static int RECTS_PER_LEVEL; //Field offset: 0x4
	public static int BUTTONS_MAX; //Field offset: 0x8
	private static LTRect[] levels; //Field offset: 0x10
	private static Int32[] levelDepths; //Field offset: 0x18
	private static Rect[] buttons; //Field offset: 0x20
	private static Int32[] buttonLevels; //Field offset: 0x28
	private static Int32[] buttonLastFrame; //Field offset: 0x30
	private static LTRect r; //Field offset: 0x38
	private static Color color; //Field offset: 0x40
	private static bool isGUIEnabled; //Field offset: 0x50
	private static int global_counter; //Field offset: 0x54

	private static LTGUI() { }

	public LTGUI() { }

	public static bool checkOnScreen(Rect rect) { }

	public static bool checkWithinRect(Vector2 vec2, Rect rect) { }

	public static void destroy(int id) { }

	public static void destroyAll(int depth) { }

	public static LTRect element(LTRect rect, int depth) { }

	public static Vector2 firstTouch() { }

	public static bool hasNoOverlap(Rect rect, int depth) { }

	public static void init() { }

	public static void initRectCheck() { }

	public static LTRect label(Rect rect, string label, int depth) { }

	public static LTRect label(LTRect rect, string label, int depth) { }

	public static bool pressedWithinRect(Rect rect) { }

	public static void reset() { }

	public static LTRect texture(LTRect rect, Texture texture, int depth) { }

	public static LTRect texture(Rect rect, Texture texture, int depth) { }

	public static void update(int updateLevel) { }

}

