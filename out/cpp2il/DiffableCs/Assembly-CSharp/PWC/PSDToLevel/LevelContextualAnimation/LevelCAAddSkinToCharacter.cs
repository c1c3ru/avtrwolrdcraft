namespace PWC.PSDToLevel.LevelContextualAnimation;

public class LevelCAAddSkinToCharacter : MonoBehaviour
{
	[SerializeField]
	private CharacterCategoryType _categoryType; //Field offset: 0x20
	[SerializeField]
	private string _skinName; //Field offset: 0x28

	public LevelCAAddSkinToCharacter() { }

	public void AddSkin(LevelCharacter character) { }

	public void OnAnimationEndHandler(LevelCAHandlerBase _, ICATarget target, LevelCAConfig __) { }

}

