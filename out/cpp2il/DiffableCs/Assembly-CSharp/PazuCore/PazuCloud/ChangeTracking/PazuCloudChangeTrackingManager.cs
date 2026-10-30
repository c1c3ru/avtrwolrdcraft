namespace PazuCore.PazuCloud.ChangeTracking;

public class PazuCloudChangeTrackingManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public string currentHash; //Field offset: 0x10
		public bool isDone; //Field offset: 0x18

		public <>c__DisplayClass6_0() { }

		internal void <CheckDeviceInfo>b__0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public string key; //Field offset: 0x10
		public int currentBuildNumber; //Field offset: 0x18
		public bool isDone; //Field offset: 0x1C

		public <>c__DisplayClass7_0() { }

		internal void <CheckDownload>b__0(Response response) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass8_0() { }

		internal void <SendDeviceInfoToCloud>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public string op; //Field offset: 0x10
		public Action<Response> onResponse; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <SendDownloadToCloud>b__0(string responseText) { }

	}

	[CompilerGenerated]
	private sealed class <CheckDeviceInfo>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudChangeTrackingManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass6_0 <>8__1; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <CheckDeviceInfo>d__6(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <CheckDownload>d__7 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudChangeTrackingManager <>4__this; //Field offset: 0x20
		private <>c__DisplayClass7_0 <>8__1; //Field offset: 0x28

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <CheckDownload>d__7(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	private sealed class <UpdateCloudIfNeeded>d__5 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public PazuCloudChangeTrackingManager <>4__this; //Field offset: 0x20

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <UpdateCloudIfNeeded>d__5(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	internal enum DownloadType
	{
		None = 0,
		Install = 1,
		Update = 2,
	}

	private const string KEYCHAIN_KEY = "PazuCore_ChangeTracking"; //Field offset: 0x0
	private const string PLAYERPREFS_KEY_PREFIX = "PazuCore_ChangeTracking_"; //Field offset: 0x0
	private bool _isInProgress; //Field offset: 0x20

	public PazuCloudChangeTrackingManager() { }

	[IteratorStateMachine(typeof(<CheckDeviceInfo>d__6))]
	private IEnumerator CheckDeviceInfo() { }

	[IteratorStateMachine(typeof(<CheckDownload>d__7))]
	private IEnumerator CheckDownload() { }

	private static string GetBuildNumberKey() { }

	public void OnGameResume() { }

	private void SendDeviceInfoToCloud(DeviceInfo deviceInfo, Action<Response> onResponse) { }

	private void SendDownloadToCloud(DownloadType downloadType, Action<Response> onResponse) { }

	[IteratorStateMachine(typeof(<UpdateCloudIfNeeded>d__5))]
	private IEnumerator UpdateCloudIfNeeded() { }

}

