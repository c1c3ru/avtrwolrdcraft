namespace PazuCore;

public class BlackFridayManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Boolean> <>9__17_0; //Field offset: 0x8
		public static Func<Boolean> <>9__17_1; //Field offset: 0x10
		public static Func<Boolean> <>9__17_2; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <OnBlackFridayProductAvailableInternal>b__17_0() { }

		internal bool <OnBlackFridayProductAvailableInternal>b__17_1() { }

		internal bool <OnBlackFridayProductAvailableInternal>b__17_2() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public string productId; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal bool <OnPurchaseUserCancelled>b__0(Product x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public Data newData; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal void <OnBlackFridayProductAvailableInternal>b__3(Data data) { }

	}

	[CompilerGenerated]
	private sealed class <DownloadData>d__15 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public Action<Data> assign; //Field offset: 0x20
		private UnityWebRequest <request>5__2; //Field offset: 0x28

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
		public <DownloadData>d__15(int <>1__state) { }

		private void <>m__Finally1() { }

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
	private sealed class <DownloadOrLoadTextures>d__18 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BlackFridayManager <>4__this; //Field offset: 0x20
		public Data data; //Field offset: 0x28

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
		public <DownloadOrLoadTextures>d__18(int <>1__state) { }

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
	private sealed class <DownloadTexture>d__19 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public string textureName; //Field offset: 0x20
		public Action<String> onFinish; //Field offset: 0x28
		public string url; //Field offset: 0x30

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
		public <DownloadTexture>d__19(int <>1__state) { }

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
	private sealed class <OnBlackFridayProductAvailableInternal>d__17 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		private <>c__DisplayClass17_0 <>8__1; //Field offset: 0x20
		public BlackFridayManager <>4__this; //Field offset: 0x28

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
		public <OnBlackFridayProductAvailableInternal>d__17(int <>1__state) { }

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

	internal class Data
	{
		public string version; //Field offset: 0x10
		public string buyButtonTextureUrl; //Field offset: 0x18
		public string backgroundTextureUrl; //Field offset: 0x20

		public Data() { }

	}

	private const string SERVER_DATA_URL = "https://s3.amazonaws.com/PazuPazu/YellowStar/blackfriday.json"; //Field offset: 0x0
	public static BlackFridayManager instance; //Field offset: 0x0
	[CompilerGenerated]
	private string <BgTextureName>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <ButtonTextureName>k__BackingField; //Field offset: 0x28
	private bool _didOnBlackFridayProductAvailableCall; //Field offset: 0x30

	public private string BgTextureName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private string ButtonTextureName
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public BlackFridayManager() { }

	[CompilerGenerated]
	private void <DownloadOrLoadTextures>b__18_0(string textureName) { }

	[CompilerGenerated]
	private void <DownloadOrLoadTextures>b__18_1(string textureName) { }

	private void Awake() { }

	[IteratorStateMachine(typeof(<DownloadData>d__15))]
	private IEnumerator DownloadData(Action<Data> assign) { }

	[IteratorStateMachine(typeof(<DownloadOrLoadTextures>d__18))]
	private IEnumerator DownloadOrLoadTextures(Data data) { }

	[IteratorStateMachine(typeof(<DownloadTexture>d__19))]
	private IEnumerator DownloadTexture(string textureName, string url, Action<String> onFinish) { }

	[CompilerGenerated]
	public string get_BgTextureName() { }

	[CompilerGenerated]
	public string get_ButtonTextureName() { }

	public bool IsAvalible() { }

	public void OnBlackFridayProductAvailable() { }

	[IteratorStateMachine(typeof(<OnBlackFridayProductAvailableInternal>d__17))]
	private IEnumerator OnBlackFridayProductAvailableInternal() { }

	private void OnDestroy() { }

	private void OnPurchaseUserCancelled(string productId) { }

	[CompilerGenerated]
	private void set_BgTextureName(string value) { }

	[CompilerGenerated]
	private void set_ButtonTextureName(string value) { }

}

