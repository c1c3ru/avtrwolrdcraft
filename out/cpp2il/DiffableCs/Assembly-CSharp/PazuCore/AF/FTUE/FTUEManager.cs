namespace PazuCore.AF.FTUE;

public class FTUEManager : AddressablesFeatureBase
{
	[CompilerGenerated]
	private sealed class <WaitForPreparationAndLoadScene>d__14 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public FTUEManager <>4__this; //Field offset: 0x20
		private float <timer>5__2; //Field offset: 0x28

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
		public <WaitForPreparationAndLoadScene>d__14(int <>1__state) { }

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
	private static FTUEManager <Instance>k__BackingField; //Field offset: 0x0
	private bool _didCallPrepareOnInitialized; //Field offset: 0x75
	[CompilerGenerated]
	private int <NextSceneIndex>k__BackingField; //Field offset: 0x78

	public private static FTUEManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public private int NextSceneIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public FTUEManager() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public static FTUEManager get_Instance() { }

	[CompilerGenerated]
	public int get_NextSceneIndex() { }

	protected virtual string GetFallbackResourcesPath() { }

	protected virtual string GetFeatureCloudResponseKey() { }

	protected virtual string GetFeatureKey() { }

	public virtual AddressablesFeatureType GetFeatureType() { }

	public void LoadFTUEFromPreparedData() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnInitialized() { }

	[CompilerGenerated]
	private static void set_Instance(FTUEManager value) { }

	[CompilerGenerated]
	private void set_NextSceneIndex(int value) { }

	[IteratorStateMachine(typeof(<WaitForPreparationAndLoadScene>d__14))]
	private IEnumerator WaitForPreparationAndLoadScene() { }

}

