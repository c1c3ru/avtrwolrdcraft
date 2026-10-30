namespace Game.Level;

public class LevelClothingMannequinSecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private string _skinName; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onSkinMatch; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onSkinUnmatch; //Field offset: 0x30
	private bool _isSolved; //Field offset: 0x38

	public LevelClothingMannequinSecret() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void OnPutClothingOnMannequin(string skinName) { }

	public void OnRemoveClothingFromMannequin(string skinName) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

