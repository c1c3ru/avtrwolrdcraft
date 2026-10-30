namespace UnityEngine;

[NativeConditional("ENABLE_ONSCREEN_KEYBOARD")]
[NativeHeader("Runtime/Export/TouchScreenKeyboard/TouchScreenKeyboard.bindings.h")]
[NativeHeader("Runtime/Input/KeyboardOnScreen.h")]
public class TouchScreenKeyboard
{
	internal enum Status
	{
		Visible = 0,
		Done = 1,
		Canceled = 2,
		LostFocus = 3,
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static bool <disableInPlaceEditing>k__BackingField; //Field offset: 0x0
	internal IntPtr m_Ptr; //Field offset: 0x10

	public bool active
	{
		[NativeName("IsActive")]
		 get { } //Length: 60
		[NativeName("SetActive")]
		 set { } //Length: 68
	}

	public bool canGetSelection
	{
		[NativeName("CanGetSelection")]
		 get { } //Length: 60
	}

	public bool canSetSelection
	{
		[NativeName("CanSetSelection")]
		 get { } //Length: 60
	}

	public int characterLimit
	{
		[NativeName("SetCharacterLimit")]
		 set { } //Length: 68
	}

	internal static bool disableInPlaceEditing
	{
		[CompilerGenerated]
		internal get { } //Length: 72
	}

	public static bool hideInput
	{
		[NativeName("SetInputHidden")]
		 set { } //Length: 60
	}

	public static bool isInPlaceEditingAllowed
	{
		 get { } //Length: 108
	}

	internal static bool isRequiredToForceOpen
	{
		internal get { } //Length: 40
	}

	public static bool isSupported
	{
		 get { } //Length: 172
	}

	public RangeInt selection
	{
		 get { } //Length: 76
		 set { } //Length: 244
	}

	public Status status
	{
		[NativeName("GetKeyboardStatus")]
		 get { } //Length: 60
	}

	public string text
	{
		[NativeName("GetText")]
		 get { } //Length: 60
		[NativeName("SetText")]
		 set { } //Length: 68
	}

	public TouchScreenKeyboard(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder, int characterLimit) { }

	private void Destroy() { }

	protected virtual void Finalize() { }

	[NativeName("IsActive")]
	public bool get_active() { }

	[NativeName("CanGetSelection")]
	public bool get_canGetSelection() { }

	[NativeName("CanSetSelection")]
	public bool get_canSetSelection() { }

	[CompilerGenerated]
	internal static bool get_disableInPlaceEditing() { }

	public static bool get_isInPlaceEditingAllowed() { }

	internal static bool get_isRequiredToForceOpen() { }

	public static bool get_isSupported() { }

	public RangeInt get_selection() { }

	[NativeName("GetKeyboardStatus")]
	public Status get_status() { }

	[NativeName("GetText")]
	public string get_text() { }

	private static void GetSelection(out int start, out int length) { }

	[FreeFunction("TouchScreenKeyboard_Destroy", IsThreadSafe = True)]
	private static void Internal_Destroy(IntPtr ptr) { }

	[FreeFunction("TouchScreenKeyboard_IsInplaceEditingAllowed")]
	private static bool IsInPlaceEditingAllowed() { }

	[FreeFunction("TouchScreenKeyboard_IsRequiredToForceOpen")]
	private static bool IsRequiredToForceOpen() { }

	[ExcludeFromDocs]
	public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure) { }

	public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder, int characterLimit) { }

	[NativeName("SetActive")]
	public void set_active(bool value) { }

	[NativeName("SetCharacterLimit")]
	public void set_characterLimit(int value) { }

	[NativeName("SetInputHidden")]
	public static void set_hideInput(bool value) { }

	public void set_selection(RangeInt value) { }

	[NativeName("SetText")]
	public void set_text(string value) { }

	private static void SetSelection(int start, int length) { }

	[FreeFunction("TouchScreenKeyboard_InternalConstructorHelper")]
	private static IntPtr TouchScreenKeyboard_InternalConstructorHelper(ref TouchScreenKeyboard_InternalConstructorHelperArguments arguments, string text, string textPlaceholder) { }

}

