namespace TMPro;

public static class TMP_DefaultControls
{
	internal struct Resources
	{
		public Sprite standard; //Field offset: 0x0
		public Sprite background; //Field offset: 0x8
		public Sprite inputField; //Field offset: 0x10
		public Sprite knob; //Field offset: 0x18
		public Sprite checkmark; //Field offset: 0x20
		public Sprite dropdown; //Field offset: 0x28
		public Sprite mask; //Field offset: 0x30

	}

	private const float kWidth = 160; //Field offset: 0x0
	private const float kThickHeight = 30; //Field offset: 0x0
	private const float kThinHeight = 20; //Field offset: 0x0
	private static Vector2 s_TextElementSize; //Field offset: 0x0
	private static Vector2 s_ThickElementSize; //Field offset: 0x8
	private static Vector2 s_ThinElementSize; //Field offset: 0x10
	private static Color s_DefaultSelectableColor; //Field offset: 0x18
	private static Color s_TextColor; //Field offset: 0x28

	private static TMP_DefaultControls() { }

	public static GameObject CreateButton(Resources resources) { }

	public static GameObject CreateDropdown(Resources resources) { }

	public static GameObject CreateInputField(Resources resources) { }

	public static GameObject CreateScrollbar(Resources resources) { }

	public static GameObject CreateText(Resources resources) { }

	private static GameObject CreateUIElementRoot(string name, Vector2 size) { }

	private static GameObject CreateUIObject(string name, GameObject parent) { }

	private static void SetDefaultColorTransitionValues(Selectable slider) { }

	private static void SetDefaultTextValues(TMP_Text lbl) { }

	private static void SetLayerRecursively(GameObject go, int layer) { }

	private static void SetParentAndAlign(GameObject child, GameObject parent) { }

}

