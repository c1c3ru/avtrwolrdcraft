namespace PWC.PersistentData;

[DisallowMultipleComponent]
public class PDSceneObject : MonoBehaviour
{
	internal sealed class TryOverrideGuidCreationDelegate : MulticastDelegate
	{

		public TryOverrideGuidCreationDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(PDSceneObject sceneObject, out string sceneGuid, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out string sceneGuid, IAsyncResult result) { }

		public override bool Invoke(PDSceneObject sceneObject, out string sceneGuid) { }

	}

	public static readonly Dictionary<String, PDSceneObject> All; //Field offset: 0x0
	[SerializeField]
	private string sceneGuid; //Field offset: 0x20
	public TryOverrideGuidCreationDelegate TryOverrideGuidCreationAction; //Field offset: 0x28

	public string SceneGuid
	{
		 get { } //Length: 8
	}

	private static PDSceneObject() { }

	public PDSceneObject() { }

	private void Awake() { }

	public void EnsureSceneGuid(bool considerMultiplayer = true) { }

	public string get_SceneGuid() { }

	private void OnDestroy() { }

	public void SetSceneGuid(string sceneGuidToAssign) { }

}

