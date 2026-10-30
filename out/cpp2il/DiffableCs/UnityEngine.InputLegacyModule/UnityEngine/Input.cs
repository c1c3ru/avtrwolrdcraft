namespace UnityEngine;

[NativeHeader("Runtime/Input/InputBindings.h")]
public class Input
{

	[NativeThrows]
	public static bool anyKey
	{
		 get { } //Length: 40
	}

	public static Vector2 compositionCursorPos
	{
		 get { } //Length: 68
		 set { } //Length: 64
	}

	public static string compositionString
	{
		 get { } //Length: 40
	}

	public static DeviceOrientation deviceOrientation
	{
		[FreeFunction("GetDeviceOrientation")]
		 get { } //Length: 40
	}

	public static IMECompositionMode imeCompositionMode
	{
		 get { } //Length: 40
		 set { } //Length: 60
	}

	[NativeThrows]
	public static Vector3 mousePosition
	{
		 get { } //Length: 76
	}

	public static bool mousePresent
	{
		[FreeFunction("GetMousePresent")]
		 get { } //Length: 40
	}

	[NativeThrows]
	public static Vector2 mouseScrollDelta
	{
		 get { } //Length: 68
	}

	public static bool multiTouchEnabled
	{
		[FreeFunction("IsMultiTouchEnabled")]
		 get { } //Length: 40
		[FreeFunction("SetMultiTouchEnabled")]
		 set { } //Length: 60
	}

	public static int touchCount
	{
		[FreeFunction("GetTouchCount")]
		 get { } //Length: 40
	}

	public static Touch[] touches
	{
		 get { } //Length: 320
	}

	public static bool touchSupported
	{
		[FreeFunction("IsTouchSupported")]
		 get { } //Length: 40
	}

	internal static bool CheckDisabled() { }

	[NativeThrows]
	public static void ClearLastPenContactEvent() { }

	public static bool get_anyKey() { }

	public static Vector2 get_compositionCursorPos() { }

	private static void get_compositionCursorPos_Injected(out Vector2 ret) { }

	public static string get_compositionString() { }

	[FreeFunction("GetDeviceOrientation")]
	public static DeviceOrientation get_deviceOrientation() { }

	public static IMECompositionMode get_imeCompositionMode() { }

	public static Vector3 get_mousePosition() { }

	private static void get_mousePosition_Injected(out Vector3 ret) { }

	[FreeFunction("GetMousePresent")]
	public static bool get_mousePresent() { }

	public static Vector2 get_mouseScrollDelta() { }

	private static void get_mouseScrollDelta_Injected(out Vector2 ret) { }

	[FreeFunction("IsMultiTouchEnabled")]
	public static bool get_multiTouchEnabled() { }

	[FreeFunction("GetTouchCount")]
	public static int get_touchCount() { }

	public static Touch[] get_touches() { }

	[FreeFunction("IsTouchSupported")]
	public static bool get_touchSupported() { }

	public static float GetAxis(string axisName) { }

	public static float GetAxisRaw(string axisName) { }

	public static bool GetButton(string buttonName) { }

	public static bool GetButtonDown(string buttonName) { }

	public static bool GetKey(KeyCode key) { }

	public static bool GetKeyDown(KeyCode key) { }

	[NativeThrows]
	private static bool GetKeyDownInt(KeyCode key) { }

	[NativeThrows]
	private static bool GetKeyInt(KeyCode key) { }

	[NativeThrows]
	public static PenData GetLastPenContactEvent() { }

	private static void GetLastPenContactEvent_Injected(out PenData ret) { }

	[NativeThrows]
	public static bool GetMouseButton(int button) { }

	[NativeThrows]
	public static bool GetMouseButtonDown(int button) { }

	[NativeThrows]
	public static bool GetMouseButtonUp(int button) { }

	[NativeThrows]
	public static Touch GetTouch(int index) { }

	private static void GetTouch_Injected(int index, out Touch ret) { }

	public static void set_compositionCursorPos(Vector2 value) { }

	private static void set_compositionCursorPos_Injected(ref Vector2 value) { }

	public static void set_imeCompositionMode(IMECompositionMode value) { }

	[FreeFunction("SetMultiTouchEnabled")]
	public static void set_multiTouchEnabled(bool value) { }

}

