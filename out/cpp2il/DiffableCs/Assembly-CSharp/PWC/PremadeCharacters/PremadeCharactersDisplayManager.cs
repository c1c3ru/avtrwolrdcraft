namespace PWC.PremadeCharacters;

public class PremadeCharactersDisplayManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameObject> <>9__18_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Start>b__18_0(GameObject objectToDestroy) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass19_0() { }

		internal bool <OnIDSubmit>b__0(AvatarSpineData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public string input; //Field offset: 0x10

		public <>c__DisplayClass20_0() { }

		internal bool <OnSkinNameSubmit>b__0(AvatarSpineData x) { }

	}

	[CompilerGenerated]
	private static PremadeCharactersDisplayManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private InputField _idInputField; //Field offset: 0x20
	[SerializeField]
	private InputField _skinNameInputField; //Field offset: 0x28
	[SerializeField]
	private List<GameObject> _objectsToDestroy; //Field offset: 0x30
	[SerializeField]
	private AvatarSpineSkinsManagerBase _characterSkinsManager; //Field offset: 0x38
	[SerializeField]
	private AvatarSpineSkinsManagerBase _babySkinsManager; //Field offset: 0x40
	[SerializeField]
	private AvatarSpineSkinsManagerBase _toddlerSkinsManager; //Field offset: 0x48
	[SerializeField]
	private AvatarSpineSkinsManagerBase _catSkinsManager; //Field offset: 0x50
	[SerializeField]
	private AvatarSpineSkinsManagerBase _dogSkinsManager; //Field offset: 0x58
	[SerializeField]
	private AvatarSpineSkinsManagerBase _horseSkinsManager; //Field offset: 0x60
	private List<AvatarSpineData> _avatarSpineDatas; //Field offset: 0x68
	private int _characterCounter; //Field offset: 0x70
	private int _maxNumberOfPremadeCharacters; //Field offset: 0x74

	public private static PremadeCharactersDisplayManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PremadeCharactersDisplayManager() { }

	private void Awake() { }

	public void CreateNewPremadeCharacter() { }

	public void DeletePremadeCharacter() { }

	public void EditPremadeCharacter() { }

	[CompilerGenerated]
	public static PremadeCharactersDisplayManager get_Instance() { }

	private void InitPremadeCharacter() { }

	private void InitSkinsManager(int id) { }

	private void LoadScene(bool isEditor) { }

	public void NextButton() { }

	private void OnDestroy() { }

	private void OnIDSubmit(string input) { }

	private void OnSkinNameSubmit(string input) { }

	public void PreviousButton() { }

	[CompilerGenerated]
	private static void set_Instance(PremadeCharactersDisplayManager value) { }

	private void SetIDText(int id) { }

	private void Start() { }

}

