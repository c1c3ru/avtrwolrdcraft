namespace PWC.DeliverySystem;

public class DeliverySystemState : ISerializationCallbackReceiver
{
	private const string STATE_KEY = "DeliverySystem_State"; //Field offset: 0x0
	[SerializeField]
	private List<DeliverySystemPackage> _items; //Field offset: 0x10
	private readonly Dictionary<String, DeliverySystemPackage> _hashedItems; //Field offset: 0x18
	[CompilerGenerated]
	private bool <IsDirty>k__BackingField; //Field offset: 0x20

	public bool IsDirty
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public DeliverySystemState() { }

	public void AddItem(DeliverySystemPackage item) { }

	public void DeleteItem(DeliverySystemPackage item) { }

	private static void EnsureFolder() { }

	[CompilerGenerated]
	public bool get_IsDirty() { }

	private static string GetFileDirectory() { }

	private static string GetFilePath() { }

	public static DeliverySystemState LoadCurrentState() { }

	public void SaveStateToDiskIfNeeded() { }

	[CompilerGenerated]
	public void set_IsDirty(bool value) { }

	public bool TryGetItem(string sceneName, out DeliverySystemPackage item) { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnAfterDeserialize() { }

	private override void UnityEngine.ISerializationCallbackReceiver.OnBeforeSerialize() { }

}

