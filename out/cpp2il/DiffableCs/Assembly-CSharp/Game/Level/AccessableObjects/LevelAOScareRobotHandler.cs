namespace Game.Level.AccessableObjects;

public class LevelAOScareRobotHandler : LevelAOScareItemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelDynamicSignRobot _robot; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private bool _isChangingSkin; //Field offset: 0x30
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private string _scaredAnimation; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onScareAction; //Field offset: 0x40
	private Skin _skin; //Field offset: 0x48
	private Skin _specialSkin; //Field offset: 0x50
	private Skin _defaultSkin; //Field offset: 0x58
	private bool _isSpecialSkin; //Field offset: 0x60

	public LevelAOScareRobotHandler() { }

	protected virtual void Awake() { }

	private void ChangeSkin(Skin skin, bool isPoof) { }

	private void FindAllSkins() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnComplete(TrackEntry track) { }

	private void RefreshSkeletonAnimation() { }

	public void ReturnToDefaultSkin() { }

	public virtual void Scare() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

