namespace Game.Level;

public class LevelBabyBlanketItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private Sprite _normalSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _dropAreaSprite; //Field offset: 0x30
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x38
	private bool _isNormal; //Field offset: 0x40

	public LevelBabyBlanketItemHandler() { }

	public void ChangeToDropAreaSprite() { }

	public void ChangeToNormalSprite() { }

	private void DropItems() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void ToggleSprite() { }

}

