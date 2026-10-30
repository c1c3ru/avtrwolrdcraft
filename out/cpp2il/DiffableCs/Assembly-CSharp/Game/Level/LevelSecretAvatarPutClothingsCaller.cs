namespace Game.Level;

public class LevelSecretAvatarPutClothingsCaller : MonoBehaviour
{
	[SerializeField]
	private LevelSecretAvatarPutClothingsListener _secretAvatarPutClothingsListener; //Field offset: 0x20
	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x28
	[SerializeField]
	private LevelSitArea _levelSitArea; //Field offset: 0x30

	public LevelSecretAvatarPutClothingsCaller() { }

	private void Awake() { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private void TryCheckAllAvatars() { }

}

