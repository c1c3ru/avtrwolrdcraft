namespace Game.Level;

public abstract class LevelStickCookable : LevelItem
{
	[SerializeField]
	private LevelEatableItemHandler _eatableItemHandler; //Field offset: 0x348
	[SerializeField]
	protected Sprite _burnedSprite; //Field offset: 0x350
	protected SpriteRenderer _spriteRenderer; //Field offset: 0x358
	protected bool _isBurned; //Field offset: 0x360
	private LevelCookingStickArea _cookingStickArea; //Field offset: 0x368

	public LevelEatableItemHandler EatableItemHandler
	{
		 get { } //Length: 8
	}

	protected LevelStickCookable() { }

	[CompilerGenerated]
	private void <Burn>b__9_0() { }

	protected virtual void Awake() { }

	protected override void Burn() { }

	public abstract void CookSetActive(bool value) { }

	public LevelEatableItemHandler get_EatableItemHandler() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	protected virtual void TweenToProperPositionOnDropArea(Vector2 position, LevelDropArea dropArea, bool useJumpTween = true, Nullable<Vector2> overrideLocalPositionDestination = null) { }

}

