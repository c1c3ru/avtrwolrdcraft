namespace UnityEngine;

[NativeType(CodegenOptions::Custom (1), "ScriptingJNINativeMethod")]
public struct JNINativeMethod
{
	public string name; //Field offset: 0x0
	public string signature; //Field offset: 0x8
	public IntPtr fnPtr; //Field offset: 0x10

}

