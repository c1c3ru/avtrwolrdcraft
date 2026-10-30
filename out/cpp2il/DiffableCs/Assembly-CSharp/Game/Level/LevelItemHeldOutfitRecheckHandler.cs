namespace Game.Level;

public class LevelItemHeldOutfitRecheckHandler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20

	public LevelItemHeldOutfitRecheckHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

}

