namespace PWC.PremadeCharacters;

public class PremadeEditorJsonAssetNameHolder : MonoBehaviour
{
	private const string PREMADE_EDITOR_JSON_NAME_SAVE = "PremadeEditorJsonName"; //Field offset: 0x0
	[CompilerGenerated]
	private static PremadeEditorJsonAssetNameHolder <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private InputField _jsonNameInputField; //Field offset: 0x20
	private string _jsonAssetName; //Field offset: 0x28

	public private static PremadeEditorJsonAssetNameHolder Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PremadeEditorJsonAssetNameHolder() { }

	private void Awake() { }

	[CompilerGenerated]
	public static PremadeEditorJsonAssetNameHolder get_Instance() { }

	public string GetJsonAssetName() { }

	private void LoadJsonName() { }

	private void OnDestroy() { }

	public void SaveJsonName() { }

	[CompilerGenerated]
	private static void set_Instance(PremadeEditorJsonAssetNameHolder value) { }

	private void Start() { }

}

