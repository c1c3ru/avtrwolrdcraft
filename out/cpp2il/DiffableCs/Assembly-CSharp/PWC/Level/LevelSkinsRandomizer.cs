namespace PWC.Level;

public class LevelSkinsRandomizer : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass9_0
	{
		public CharacterCategoryType categoryType; //Field offset: 0x0

	}

	[SerializeField]
	private SkeletonDataAsset _skeletonDataAsset; //Field offset: 0x20
	[SerializeField]
	private SUTSkinsDataMap _sutSkinsDataMap; //Field offset: 0x28
	[SerializeField]
	private SerializableDictionaryBase<CharacterCategoryType, RandomSkinsList> _skinsByCategoryType; //Field offset: 0x30
	[SerializeField]
	private SerializableDictionaryBase<CharacterCategoryType, MakeupBoothColorsList> _colorsByCategoryType; //Field offset: 0x38
	[SerializeField]
	private SerializableDictionaryBase<CharacterCategoryType, SpecificColorsIndexBySkinNameList> _specificColorsIndexesByType; //Field offset: 0x40
	private AvatarSpineSkinsManagerBase _skinsManager; //Field offset: 0x48
	private LevelAvatarClothingHandler _clothingHandler; //Field offset: 0x50
	private CharacterCategoryType _forcedCategory; //Field offset: 0x58
	private string _forcedSkinName; //Field offset: 0x60

	public LevelSkinsRandomizer() { }

	[CompilerGenerated]
	private void <RandomizeSkins>g__AddRandomSkin|9_0(CharacterCategoryType categoryTypeToAdd, RandomSkinsList skinsList, ref <>c__DisplayClass9_0 unnamed_param_2) { }

	[CompilerGenerated]
	private void <RandomizeSkins>g__ColorRandomSkin|9_1(CharacterCategoryType categoryTypeToColor, string skinName) { }

	[CompilerGenerated]
	private MakeupBoothColorModel <RandomizeSkins>g__GetRandomColor|9_2(CharacterCategoryType categoryType, string skinName) { }

	public void ForceItemForNextCharacter(string skinName) { }

	public void RandomizeSkins(ILevelAvatar avatar) { }

}

