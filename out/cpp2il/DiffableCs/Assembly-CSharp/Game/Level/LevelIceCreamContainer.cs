namespace Game.Level;

public class LevelIceCreamContainer : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private Sprite _iceCreamSprite; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _icsCreamPrefab; //Field offset: 0x28
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38
	[SerializeField]
	private Color _effectColor; //Field offset: 0x40
	private CShape _cShape; //Field offset: 0x50
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x58

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelIceCreamContainer() { }

	private void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private LevelSpawn GetPrefabToSpawn() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	public override void OnDrag(PointerEventData eventData) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private bool TrySpawnForBeginDragCall(out LevelItem iceCreamLevelItem) { }

}

