namespace Game.Level;

public class LevelChangeSpriteOnDropAreaItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x30
	[SerializeField]
	private LevelLabelHandler _labelHandler; //Field offset: 0x38
	[SerializeField]
	private LevelMultiLabelHandler _multiLabelHandler; //Field offset: 0x40
	private bool _isOn; //Field offset: 0x48

	public LevelChangeSpriteOnDropAreaItemHandler() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void SetOffDropAreaSprite(DragDropItemBase dropItemBase, PointerEventData eventData) { }

	private void SetOnDropAreaSprite(LevelDropArea dropArea) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

