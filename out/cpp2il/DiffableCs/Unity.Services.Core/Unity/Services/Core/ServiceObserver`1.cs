namespace Unity.Services.Core;

public class ServiceObserver : IDisposable
{
	[CompilerGenerated]
	private Action<T> Initialized; //Field offset: 0x0
	[CompilerGenerated]
	private T <Service>k__BackingField; //Field offset: 0x0
	private IUnityServices m_Registry; //Field offset: 0x0

	public event Action<T> Initialized
	{
		[CompilerGenerated]
		 add { } //Length: 216
		[CompilerGenerated]
		 remove { } //Length: 216
	}

	public private T Service
	{
		[CompilerGenerated]
		 get { } //Length: 160
		[CompilerGenerated]
		private set { } //Length: 184
	}

	public ServiceObserver`1() { }

	public ServiceObserver`1(IUnityServices registry) { }

	[CompilerGenerated]
	public void add_Initialized(Action<T> value) { }

	private void AssignService() { }

	public override void Dispose() { }

	[CompilerGenerated]
	public T get_Service() { }

	private void Init() { }

	[CompilerGenerated]
	public void remove_Initialized(Action<T> value) { }

	[CompilerGenerated]
	private void set_Service(T value) { }

}

