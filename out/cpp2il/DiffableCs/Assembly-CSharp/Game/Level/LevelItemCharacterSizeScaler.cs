namespace Game.Level;

public class LevelItemCharacterSizeScaler : MonoBehaviour
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private Transform _scaledTransform; //Field offset: 0x28
	[SerializeField]
	private float _bigScale; //Field offset: 0x30
	[SerializeField]
	private float _mediumScale; //Field offset: 0x34
	[SerializeField]
	private float _smallScale; //Field offset: 0x38
	private Vector3 _baseLocalScale; //Field offset: 0x3C

	public LevelItemCharacterSizeScaler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnRemovedFromAvatar(ILevelAvatar avatar) { }

}

