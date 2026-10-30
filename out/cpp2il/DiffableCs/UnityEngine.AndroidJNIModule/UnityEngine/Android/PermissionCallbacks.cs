namespace UnityEngine.Android;

public class PermissionCallbacks : AndroidJavaProxy
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<String> PermissionGranted; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<String> PermissionDenied; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private Action<String> PermissionDeniedAndDontAskAgain; //Field offset: 0x30

	public event Action<String> PermissionDenied
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<String> PermissionDeniedAndDontAskAgain
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<String> PermissionGranted
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public PermissionCallbacks() { }

	[CompilerGenerated]
	public void add_PermissionDenied(Action<String> value) { }

	[CompilerGenerated]
	public void add_PermissionDeniedAndDontAskAgain(Action<String> value) { }

	[CompilerGenerated]
	public void add_PermissionGranted(Action<String> value) { }

	[Preserve]
	private void onPermissionDenied(string permissionName) { }

	[Preserve]
	private void onPermissionDeniedAndDontAskAgain(string permissionName) { }

	[Preserve]
	private void onPermissionGranted(string permissionName) { }

	[CompilerGenerated]
	public void remove_PermissionDenied(Action<String> value) { }

	[CompilerGenerated]
	public void remove_PermissionDeniedAndDontAskAgain(Action<String> value) { }

	[CompilerGenerated]
	public void remove_PermissionGranted(Action<String> value) { }

}

