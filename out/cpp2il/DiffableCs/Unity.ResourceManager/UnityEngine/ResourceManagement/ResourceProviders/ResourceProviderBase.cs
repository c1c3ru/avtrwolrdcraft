namespace UnityEngine.ResourceManagement.ResourceProviders;

public abstract class ResourceProviderBase : IResourceProvider, IInitializableObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public ResourceProviderBase <>4__this; //Field offset: 0x10
		public string id; //Field offset: 0x18
		public string data; //Field offset: 0x20

		public <>c__DisplayClass10_0() { }

		internal bool <InitializeAsync>b__0() { }

	}

	private class BaseInitAsyncOp : AsyncOperationBase<Boolean>
	{
		private Func<Boolean> m_CallBack; //Field offset: 0x98

		public BaseInitAsyncOp() { }

		protected virtual void Execute() { }

		public void Init(Func<Boolean> callback) { }

		protected virtual bool InvokeWaitForCompletion() { }

	}

	protected string m_ProviderId; //Field offset: 0x10
	protected ProviderBehaviourFlags m_BehaviourFlags; //Field offset: 0x18

	public override string ProviderId
	{
		 get { } //Length: 100
	}

	private override ProviderBehaviourFlags UnityEngine.ResourceManagement.ResourceProviders.IResourceProvider.BehaviourFlags
	{
		private get { } //Length: 8
	}

	protected ResourceProviderBase() { }

	public override bool CanProvide(Type t, IResourceLocation location) { }

	public override string get_ProviderId() { }

	public override Type GetDefaultType(IResourceLocation location) { }

	public override bool Initialize(string id, string data) { }

	public override AsyncOperationHandle<Boolean> InitializeAsync(ResourceManager rm, string id, string data) { }

	public abstract void Provide(ProvideHandle provideHandle) { }

	public override void Release(IResourceLocation location, object obj) { }

	public virtual string ToString() { }

	private override ProviderBehaviourFlags UnityEngine.ResourceManagement.ResourceProviders.IResourceProvider.get_BehaviourFlags() { }

}

