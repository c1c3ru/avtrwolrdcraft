namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelNewSimpleTransparentContainer : MonoBehaviour, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelDoor _door; //Field offset: 0x20
	[SerializeField]
	private LevelConsumerAreaBase[] _insideConsumers; //Field offset: 0x28
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

	public LevelConsumerAreaBase[] InsideDropArea
	{
		 get { } //Length: 8
	}

	public LevelNewSimpleTransparentContainer() { }

	[CompilerGenerated]
	public void add_OnDoorChangeStateAction(Action<List`1<LevelItem>, Boolean> value) { }

	private void Awake() { }

	private void EnsureOnReadyPostLoad() { }

	public LevelDoor get_Door() { }

	public LevelConsumerAreaBase[] get_InsideDropArea() { }

	private void OnDestroy() { }

	protected override void OnDoorStateChange(bool isOpen) { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	public void remove_OnDoorChangeStateAction(Action<List`1<LevelItem>, Boolean> value) { }

}

