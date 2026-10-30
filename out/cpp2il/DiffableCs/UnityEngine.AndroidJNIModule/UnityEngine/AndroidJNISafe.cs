namespace UnityEngine;

internal class AndroidJNISafe
{

	public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static void CallStaticVoidMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static void CallVoidMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static void CheckException() { }

	public static void DeleteLocalRef(IntPtr localref) { }

	public static void DeleteWeakGlobalRef(IntPtr globalref) { }

	public static IntPtr FindClass(string name) { }

	public static Boolean[] FromBooleanArray(IntPtr array) { }

	public static Byte[] FromByteArray(IntPtr array) { }

	public static Char[] FromCharArray(IntPtr array) { }

	public static Double[] FromDoubleArray(IntPtr array) { }

	public static Single[] FromFloatArray(IntPtr array) { }

	public static Int32[] FromIntArray(IntPtr array) { }

	public static Int64[] FromLongArray(IntPtr array) { }

	public static IntPtr FromReflectedMethod(IntPtr refMethod) { }

	public static SByte[] FromSByteArray(IntPtr array) { }

	public static Int16[] FromShortArray(IntPtr array) { }

	public static int GetArrayLength(IntPtr array) { }

	public static bool GetBooleanField(IntPtr obj, IntPtr fieldID) { }

	public static char GetCharField(IntPtr obj, IntPtr fieldID) { }

	public static double GetDoubleField(IntPtr obj, IntPtr fieldID) { }

	public static IntPtr GetFieldID(IntPtr clazz, string name, string sig) { }

	public static float GetFloatField(IntPtr obj, IntPtr fieldID) { }

	public static int GetIntField(IntPtr obj, IntPtr fieldID) { }

	public static long GetLongField(IntPtr obj, IntPtr fieldID) { }

	public static IntPtr GetMethodID(IntPtr obj, string name, string sig) { }

	public static IntPtr GetObjectArrayElement(IntPtr array, int index) { }

	public static IntPtr GetObjectClass(IntPtr ptr) { }

	public static IntPtr GetObjectField(IntPtr obj, IntPtr fieldID) { }

	public static sbyte GetSByteField(IntPtr obj, IntPtr fieldID) { }

	public static short GetShortField(IntPtr obj, IntPtr fieldID) { }

	public static bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID) { }

	public static char GetStaticCharField(IntPtr clazz, IntPtr fieldID) { }

	public static double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID) { }

	public static IntPtr GetStaticFieldID(IntPtr clazz, string name, string sig) { }

	public static float GetStaticFloatField(IntPtr clazz, IntPtr fieldID) { }

	public static int GetStaticIntField(IntPtr clazz, IntPtr fieldID) { }

	public static long GetStaticLongField(IntPtr clazz, IntPtr fieldID) { }

	public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) { }

	public static IntPtr GetStaticObjectField(IntPtr clazz, IntPtr fieldID) { }

	public static sbyte GetStaticSByteField(IntPtr clazz, IntPtr fieldID) { }

	public static short GetStaticShortField(IntPtr clazz, IntPtr fieldID) { }

	public static string GetStaticStringField(IntPtr clazz, IntPtr fieldID) { }

	public static string GetStringChars(IntPtr str) { }

	public static string GetStringField(IntPtr obj, IntPtr fieldID) { }

	public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static IntPtr NewString(string chars) { }

	public static void QueueDeleteGlobalRef(IntPtr globalref) { }

	public static void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val) { }

	public static void SetCharField(IntPtr obj, IntPtr fieldID, char val) { }

	public static void SetDoubleField(IntPtr obj, IntPtr fieldID, double val) { }

	public static void SetFloatField(IntPtr obj, IntPtr fieldID, float val) { }

	public static void SetIntField(IntPtr obj, IntPtr fieldID, int val) { }

	public static void SetLongField(IntPtr obj, IntPtr fieldID, long val) { }

	public static void SetObjectField(IntPtr obj, IntPtr fieldID, IntPtr val) { }

	public static void SetSByteField(IntPtr obj, IntPtr fieldID, sbyte val) { }

	public static void SetShortField(IntPtr obj, IntPtr fieldID, short val) { }

	public static void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool val) { }

	public static void SetStaticCharField(IntPtr clazz, IntPtr fieldID, char val) { }

	public static void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double val) { }

	public static void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float val) { }

	public static void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int val) { }

	public static void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long val) { }

	public static void SetStaticObjectField(IntPtr clazz, IntPtr fieldID, IntPtr val) { }

	public static void SetStaticSByteField(IntPtr clazz, IntPtr fieldID, sbyte val) { }

	public static void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short val) { }

	public static void SetStaticStringField(IntPtr clazz, IntPtr fieldID, string val) { }

	public static void SetStringField(IntPtr obj, IntPtr fieldID, string val) { }

	public static IntPtr ToBooleanArray(Boolean[] array) { }

	public static IntPtr ToByteArray(Byte[] array) { }

	public static IntPtr ToCharArray(Char[] array) { }

	public static IntPtr ToDoubleArray(Double[] array) { }

	public static IntPtr ToFloatArray(Single[] array) { }

	public static IntPtr ToIntArray(Int32[] array) { }

	public static IntPtr ToLongArray(Int64[] array) { }

	public static IntPtr ToObjectArray(IntPtr[] array, IntPtr type) { }

	public static IntPtr ToSByteArray(SByte[] array) { }

	public static IntPtr ToShortArray(Int16[] array) { }

}

