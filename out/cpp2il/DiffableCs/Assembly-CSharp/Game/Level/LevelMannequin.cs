namespace Game.Level;

public class LevelMannequin : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelHasClothingHandler, ILevelSpawnDuringGameplay, ILevelMakerUIMenuItem
{
	[SerializeField]
	private LevelMannequinSkinsManager _skinsManager; //Field offset: 0x20
	private LevelCharacterClothingHandler _clothingHandler; //Field offset: 0x28
	private bool _hasPersistentData; //Field offset: 0x30

	public LevelMannequinSkinsManager SkinsManager
	{
		 get { } //Length: 8
	}

	public LevelMannequin() { }

	private void Awake() { }

	public LevelMannequinSkinsManager get_SkinsManager() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnClickMakerItemDestroyButton(ILevelMakerDeletableByUIItem _) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	private override LevelAvatarClothingHandler PWC.Level.ILevelHasClothingHandler.GetLevelAvatarClothingHandler() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	public void ResetMannaquin() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

