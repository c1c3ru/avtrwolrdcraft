namespace UnityEngine;

[NativeConditional("PLATFORM_ANDROID")]
[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType::DoubleColon (2))]
public static class AndroidJNI
{

	[ThreadSafe]
	public static IntPtr AllocObject(IntPtr clazz) { }

	[ThreadSafe]
	public static int AttachCurrentThread() { }

	public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static bool CallBooleanMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	[Obsolete("AndroidJNI.CallByteMethod is obsolete. Use AndroidJNI.CallSByteMethod method instead")]
	public static byte CallByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static char CallCharMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static char CallCharMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static double CallDoubleMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static float CallFloatMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static float CallFloatMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static int CallIntMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static int CallIntMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static long CallLongMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static long CallLongMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static IntPtr CallObjectMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static sbyte CallSByteMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static short CallShortMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static short CallShortMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static bool CallStaticBooleanMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	[Obsolete("AndroidJNI.CallStaticByteMethod is obsolete. Use AndroidJNI.CallStaticSByteMethod method instead")]
	public static byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static char CallStaticCharMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static double CallStaticDoubleMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static float CallStaticFloatMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static int CallStaticIntMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static long CallStaticLongMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static IntPtr CallStaticObjectMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static sbyte CallStaticSByteMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static short CallStaticShortMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static string CallStaticStringMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static void CallStaticVoidMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static string CallStringMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static void CallVoidMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static void CallVoidMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	[ThreadSafe]
	public static void CallVoidMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	[ThreadSafe]
	private static IntPtr ConvertToBooleanArray(Boolean[] array) { }

	[ThreadSafe]
	public static void DeleteGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static void DeleteLocalRef(IntPtr obj) { }

	[ThreadSafe]
	public static void DeleteWeakGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static int DetachCurrentThread() { }

	[ThreadSafe]
	public static int EnsureLocalCapacity(int capacity) { }

	[ThreadSafe]
	public static void ExceptionClear() { }

	[ThreadSafe]
	public static void ExceptionDescribe() { }

	[ThreadSafe]
	public static IntPtr ExceptionOccurred() { }

	[ThreadSafe]
	public static void FatalError(string message) { }

	[ThreadSafe]
	public static IntPtr FindClass(string name) { }

	[ThreadSafe]
	public static Boolean[] FromBooleanArray(IntPtr array) { }

	[Obsolete("AndroidJNI.FromByteArray is obsolete. Use AndroidJNI.FromSByteArray method instead")]
	[ThreadSafe]
	public static Byte[] FromByteArray(IntPtr array) { }

	[ThreadSafe]
	public static Char[] FromCharArray(IntPtr array) { }

	[ThreadSafe]
	public static Double[] FromDoubleArray(IntPtr array) { }

	[ThreadSafe]
	public static Single[] FromFloatArray(IntPtr array) { }

	[ThreadSafe]
	public static Int32[] FromIntArray(IntPtr array) { }

	[ThreadSafe]
	public static Int64[] FromLongArray(IntPtr array) { }

	[ThreadSafe]
	public static IntPtr[] FromObjectArray(IntPtr array) { }

	[ThreadSafe]
	public static IntPtr FromReflectedField(IntPtr refField) { }

	[ThreadSafe]
	public static IntPtr FromReflectedMethod(IntPtr refMethod) { }

	[ThreadSafe]
	public static SByte[] FromSByteArray(IntPtr array) { }

	[ThreadSafe]
	public static Int16[] FromShortArray(IntPtr array) { }

	[ThreadSafe]
	public static int GetArrayLength(IntPtr array) { }

	[ThreadSafe]
	public static bool GetBooleanArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static bool GetBooleanField(IntPtr obj, IntPtr fieldID) { }

	[Obsolete("AndroidJNI.GetByteArrayElement is obsolete. Use AndroidJNI.GetSByteArrayElement method instead")]
	public static byte GetByteArrayElement(IntPtr array, int index) { }

	[Obsolete("AndroidJNI.GetByteField is obsolete. Use AndroidJNI.GetSByteField method instead")]
	public static byte GetByteField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static char GetCharArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static char GetCharField(IntPtr obj, IntPtr fieldID) { }

	private static NativeArray<T> GetDirectBuffer(IntPtr buffer) { }

	[ThreadSafe]
	public static SByte* GetDirectBufferAddress(IntPtr buffer) { }

	[ThreadSafe]
	public static long GetDirectBufferCapacity(IntPtr buffer) { }

	public static NativeArray<Byte> GetDirectByteBuffer(IntPtr buffer) { }

	public static NativeArray<SByte> GetDirectSByteBuffer(IntPtr buffer) { }

	[ThreadSafe]
	public static double GetDoubleArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static double GetDoubleField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static IntPtr GetFieldID(IntPtr clazz, string name, string sig) { }

	[ThreadSafe]
	public static float GetFloatArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static float GetFloatField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static int GetIntArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static int GetIntField(IntPtr obj, IntPtr fieldID) { }

	[StaticAccessor("jni", StaticAccessorType::DoubleColon (2))]
	[ThreadSafe]
	public static IntPtr GetJavaVM() { }

	[ThreadSafe]
	public static long GetLongArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static long GetLongField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static IntPtr GetMethodID(IntPtr clazz, string name, string sig) { }

	[ThreadSafe]
	public static IntPtr GetObjectArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static IntPtr GetObjectClass(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	internal static uint GetQueueGlobalRefsCount() { }

	[ThreadSafe]
	public static sbyte GetSByteArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static sbyte GetSByteField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static short GetShortArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static short GetShortField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID) { }

	[Obsolete("AndroidJNI.GetStaticByteField is obsolete. Use AndroidJNI.GetStaticSByteField method instead")]
	public static byte GetStaticByteField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static char GetStaticCharField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig) { }

	[ThreadSafe]
	public static float GetStaticFloatField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static int GetStaticIntField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static long GetStaticLongField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) { }

	[ThreadSafe]
	public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static sbyte GetStaticSByteField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static short GetStaticShortField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static string GetStaticStringField(IntPtr clazz, IntPtr fieldID) { }

	[ThreadSafe]
	public static string GetStringChars(IntPtr str) { }

	[ThreadSafe]
	public static string GetStringField(IntPtr obj, IntPtr fieldID) { }

	[ThreadSafe]
	public static int GetStringLength(IntPtr str) { }

	[ThreadSafe]
	public static string GetStringUTFChars(IntPtr str) { }

	[ThreadSafe]
	public static int GetStringUTFLength(IntPtr str) { }

	[ThreadSafe]
	public static IntPtr GetSuperclass(IntPtr clazz) { }

	[ThreadSafe]
	public static int GetVersion() { }

	[ThreadSafe]
	public static bool IsAssignableFrom(IntPtr clazz1, IntPtr clazz2) { }

	[ThreadSafe]
	public static bool IsInstanceOf(IntPtr obj, IntPtr clazz) { }

	[ThreadSafe]
	public static bool IsSameObject(IntPtr obj1, IntPtr obj2) { }

	[ThreadSafe]
	public static IntPtr NewBooleanArray(int size) { }

	[Obsolete("AndroidJNI.NewByteArray is obsolete. Use AndroidJNI.NewSByteArray method instead")]
	public static IntPtr NewByteArray(int size) { }

	[ThreadSafe]
	public static IntPtr NewCharArray(int size) { }

	public static IntPtr NewDirectByteBuffer(NativeArray<SByte> buffer) { }

	[ThreadSafe]
	public static IntPtr NewDirectByteBuffer(Byte* buffer, long capacity) { }

	public static IntPtr NewDirectByteBuffer(NativeArray<Byte> buffer) { }

	private static IntPtr NewDirectByteBufferFromNativeArray(NativeArray<T> buffer) { }

	[ThreadSafe]
	public static IntPtr NewDoubleArray(int size) { }

	[ThreadSafe]
	public static IntPtr NewFloatArray(int size) { }

	[ThreadSafe]
	public static IntPtr NewGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr NewIntArray(int size) { }

	[ThreadSafe]
	public static IntPtr NewLocalRef(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr NewLongArray(int size) { }

	public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static IntPtr NewObjectA(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	[ThreadSafe]
	public static IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr NewSByteArray(int size) { }

	[ThreadSafe]
	public static IntPtr NewShortArray(int size) { }

	public static IntPtr NewString(string chars) { }

	[ThreadSafe]
	public static IntPtr NewString(Char[] chars) { }

	[ThreadSafe]
	private static IntPtr NewStringFromStr(string chars) { }

	[ThreadSafe]
	public static IntPtr NewStringUTF(string bytes) { }

	[ThreadSafe]
	public static IntPtr NewWeakGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr PopLocalFrame(IntPtr ptr) { }

	[ThreadSafe]
	public static int PushLocalFrame(int capacity) { }

	[ThreadSafe]
	internal static void QueueDeleteGlobalRef(IntPtr obj) { }

	public static int RegisterNatives(IntPtr clazz, JNINativeMethod[] methods) { }

	[ThreadSafe]
	private static IntPtr RegisterNativesAllocate(int length) { }

	[ThreadSafe]
	private static int RegisterNativesAndFree(IntPtr clazz, IntPtr natives, int n) { }

	[ThreadSafe]
	private static void RegisterNativesSet(IntPtr natives, int idx, string name, string signature, IntPtr fnPtr) { }

	[Obsolete("AndroidJNI.SetBooleanArrayElement(IntPtr, int, byte) is obsolete. Use AndroidJNI.SetBooleanArrayElement(IntPtr, int, bool) method instead")]
	public static void SetBooleanArrayElement(IntPtr array, int index, byte val) { }

	[ThreadSafe]
	public static void SetBooleanArrayElement(IntPtr array, int index, bool val) { }

	[ThreadSafe]
	public static void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val) { }

	[Obsolete("AndroidJNI.SetByteArrayElement is obsolete. Use AndroidJNI.SetSByteArrayElement method instead")]
	public static void SetByteArrayElement(IntPtr array, int index, sbyte val) { }

	[Obsolete("AndroidJNI.SetByteField is obsolete. Use AndroidJNI.SetSByteField method instead")]
	public static void SetByteField(IntPtr obj, IntPtr fieldID, byte val) { }

	[ThreadSafe]
	public static void SetCharArrayElement(IntPtr array, int index, char val) { }

	[ThreadSafe]
	public static void SetCharField(IntPtr obj, IntPtr fieldID, char val) { }

	[ThreadSafe]
	public static void SetDoubleArrayElement(IntPtr array, int index, double val) { }

	[ThreadSafe]
	public static void SetDoubleField(IntPtr obj, IntPtr fieldID, double val) { }

	[ThreadSafe]
	public static void SetFloatArrayElement(IntPtr array, int index, float val) { }

	[ThreadSafe]
	public static void SetFloatField(IntPtr obj, IntPtr fieldID, float val) { }

	[ThreadSafe]
	public static void SetIntArrayElement(IntPtr array, int index, int val) { }

	[ThreadSafe]
	public static void SetIntField(IntPtr obj, IntPtr fieldID, int val) { }

	[ThreadSafe]
	public static void SetLongArrayElement(IntPtr array, int index, long val) { }

	[ThreadSafe]
	public static void SetLongField(IntPtr obj, IntPtr fieldID, long val) { }

	[ThreadSafe]
	public static void SetObjectArrayElement(IntPtr array, int index, IntPtr obj) { }

	[ThreadSafe]
	public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val) { }

	[ThreadSafe]
	public static void SetSByteArrayElement(IntPtr array, int index, sbyte val) { }

	[ThreadSafe]
	public static void SetSByteField(IntPtr obj, IntPtr fieldID, sbyte val) { }

	[ThreadSafe]
	public static void SetShortArrayElement(IntPtr array, int index, short val) { }

	[ThreadSafe]
	public static void SetShortField(IntPtr obj, IntPtr fieldID, short val) { }

	[ThreadSafe]
	public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val) { }

	[Obsolete("AndroidJNI.SetStaticByteField is obsolete. Use AndroidJNI.SetStaticSByteField method instead")]
	public static void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte val) { }

	[ThreadSafe]
	public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val) { }

	[ThreadSafe]
	public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val) { }

	[ThreadSafe]
	public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val) { }

	[ThreadSafe]
	public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val) { }

	[ThreadSafe]
	public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val) { }

	[ThreadSafe]
	public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val) { }

	[ThreadSafe]
	public static void SetStaticSByteField(IntPtr clazz, IntPtr fieldID, sbyte val) { }

	[ThreadSafe]
	public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val) { }

	[ThreadSafe]
	public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val) { }

	[ThreadSafe]
	public static void SetStringField(IntPtr obj, IntPtr fieldID, string val) { }

	[ThreadSafe]
	public static int Throw(IntPtr obj) { }

	[ThreadSafe]
	public static int ThrowNew(IntPtr clazz, string message) { }

	public static IntPtr ToBooleanArray(Boolean[] array) { }

	[Obsolete("AndroidJNI.ToByteArray is obsolete. Use AndroidJNI.ToSByteArray method instead")]
	[ThreadSafe]
	public static IntPtr ToByteArray(Byte[] array) { }

	[ThreadSafe]
	public static IntPtr ToCharArray(Char* array, int length) { }

	public static IntPtr ToCharArray(Char[] array) { }

	public static IntPtr ToDoubleArray(Double[] array) { }

	[ThreadSafe]
	public static IntPtr ToDoubleArray(Double* array, int length) { }

	[ThreadSafe]
	public static IntPtr ToFloatArray(Single* array, int length) { }

	public static IntPtr ToFloatArray(Single[] array) { }

	[ThreadSafe]
	public static IntPtr ToIntArray(Int32* array, int length) { }

	public static IntPtr ToIntArray(Int32[] array) { }

	[ThreadSafe]
	public static IntPtr ToLongArray(Int64* array, int length) { }

	public static IntPtr ToLongArray(Int64[] array) { }

	public static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass) { }

	[ThreadSafe]
	public static IntPtr ToObjectArray(IntPtr* array, int length, IntPtr arrayClass) { }

	public static IntPtr ToObjectArray(IntPtr[] array) { }

	[ThreadSafe]
	public static IntPtr ToReflectedField(IntPtr clazz, IntPtr fieldID, bool isStatic) { }

	[ThreadSafe]
	public static IntPtr ToReflectedMethod(IntPtr clazz, IntPtr methodID, bool isStatic) { }

	[ThreadSafe]
	public static IntPtr ToSByteArray(SByte* array, int length) { }

	public static IntPtr ToSByteArray(SByte[] array) { }

	[ThreadSafe]
	public static IntPtr ToShortArray(Int16* array, int length) { }

	public static IntPtr ToShortArray(Int16[] array) { }

	[ThreadSafe]
	public static int UnregisterNatives(IntPtr clazz) { }

}

