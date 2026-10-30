namespace PWC.Level;

public class LevelAnimationDropAreaHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public string sceneGuid; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <OnItemPickUp>b__0(LevelItemData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public PDSceneObject pdSceneObject; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <OnLevelItemClick>b__0(LevelItemData x) { }

	}

	[SerializeField]
	private SkeletonDataAsset _skeletonDataAsset; //Field offset: 0x20
	[SerializeField]
	[SpineAnimation(null, "_skeletonDataAsset", True, False, False)]
	private String[] _animationsNames; //Field offset: 0x28
	[SerializeField]
	private int _trackIndex; //Field offset: 0x30
	private LevelDropArea _dropArea; //Field offset: 0x38
	private int _nextAnimationIndex; //Field offset: 0x40
	private LevelAnimationDropAreaPD _data; //Field offset: 0x48

	public LevelAnimationDropAreaHandler() { }

	private void Awake() { }

	private string GetNextAnimationNameToPlay() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void OnLevelItemClick(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnLevelPostInit() { }

	private bool OverrideCharacterEndDropAnimation(ILevelAvatar avatar) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private bool TryAddItemWithAnimation(LevelItem levelItem) { }

}

