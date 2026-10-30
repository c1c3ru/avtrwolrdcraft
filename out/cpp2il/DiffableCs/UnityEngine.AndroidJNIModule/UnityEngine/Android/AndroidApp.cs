namespace UnityEngine.Android;

[NativeConditional("PLATFORM_ANDROID")]
[NativeHeader("Modules/AndroidJNI/Public/AndroidApp.bindings.h")]
[StaticAccessor("AndroidApp", StaticAccessorType::DoubleColon (2))]
internal static class AndroidApp
{
	private static AndroidJavaObject m_Context; //Field offset: 0x0
	private static AndroidJavaObject m_Activity; //Field offset: 0x8

	public static AndroidJavaObject Activity
	{
		 get { } //Length: 76
	}

	public static AndroidJavaObject Context
	{
		 get { } //Length: 76
	}

	public static IntPtr UnityPlayerRaw
	{
		[ThreadSafe]
		 get { } //Length: 40
	}

	private static void AcquireContextAndActivity() { }

	public static AndroidJavaObject get_Activity() { }

	public static AndroidJavaObject get_Context() { }

	[ThreadSafe]
	public static IntPtr get_UnityPlayerRaw() { }

}

