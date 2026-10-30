namespace Game.Level;

public class LevelLifeguardBoueyItemHandler : MonoBehaviour
{
	[SerializeField]
	protected LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	protected LevelItemInCharacterBoneTransformOverride _levelItemInCharacterBoneTransformOverride; //Field offset: 0x28
	[SerializeField]
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x30
	[SerializeField]
	protected Sprite _floatSprite; //Field offset: 0x38
	[SerializeField]
	protected Sprite _heldSprite; //Field offset: 0x40
	[SerializeField]
	protected Transform _holdPointA; //Field offset: 0x48
	[SerializeField]
	protected Transform _holdPointB; //Field offset: 0x50
	[SerializeField]
	protected LevelDropArea _floatdDropArea; //Field offset: 0x58
	private bool _isInWater; //Field offset: 0x60
	private LevelCharacter _levelCharacter; //Field offset: 0x68
	private ItemOnAvatarType _itemOnAvatarType; //Field offset: 0x70
	private LevelWaterArea _waterArea; //Field offset: 0x78

	public LevelLifeguardBoueyItemHandler() { }

	private void Awake() { }

	private void CanPutInCharacterHand(LevelCharacter character, ref bool canPutInHand) { }

	private void CheckIfOnWater() { }

	private void OnBeforePlacedOnAvatar(ILevelAvatar levelAvatar, ItemOnAvatarType itemOnAvatarType) { }

	private void OnDestroy() { }

	private void OnEndLand(LevelDropArea levelDropArea) { }

	private void OnPostInit() { }

	private void OnRemovedFromAvatar(ILevelAvatar levelAvatar) { }

}

