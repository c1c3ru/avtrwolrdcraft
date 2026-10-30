namespace PazuCore.PazuCoreAddressables;

public static class AddressablesUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass2_0
	{
		public List<String> catalogsToUpdate; //Field offset: 0x10

		public <>c__DisplayClass2_0() { }

		internal void <UpdateCatalog>b__0(AsyncOperationHandle<List`1<String>> op) { }

	}

	[CompilerGenerated]
	private sealed class <DownloadDependencies>d__1 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public List<String> labels; //Field offset: 0x20
		private bool <isError>5__2; //Field offset: 0x28
		private AsyncOperationHandle<Int64> <getDownloadSize>5__3; //Field offset: 0x30

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
		public <DownloadDependencies>d__1(int <>1__state) { }

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
	private sealed class <InstantiateAsync>d__6 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float timeout; //Field offset: 0x20
		public Action<AsyncOperationHandle`1<GameObject>> onCompleteAction; //Field offset: 0x28
		public string key; //Field offset: 0x30
		private AsyncOperationHandle<GameObject> <handle>5__2; //Field offset: 0x38
		private float <timer>5__3; //Field offset: 0x50

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
		public <InstantiateAsync>d__6(int <>1__state) { }

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
	private sealed class <TryLoadAssetAsync>d__4 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public float timeout; //Field offset: 0x20
		public Action<AsyncOperationHandle`1<GameObject>> onCompleteAction; //Field offset: 0x28
		public string key; //Field offset: 0x30
		private AsyncOperationHandle<GameObject> <handle>5__2; //Field offset: 0x38
		private float <timer>5__3; //Field offset: 0x50

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
		public <TryLoadAssetAsync>d__4(int <>1__state) { }

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
	private sealed class <UpdateCatalog>d__2 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action onFinish; //Field offset: 0x20
		private <>c__DisplayClass2_0 <>8__1; //Field offset: 0x28
		private bool <isError>5__2; //Field offset: 0x30

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
		public <UpdateCatalog>d__2(int <>1__state) { }

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

	public const float ASYNC_OPERATIONS_TIMEOUT = 3; //Field offset: 0x0

	public static void ClearDependencyCacheAsync(string key) { }

	[IteratorStateMachine(typeof(<DownloadDependencies>d__1))]
	public static IEnumerator DownloadDependencies(List<String> labels) { }

	[IteratorStateMachine(typeof(<InstantiateAsync>d__6))]
	public static IEnumerator InstantiateAsync(string key, Action<AsyncOperationHandle`1<GameObject>> onCompleteAction, float timeout) { }

	public static void ReleaseHandle(AsyncOperationHandle handle) { }

	public static void ReleaseInstance(GameObject obj) { }

	[IteratorStateMachine(typeof(<TryLoadAssetAsync>d__4))]
	public static IEnumerator TryLoadAssetAsync(string key, Action<AsyncOperationHandle`1<GameObject>> onCompleteAction, float timeout) { }

	[IteratorStateMachine(typeof(<UpdateCatalog>d__2))]
	public static IEnumerator UpdateCatalog(Action onFinish = null) { }

}

