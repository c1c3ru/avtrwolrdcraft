namespace PWC.PremadeCharacters;

public class PremadeCarsDisplayManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<GameObject> <>9__11_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <Start>b__11_0(GameObject objectToDestroy) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public int id; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal bool <OnIDSubmit>b__0(AvatarSpineData x) { }

	}

	[CompilerGenerated]
	private static PremadeCarsDisplayManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private InputField _idInputField; //Field offset: 0x20
	[SerializeField]
	private List<GameObject> _objectsToDestroy; //Field offset: 0x28
	[SerializeField]
	private PremadeEditorCarSkinsManager _carSkinsManager; //Field offset: 0x30
	private readonly List<AvatarSpineData> _carSpineDatas; //Field offset: 0x38
	private int _carCounter; //Field offset: 0x40

	public private static PremadeCarsDisplayManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public PremadeCarsDisplayManager() { }

	private void Awake() { }

	public void CreateNewPremadeCar() { }

	public void DeletePremadeCar() { }

	public void EditPremadeCar() { }

	[CompilerGenerated]
	public static PremadeCarsDisplayManager get_Instance() { }

	private void LoadScene(bool isEditor) { }

	public void NextButton() { }

	private void OnDestroy() { }

	private void OnIDSubmit(string input) { }

	private void OpenEditor(int id) { }

	public void PreviousButton() { }

	[CompilerGenerated]
	private static void set_Instance(PremadeCarsDisplayManager value) { }

	private void ShowCurrentCar() { }

	private void Start() { }

	private bool TryCollectCars() { }

}

