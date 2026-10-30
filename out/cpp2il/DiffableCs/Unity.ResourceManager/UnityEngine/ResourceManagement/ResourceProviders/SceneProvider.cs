namespace UnityEngine.ResourceManagement.ResourceProviders;

public class SceneProvider : ISceneProvider2, ISceneProvider
{
	private class SceneOp : AsyncOperationBase<SceneInstance>, IUpdateReceiver
	{
		private bool m_ActivateOnLoad; //Field offset: 0xA0
		private SceneInstance m_Inst; //Field offset: 0xA8
		private IResourceLocation m_Location; //Field offset: 0xB8
		private LoadSceneParameters m_LoadSceneParameters; //Field offset: 0xC0
		private int m_Priority; //Field offset: 0xC8
		private AsyncOperationHandle<IList`1<AsyncOperationHandle>> m_DepOp; //Field offset: 0xD0
		private ResourceManager m_ResourceManager; //Field offset: 0xE8
		private ISceneProvider2 m_provider; //Field offset: 0xF0

		protected virtual string DebugName
		{
			 get { } //Length: 164
		}

		protected virtual float Progress
		{
			 get { } //Length: 192
		}

		public SceneOp(ResourceManager rm, ISceneProvider2 provider) { }

		protected virtual void Destroy() { }

		protected virtual void Execute() { }

		protected virtual string get_DebugName() { }

		protected virtual float get_Progress() { }

		public virtual void GetDependencies(List<AsyncOperationHandle> deps) { }

		internal virtual DownloadStatus GetDownloadStatus(HashSet<Object> visited) { }

		public void Init(IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp) { }

		public void Init(IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority, AsyncOperationHandle<IList`1<AsyncOperationHandle>> depOp) { }

		private AsyncOperation InternalLoad(string path, bool loadingFromBundle, LoadSceneParameters loadSceneParameters) { }

		internal SceneInstance InternalLoadScene(IResourceLocation location, bool loadingFromBundle, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority) { }

		protected virtual bool InvokeWaitForCompletion() { }

		private override void UnityEngine.ResourceManagement.IUpdateReceiver.Update(float unscaledDeltaTime) { }

	}

	private class UnloadSceneOp : AsyncOperationBase<SceneInstance>
	{
		private SceneInstance m_Instance; //Field offset: 0xA0
		private AsyncOperationHandle<SceneInstance> m_sceneLoadHandle; //Field offset: 0xB0
		private UnloadSceneOptions m_UnloadOptions; //Field offset: 0xC8

		protected virtual float Progress
		{
			 get { } //Length: 72
		}

		public UnloadSceneOp() { }

		protected virtual void Execute() { }

		protected virtual float get_Progress() { }

		public void Init(AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions options) { }

		protected virtual bool InvokeWaitForCompletion() { }

		private void UnloadSceneCompleted(AsyncOperation obj) { }

	}


	public SceneProvider() { }

	public override AsyncOperationHandle<SceneInstance> ProvideScene(ResourceManager resourceManager, IResourceLocation location, LoadSceneMode loadSceneMode, bool activateOnLoad, int priority) { }

	public override AsyncOperationHandle<SceneInstance> ProvideScene(ResourceManager resourceManager, IResourceLocation location, LoadSceneParameters loadSceneParameters, bool activateOnLoad, int priority) { }

	public override AsyncOperationHandle<SceneInstance> ReleaseScene(ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle) { }

	private override AsyncOperationHandle<SceneInstance> UnityEngine.ResourceManagement.ResourceProviders.ISceneProvider2.ReleaseScene(ResourceManager resourceManager, AsyncOperationHandle<SceneInstance> sceneLoadHandle, UnloadSceneOptions unloadOptions) { }

}

