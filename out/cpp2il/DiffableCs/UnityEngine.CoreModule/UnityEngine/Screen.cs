namespace UnityEngine;

[NativeHeader("Runtime/Graphics/WindowLayout.h")]
[NativeHeader("Runtime/Graphics/ScreenManager.h")]
[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
[StaticAccessor("GetScreenManager()", StaticAccessorType::Dot (0))]
public sealed class Screen
{

	public static bool autorotateToLandscapeLeft
	{
		 get { } //Length: 48
		 set { } //Length: 64
	}

	public static bool autorotateToLandscapeRight
	{
		 get { } //Length: 48
		 set { } //Length: 64
	}

	public static bool autorotateToPortrait
	{
		 get { } //Length: 48
		 set { } //Length: 64
	}

	public static bool autorotateToPortraitUpsideDown
	{
		 get { } //Length: 48
		 set { } //Length: 64
	}

	public static Resolution currentResolution
	{
		 get { } //Length: 68
	}

	public static float dpi
	{
		[NativeName("GetDPI")]
		 get { } //Length: 40
	}

	public static bool fullScreen
	{
		[NativeName("IsFullscreen")]
		 get { } //Length: 40
	}

	public static int height
	{
		[NativeMethod(Name = "GetHeight", IsThreadSafe = True)]
		 get { } //Length: 40
	}

	public static ScreenOrientation orientation
	{
		 get { } //Length: 40
		 set { } //Length: 152
	}

	[NativeProperty("ScreenTimeout")]
	public static int sleepTimeout
	{
		 set { } //Length: 60
	}

	public static int width
	{
		[NativeMethod(Name = "GetWidth", IsThreadSafe = True)]
		 get { } //Length: 40
	}

	public static bool get_autorotateToLandscapeLeft() { }

	public static bool get_autorotateToLandscapeRight() { }

	public static bool get_autorotateToPortrait() { }

	public static bool get_autorotateToPortraitUpsideDown() { }

	public static Resolution get_currentResolution() { }

	private static void get_currentResolution_Injected(out Resolution ret) { }

	[NativeName("GetDPI")]
	public static float get_dpi() { }

	[NativeName("IsFullscreen")]
	public static bool get_fullScreen() { }

	[NativeMethod(Name = "GetHeight", IsThreadSafe = True)]
	public static int get_height() { }

	public static ScreenOrientation get_orientation() { }

	[NativeMethod(Name = "GetWidth", IsThreadSafe = True)]
	public static int get_width() { }

	private static ScreenOrientation GetScreenOrientation() { }

	[NativeName("GetIsOrientationEnabled")]
	private static bool IsOrientationEnabled(EnabledOrientation orient) { }

	private static void RequestOrientation(ScreenOrientation orient) { }

	public static void set_autorotateToLandscapeLeft(bool value) { }

	public static void set_autorotateToLandscapeRight(bool value) { }

	public static void set_autorotateToPortrait(bool value) { }

	public static void set_autorotateToPortraitUpsideDown(bool value) { }

	public static void set_orientation(ScreenOrientation value) { }

	public static void set_sleepTimeout(int value) { }

	[NativeName("SetIsOrientationEnabled")]
	private static void SetOrientationEnabled(EnabledOrientation orient, bool enabled) { }

}

