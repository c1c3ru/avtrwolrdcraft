namespace Game.Level;

public class LevelOrderTable : MonoBehaviour
{
	[CompilerGenerated]
	private static Action OnFlagRaise; //Field offset: 0x0
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private float _hightLimit; //Field offset: 0x28
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x30
	[SerializeField]
	private LevelToggleableSprite _flag; //Field offset: 0x38
	[SerializeField]
	private string _dropSoundName; //Field offset: 0x40
	private bool _canCreateItem; //Field offset: 0x48
	private bool _isFull; //Field offset: 0x49

	public static event Action OnFlagRaise
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public LevelOrderTable() { }

	[CompilerGenerated]
	public static void add_OnFlagRaise(Action value) { }

	private void Awake() { }

	public bool CreateItem(PDPrefabReference pdReference) { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	private void OnDestroy() { }

	private void OnDropAreaUpdate(LevelDropArea lastItemDropArea, LevelItem item) { }

	private void OnLevelPostInit() { }

	[CompilerGenerated]
	public static void remove_OnFlagRaise(Action value) { }

	private void UpdateFlag() { }

	private void UpdateTableIsFull() { }

}

