namespace UnityEngine;

[NativeHeader("Runtime/Misc/AsyncOperation.h")]
[NativeHeader("Runtime/Export/Scripting/AsyncOperation.bindings.h")]
[RequiredByNativeCode]
public class AsyncOperation : YieldInstruction
{
	internal IntPtr m_Ptr; //Field offset: 0x10
	private Action<AsyncOperation> m_completeCallback; //Field offset: 0x18

	public event Action<AsyncOperation> completed
	{
		 add { } //Length: 252
		 remove { } //Length: 168
	}

	public bool allowSceneActivation
	{
		[NativeMethod("GetAllowSceneActivation")]
		 get { } //Length: 60
		[NativeMethod("SetAllowSceneActivation")]
		 set { } //Length: 68
	}

	public bool isDone
	{
		[NativeMethod("IsDone")]
		 get { } //Length: 60
	}

	public int priority
	{
		[NativeMethod("SetPriority")]
		 set { } //Length: 68
	}

	public float progress
	{
		[NativeMethod("GetProgress")]
		 get { } //Length: 60
	}

	public AsyncOperation() { }

	public void add_completed(Action<AsyncOperation> value) { }

	protected virtual void Finalize() { }

	[NativeMethod("GetAllowSceneActivation")]
	public bool get_allowSceneActivation() { }

	[NativeMethod("IsDone")]
	public bool get_isDone() { }

	[NativeMethod("GetProgress")]
	public float get_progress() { }

	[NativeMethod(IsThreadSafe = True)]
	[StaticAccessor("AsyncOperationBindings", StaticAccessorType::DoubleColon (2))]
	private static void InternalDestroy(IntPtr ptr) { }

	[RequiredByNativeCode]
	internal void InvokeCompletionEvent() { }

	public void remove_completed(Action<AsyncOperation> value) { }

	[NativeMethod("SetAllowSceneActivation")]
	public void set_allowSceneActivation(bool value) { }

	[NativeMethod("SetPriority")]
	public void set_priority(int value) { }

}

