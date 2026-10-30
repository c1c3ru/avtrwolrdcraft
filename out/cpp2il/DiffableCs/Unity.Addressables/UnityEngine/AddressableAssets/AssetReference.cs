namespace UnityEngine.AddressableAssets;

public class AssetReference : IKeyEvaluator
{
	[FormerlySerializedAs("m_assetGUID")]
	[SerializeField]
	protected private string m_AssetGUID; //Field offset: 0x10
	[SerializeField]
	private string m_SubObjectName; //Field offset: 0x18
	[SerializeField]
	private string m_SubObjectType; //Field offset: 0x20
	private AsyncOperationHandle m_Operation; //Field offset: 0x28

	public override object Asset
	{
		 get { } //Length: 160
	}

	public override string AssetGUID
	{
		 get { } //Length: 8
	}

	public bool IsDone
	{
		 get { } //Length: 12
	}

	public internal AsyncOperationHandle OperationHandle
	{
		 get { } //Length: 20
		internal set { } //Length: 32
	}

	public override object RuntimeKey
	{
		 get { } //Length: 164
	}

	public override string SubObjectName
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	internal override Type SubObjectType
	{
		internal get { } //Length: 172
	}

	public AssetReference(string guid) { }

	public AssetReference() { }

	private static AsyncOperationHandle<T> CreateFailedOperation() { }

	public override object get_Asset() { }

	public override string get_AssetGUID() { }

	public bool get_IsDone() { }

	public AsyncOperationHandle get_OperationHandle() { }

	public override object get_RuntimeKey() { }

	public override string get_SubObjectName() { }

	internal override Type get_SubObjectType() { }

	[Obsolete]
	public AsyncOperationHandle<GameObject> Instantiate(Transform parent = null, bool instantiateInWorldSpace = false) { }

	[Obsolete]
	public AsyncOperationHandle<GameObject> Instantiate(Vector3 position, Quaternion rotation, Transform parent = null) { }

	public override AsyncOperationHandle<GameObject> InstantiateAsync(Transform parent = null, bool instantiateInWorldSpace = false) { }

	public override AsyncOperationHandle<GameObject> InstantiateAsync(Vector3 position, Quaternion rotation, Transform parent = null) { }

	public bool IsValid() { }

	[Obsolete]
	public AsyncOperationHandle<TObject> LoadAsset() { }

	public override AsyncOperationHandle<TObject> LoadAssetAsync() { }

	[Obsolete]
	public AsyncOperationHandle<SceneInstance> LoadScene() { }

	public override AsyncOperationHandle<SceneInstance> LoadSceneAsync(LoadSceneMode loadMode = 0, bool activateOnLoad = true, int priority = 100) { }

	public override void ReleaseAsset() { }

	public override void ReleaseInstance(GameObject obj) { }

	public override bool RuntimeKeyIsValid() { }

	internal void set_OperationHandle(AsyncOperationHandle value) { }

	public override void set_SubObjectName(string value) { }

	public virtual string ToString() { }

	public override AsyncOperationHandle<SceneInstance> UnLoadScene() { }

	public override bool ValidateAsset(object obj) { }

	public override bool ValidateAsset(string path) { }

}

