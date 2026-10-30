namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelAnimationDropArea : LevelDropArea, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public string sceneGuid; //Field offset: 0x10

		public <>c__DisplayClass5_0() { }

		internal bool <OnItemPickUp>b__0(LevelItemData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public PDSceneObject pdSceneObject; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <OnCharacterClick>b__0(LevelItemData x) { }

	}

	[SerializeField]
	private SkeletonDataAsset _skeletonDataAsset; //Field offset: 0xD8
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private String[] _animationsNames; //Field offset: 0xE0
	private int _nextAnimationIndex; //Field offset: 0xE8
	private LevelAnimationDropAreaPD _data; //Field offset: 0xF0

	public LevelAnimationDropArea() { }

	public virtual bool CanConsumeCharacters() { }

	private string GetNextAnimationNameToPlay() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnCharacterClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	public virtual void OnItemPickUp(LevelItem levelItem) { }

	protected virtual void OnLevelPostInit() { }

	public virtual bool OverrideAvatarEndDropAnimation(ILevelAvatar avatar) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

