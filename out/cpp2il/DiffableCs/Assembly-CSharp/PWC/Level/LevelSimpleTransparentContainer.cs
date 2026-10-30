namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelSimpleTransparentContainer : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _insideDropArea; //Field offset: 0x28
	[CompilerGenerated]
	private Action<List`1<LevelItem>, Boolean> OnDoorChangeStateAction; //Field offset: 0x30

	public event Action<List`1<LevelItem>, Boolean> OnDoorChangeStateAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelDoor Door
	{
		 get { } //Length: 8
	}

	public LevelDropArea InsideDropArea
	{
		 get { } //Length: 8
	}

	public LevelSimpleTransparentContainer() { }

	[CompilerGenerated]
	public void add_OnDoorChangeStateAction(Action<List`1<LevelItem>, Boolean> value) { }

	private void Awake() { }

	public LevelDoor get_Door() { }

	public LevelDropArea get_InsideDropArea() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	protected override void OnDoorStateChange(bool isOpen) { }

	[CompilerGenerated]
	public void remove_OnDoorChangeStateAction(Action<List`1<LevelItem>, Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void Start() { }

}

