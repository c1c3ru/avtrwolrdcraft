namespace PWC.QA.RTA;

public static class RTAScreenCapturer
{
	[CompilerGenerated]
	private struct <SaveScreenCaptureAsync>d__0 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder <>t__builder; //Field offset: 0x8
		public string fileName; //Field offset: 0x20
		public string directory; //Field offset: 0x28
		public bool forceOverrideFile; //Field offset: 0x30
		private string <fullPath>5__2; //Field offset: 0x38
		private Texture2D <texture>5__3; //Field offset: 0x40
		private TaskAwaiter <>u__1; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}


	private static string GetNextFreePath_Internal(string fullPath) { }

	[AsyncStateMachine(typeof(<SaveScreenCaptureAsync>d__0))]
	public static Task SaveScreenCaptureAsync(string fileName, string directory, bool forceOverrideFile) { }

}

