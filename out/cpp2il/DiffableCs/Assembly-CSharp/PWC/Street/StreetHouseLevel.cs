namespace PWC.Street;

public class StreetHouseLevel : StationaryInteractableItem, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x40
	[SerializeField]
	private int _id; //Field offset: 0x48
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x4C
	private StreetHouse _house; //Field offset: 0x50

	public int ID
	{
		 get { } //Length: 8
	}

	public LevelType LevelType
	{
		 get { } //Length: 8
	}

	public StreetHouseLevel() { }

	public int get_ID() { }

	public LevelType get_LevelType() { }

	public void Init(StreetHouse house) { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

