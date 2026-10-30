namespace Game.Level;

public class LevelRoadBlockAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private Vector2 _blockedArea; //Field offset: 0x20
	[SerializeField]
	private bool _isBlocked; //Field offset: 0x28

	public Vector2 BlockedArea
	{
		 get { } //Length: 8
	}

	public LevelRoadBlockAreaHandler() { }

	public bool CheckIfToggleBlocked() { }

	public Vector2 get_BlockedArea() { }

	public bool GetIsBlocked() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public void SetBlocked(bool value) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void ToggleBlocked() { }

}

