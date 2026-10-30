namespace UnityEngine.ResourceManagement.ResourceProviders;

public struct SceneInstance
{
	private Scene m_Scene; //Field offset: 0x0
	internal AsyncOperation m_Operation; //Field offset: 0x8

	public internal Scene Scene
	{
		 get { } //Length: 8
		internal set { } //Length: 8
	}

	[Obsolete("Activate() has been deprecated.  Please use ActivateAsync().")]
	public void Activate() { }

	public AsyncOperation ActivateAsync() { }

	public virtual bool Equals(object obj) { }

	public Scene get_Scene() { }

	public virtual int GetHashCode() { }

	internal void set_Scene(Scene value) { }

}

