namespace Game.Level.Arcade.Prizes;

public class LevelArcadePrizeSpawner : LevelSimpleSpawner
{
	[CompilerGenerated]
	private static Action<Int32> OnItemSpawned; //Field offset: 0x0
	[SerializeField]
	private int _numberOfTicketsWorth; //Field offset: 0x98
	[SerializeField]
	private LevelLight _light; //Field offset: 0xA0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA8
	private bool _CanBeSpawned; //Field offset: 0xB0

	public static event Action<Int32> OnItemSpawned
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelArcadePrizeSpawner() { }

	[CompilerGenerated]
	public static void add_OnItemSpawned(Action<Int32> value) { }

	protected virtual void Awake() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	private void OnDestroy() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnItemSpawned(Action<Int32> value) { }

	private void TryEnableSpawn(int numberOfTickets) { }

}

