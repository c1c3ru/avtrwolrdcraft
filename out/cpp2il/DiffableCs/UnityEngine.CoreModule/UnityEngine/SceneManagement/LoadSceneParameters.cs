namespace UnityEngine.SceneManagement;

public struct LoadSceneParameters
{
	[SerializeField]
	private LoadSceneMode m_LoadSceneMode; //Field offset: 0x0
	[SerializeField]
	private LocalPhysicsMode m_LocalPhysicsMode; //Field offset: 0x4

	public LoadSceneParameters(LoadSceneMode mode) { }

}

