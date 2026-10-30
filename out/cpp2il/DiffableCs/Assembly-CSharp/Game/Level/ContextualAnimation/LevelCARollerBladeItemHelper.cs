namespace Game.Level.ContextualAnimation;

public class LevelCARollerBladeItemHelper
{
	private const string _transparentSkateboard = "TransparentSkateboard"; //Field offset: 0x0
	private LevelCAHandlerBase _CAHandler; //Field offset: 0x10
	private LevelRollerBladesItemHandler _rollerbladesHandler; //Field offset: 0x18
	private LevelSkateboardAnimationItemHandlerBase _animationHandler; //Field offset: 0x20
	private LevelItem _currentCharacter; //Field offset: 0x28
	private LevelItem _transparentSkateboardItem; //Field offset: 0x30
	private SkateboardType _skateboardType; //Field offset: 0x38

	public LevelSkateboardAnimationItemHandlerBase AnimationHandler
	{
		 get { } //Length: 8
	}

	public LevelRollerBladesItemHandler RollerbladesHandler
	{
		 get { } //Length: 8
	}

	public LevelCARollerBladeItemHelper() { }

	public void CreateTransparentSkateboard() { }

	private void EnsureCharacterOnTransparentSkateboard() { }

	private void EnsureNoSkateboardInHand() { }

	public void EnsureOnReadyPostLoad() { }

	public void FallFromRamp() { }

	public LevelSkateboardAnimationItemHandlerBase get_AnimationHandler() { }

	public LevelRollerBladesItemHandler get_RollerbladesHandler() { }

	public void Init(LevelCAHandlerBase handler, SkateboardType skateboardType) { }

	private void LevelItem_CanBeDroppedOnAction(LevelDropArea dropArea, ref bool canDrop) { }

	public void OnAddedToTarget(ICATarget target) { }

	private void OnApplicationPause(bool pause) { }

	private void OnBeforeDestroyLevelItem(LevelItem item) { }

	private void OnBeginDrag(DragDropItemBase arg1, PointerEventData arg2) { }

	public void OnDestroy() { }

	private void OnEndLand(LevelDropArea _) { }

	private void OnPreEndDrag(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnPreSaveProgress(Scene obj) { }

	public void OnRemovedFromTarget(ICATarget target) { }

	private void PutCharacterOnTransparentSkateboard() { }

	public void RemoveTransparentSkateboard() { }

	public void StartFallingFromRamp() { }

}

