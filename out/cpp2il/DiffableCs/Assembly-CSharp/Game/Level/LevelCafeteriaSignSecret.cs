namespace Game.Level;

public class LevelCafeteriaSignSecret : LevelConsumerAreaBase, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x58
	[SerializeField]
	private GameObject _forkSprite; //Field offset: 0x60
	[SerializeField]
	private GameObject _spoonSprite; //Field offset: 0x68
	[SerializeField]
	private string _spoonLabel; //Field offset: 0x70
	[SerializeField]
	private string _forkLabel; //Field offset: 0x78
	private bool _isOpen; //Field offset: 0x80

	public LevelCafeteriaSignSecret() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

