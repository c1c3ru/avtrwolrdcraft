namespace UnityEngine.AddressableAssets.Initialization;

public class CacheInitialization : IInitializableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public CacheInitialization <>4__this; //Field offset: 0x10
		public string id; //Field offset: 0x18
		public string data; //Field offset: 0x20

		public <>c__DisplayClass1_0() { }

		internal bool <InitializeAsync>b__0() { }

	}

	private class CacheInitOp : AsyncOperationBase<Boolean>, IUpdateReceiver
	{
		private Func<Boolean> m_Callback; //Field offset: 0x98
		private bool m_UpdateRequired; //Field offset: 0xA0

		public CacheInitOp() { }

		protected virtual void Execute() { }

		public void Init(Func<Boolean> callback) { }

		protected virtual bool InvokeWaitForCompletion() { }

		public override void Update(float unscaledDeltaTime) { }

	}


	public static string RootPath
	{
		 get { } //Length: 120
	}

	public CacheInitialization() { }

	public static string get_RootPath() { }

	public override bool Initialize(string id, string dataStr) { }

	public override AsyncOperationHandle<Boolean> InitializeAsync(ResourceManager rm, string id, string data) { }

}

