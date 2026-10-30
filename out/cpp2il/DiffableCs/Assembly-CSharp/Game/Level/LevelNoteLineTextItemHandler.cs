namespace Game.Level;

public class LevelNoteLineTextItemHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private TextMesh _textMesh; //Field offset: 0x20
	private int _index; //Field offset: 0x28

	public LevelNoteLineTextItemHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void UpdateNumber(int index) { }

}

