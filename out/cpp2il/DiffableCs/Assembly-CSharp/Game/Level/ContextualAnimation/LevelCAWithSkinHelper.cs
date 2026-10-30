namespace Game.Level.ContextualAnimation;

public class LevelCAWithSkinHelper : MonoBehaviour
{
	private Action<Material> _sutInitSingleColortMaterial; //Field offset: 0x20
	private readonly List<Skin> _addedSkins; //Field offset: 0x28
	private ILevelAvatar _currentHolder; //Field offset: 0x30
	private LevelItem _levelItem; //Field offset: 0x38
	private List<Renderer> _renderers; //Field offset: 0x40
	private bool _isInteractable; //Field offset: 0x48
	private HashSet<String> _excludedSkins; //Field offset: 0x50
	private string _skinName; //Field offset: 0x58
	private bool _isSkinOn; //Field offset: 0x60
	private BoneFollower _currentBoneFollower; //Field offset: 0x68

	public LevelCAWithSkinHelper() { }

	[CompilerGenerated]
	private void <UpdateSpineAsset>b__13_0(Material material) { }

	public void AddSkinAndHideItem(Skin skin, string boneName, LevelItem levelItem) { }

	private void HideItem(LevelItem levelItem) { }

	public void Init(LevelItem levelItem, List<Renderer> renderersToHide, bool isItemInetractable, string skinName) { }

	public void OnAddedToTarget(ICATarget target) { }

	public void OnRemovedFromTarget(ICATarget target) { }

	private void RefreshSkeletonAnimation(ILevelAvatar avatar) { }

	private void RemoveSkin(Skin mainSkin, Skin skinToRemove) { }

	public void RemoveSkinAndShowItem(Skin skin, LevelItem levelItem) { }

	public void SetExcludedSkins(HashSet<String> excludedSkins) { }

	public void SetInteractable(ICATarget target, LevelCAConfig config) { }

	private void SetMaterialStrightAlpha(Material material) { }

	private void ShowItem(LevelItem levelItem) { }

	public void UpdateSpineAsset(ILevelAvatar avatar, LevelItem levelItem) { }

}

