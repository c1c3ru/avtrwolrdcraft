namespace UnityEngine;

[NativeConditional("PLATFORM_ANDROID")]
[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType::DoubleColon (2))]
[UsedByNativeCode]
public static class AndroidJNIHelper
{

	public static bool debug
	{
		 get { } //Length: 40
		 set { } //Length: 60
	}

	public static IntPtr Box(sbyte value) { }

	public static IntPtr Box(bool value) { }

	public static IntPtr Box(char value) { }

	public static IntPtr Box(double value) { }

	public static IntPtr Box(float value) { }

	public static IntPtr Box(long value) { }

	public static IntPtr Box(int value) { }

	public static IntPtr Box(short value) { }

	private static IntPtr Box(jvalue val, string boxedClass, string signature) { }

	public static ArrayType ConvertFromJNIArray(IntPtr array) { }

	public static IntPtr ConvertToJNIArray(Array array) { }

	public static IntPtr CreateJavaProxy(AndroidJavaProxy proxy) { }

	public static IntPtr CreateJavaRunnable(AndroidJavaRunnable jrunnable) { }

	public static jvalue[] CreateJNIArgArray(Object[] args) { }

	public static void CreateJNIArgArray(Object[] args, Span<jvalue> jniArgs) { }

	public static void DeleteJNIArgArray(Object[] args, jvalue[] jniArgs) { }

	public static void DeleteJNIArgArray(Object[] args, Span<jvalue> jniArgs) { }

	public static bool get_debug() { }

	public static IntPtr GetConstructorID(IntPtr javaClass) { }

	public static IntPtr GetConstructorID(IntPtr javaClass, string signature) { }

	public static IntPtr GetConstructorID(IntPtr jclass, Object[] args) { }

	public static IntPtr GetFieldID(IntPtr jclass, string fieldName, bool isStatic) { }

	public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, string signature, bool isStatic) { }

	public static IntPtr GetFieldID(IntPtr javaClass, string fieldName, string signature) { }

	public static IntPtr GetFieldID(IntPtr javaClass, string fieldName) { }

	public static IntPtr GetMethodID(IntPtr jclass, string methodName, Object[] args, bool isStatic) { }

	public static IntPtr GetMethodID(IntPtr javaClass, string methodName, string signature) { }

	public static IntPtr GetMethodID(IntPtr javaClass, string methodName, string signature, bool isStatic) { }

	public static IntPtr GetMethodID(IntPtr javaClass, string methodName) { }

	public static IntPtr GetMethodID(IntPtr jclass, string methodName, Object[] args, bool isStatic) { }

	public static string GetSignature(Object[] args) { }

	public static string GetSignature(object obj) { }

	public static string GetSignature(Object[] args) { }

	private static IntPtr GetUnboxMethod(IntPtr obj, string methodName, string signature) { }

	public static void set_debug(bool value) { }

	public static void Unbox(IntPtr obj, out char value) { }

	public static void Unbox(IntPtr obj, out sbyte value) { }

	public static void Unbox(IntPtr obj, out short value) { }

	public static void Unbox(IntPtr obj, out int value) { }

	public static void Unbox(IntPtr obj, out long value) { }

	public static void Unbox(IntPtr obj, out float value) { }

	public static void Unbox(IntPtr obj, out double value) { }

	public static void Unbox(IntPtr obj, out bool value) { }

}

