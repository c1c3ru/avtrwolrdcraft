namespace Game.Level;

public class LevelCharacterIDTogglerHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelCharacter _character; //Field offset: 0x20
	[SerializeField]
	private Int32[] _ids; //Field offset: 0x28
	[SerializeField]
	private int _interval; //Field offset: 0x30
	private int _idIndex; //Field offset: 0x34
	private bool _isTimePassed; //Field offset: 0x38
	[CompilerGenerated]
	private Action<Int32, Boolean> OnCharacterInitAction; //Field offset: 0x40

	public event Action<Int32, Boolean> OnCharacterInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelCharacterIDTogglerHandler() { }

	[CompilerGenerated]
	public void add_OnCharacterInitAction(Action<Int32, Boolean> value) { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	[CompilerGenerated]
	public void remove_OnCharacterInitAction(Action<Int32, Boolean> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

