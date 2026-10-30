namespace UnityEngine;

public class AndroidJavaObject : IDisposable
{
	private static bool enableDebugPrints; //Field offset: 0x0
	internal GlobalJavaObjectRef m_jobject; //Field offset: 0x10
	internal GlobalJavaObjectRef m_jclass; //Field offset: 0x18

	private void _AndroidJavaObject(IntPtr constructorID, Object[] args) { }

	private void _AndroidJavaObject(string className, Object[] args) { }

	protected void _Call(string methodName, Object[] args) { }

	protected void _Call(IntPtr methodID, Object[] args) { }

	protected ReturnType _Call(string methodName, Object[] args) { }

	protected ReturnType _Call(IntPtr methodID, Object[] args) { }

	protected ReturnType _CallStatic(IntPtr methodID, Object[] args) { }

	protected ReturnType _CallStatic(string methodName, Object[] args) { }

	protected void _CallStatic(IntPtr methodID, Object[] args) { }

	protected void _CallStatic(string methodName, Object[] args) { }

	protected FieldType _Get(IntPtr fieldID) { }

	protected FieldType _Get(string fieldName) { }

	protected IntPtr _GetRawClass() { }

	protected IntPtr _GetRawObject() { }

	protected FieldType _GetStatic(string fieldName) { }

	protected FieldType _GetStatic(IntPtr fieldID) { }

	protected void _Set(IntPtr fieldID, FieldType val) { }

	protected void _Set(string fieldName, FieldType val) { }

	protected void _SetStatic(string fieldName, FieldType val) { }

	protected void _SetStatic(IntPtr fieldID, FieldType val) { }

	internal AndroidJavaObject() { }

	public AndroidJavaObject(string className, String[] args) { }

	public AndroidJavaObject(string className, AndroidJavaObject[] args) { }

	public AndroidJavaObject(string className, AndroidJavaClass[] args) { }

	public AndroidJavaObject(IntPtr clazz, IntPtr constructorID, Object[] args) { }

	public AndroidJavaObject(IntPtr jobject) { }

	public AndroidJavaObject(string className, AndroidJavaProxy[] args) { }

	public AndroidJavaObject(string className, Object[] args) { }

	public AndroidJavaObject(string className, AndroidJavaRunnable[] args) { }

	internal static AndroidJavaClass AndroidJavaClassDeleteLocalRef(IntPtr jclass) { }

	internal static AndroidJavaObject AndroidJavaObjectDeleteLocalRef(IntPtr jobject) { }

	public ReturnType Call(IntPtr methodID, Object[] args) { }

	public void Call(string methodName, Object[] args) { }

	public void Call(IntPtr methodID, Object[] args) { }

	public void Call(IntPtr methodID, T[] args) { }

	public void Call(string methodName, T[] args) { }

	public ReturnType Call(string methodName, Object[] args) { }

	public ReturnType Call(IntPtr methodID, T[] args) { }

	public ReturnType Call(string methodName, T[] args) { }

	public ReturnType CallStatic(string methodName, Object[] args) { }

	public ReturnType CallStatic(IntPtr methodID, T[] args) { }

	public ReturnType CallStatic(string methodName, T[] args) { }

	public void CallStatic(IntPtr methodID, Object[] args) { }

	public void CallStatic(string methodName, Object[] args) { }

	public void CallStatic(IntPtr methodID, T[] args) { }

	public void CallStatic(string methodName, T[] args) { }

	public ReturnType CallStatic(IntPtr methodID, Object[] args) { }

	public AndroidJavaObject CloneReference() { }

	protected void DebugPrint(string call, string methodName, string signature, Object[] args) { }

	protected void DebugPrint(string msg) { }

	public override void Dispose() { }

	protected override void Dispose(bool disposing) { }

	protected virtual void Finalize() { }

	internal static ReturnType FromJavaArrayDeleteLocalRef(IntPtr jobject) { }

	public FieldType Get(string fieldName) { }

	public FieldType Get(IntPtr fieldID) { }

	public IntPtr GetRawClass() { }

	public IntPtr GetRawObject() { }

	public FieldType GetStatic(string fieldName) { }

	public FieldType GetStatic(IntPtr fieldID) { }

	public void Set(string fieldName, FieldType val) { }

	public void Set(IntPtr fieldID, FieldType val) { }

	public void SetStatic(IntPtr fieldID, FieldType val) { }

	public void SetStatic(string fieldName, FieldType val) { }

}

