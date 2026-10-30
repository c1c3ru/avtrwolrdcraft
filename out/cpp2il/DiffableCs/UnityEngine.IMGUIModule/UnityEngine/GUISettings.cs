namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUISkin.bindings.h")]
public sealed class GUISettings
{
	[SerializeField]
	private bool m_DoubleClickSelectsWord; //Field offset: 0x10
	[SerializeField]
	private bool m_TripleClickSelectsLine; //Field offset: 0x11
	[SerializeField]
	private Color m_CursorColor; //Field offset: 0x14
	[SerializeField]
	private float m_CursorFlashSpeed; //Field offset: 0x24
	[SerializeField]
	private Color m_SelectionColor; //Field offset: 0x28

	public Color cursorColor
	{
		 get { } //Length: 12
	}

	public float cursorFlashSpeed
	{
		 get { } //Length: 60
	}

	public bool doubleClickSelectsWord
	{
		 get { } //Length: 8
	}

	public Color selectionColor
	{
		 get { } //Length: 12
	}

	public bool tripleClickSelectsLine
	{
		 get { } //Length: 8
	}

	public GUISettings() { }

	public Color get_cursorColor() { }

	public float get_cursorFlashSpeed() { }

	public bool get_doubleClickSelectsWord() { }

	public Color get_selectionColor() { }

	public bool get_tripleClickSelectsLine() { }

	private static float Internal_GetCursorFlashSpeed() { }

}

