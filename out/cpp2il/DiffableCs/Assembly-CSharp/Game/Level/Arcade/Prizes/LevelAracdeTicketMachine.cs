namespace Game.Level.Arcade.Prizes;

public class LevelAracdeTicketMachine : LevelConsumerAreaBase, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private static Action<Int32> OnTicketsChanged; //Field offset: 0x0
	[SerializeField]
	private PDPrefab _spawn; //Field offset: 0x58
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x60
	[SerializeField]
	private TextMesh _numberOfTicketsText; //Field offset: 0x68
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x70
	[SerializeField]
	private string _soundName; //Field offset: 0x78
	[SerializeField]
	private UnityEvent _onMaxTicketsReachedEvent; //Field offset: 0x80
	private int _numberOfTickets; //Field offset: 0x88

	public static event Action<Int32> OnTicketsChanged
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelAracdeTicketMachine() { }

	[CompilerGenerated]
	public static void add_OnTicketsChanged(Action<Int32> value) { }

	protected virtual void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitGift() { }

	protected virtual void OnDestroy() { }

	private void OnTicketAdded() { }

	private void ReduceTickets(int tickets) { }

	[CompilerGenerated]
	public static void remove_OnTicketsChanged(Action<Int32> value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

