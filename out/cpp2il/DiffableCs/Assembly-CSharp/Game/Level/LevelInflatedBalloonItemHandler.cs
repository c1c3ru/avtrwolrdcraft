namespace Game.Level;

public class LevelInflatedBalloonItemHandler : MonoBehaviour
{
	private const float RANGE_TO_HOVER = 0,5; //Field offset: 0x0
	private const float FLOATING_SPEED = 0,5; //Field offset: 0x0
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private float _maxHeight; //Field offset: 0x28
	private bool _isFloating; //Field offset: 0x2C
	private bool _isInit; //Field offset: 0x2D
	private int _floatingLeanTweenId; //Field offset: 0x30
	private int _hoverTweenId; //Field offset: 0x34

	public LevelInflatedBalloonItemHandler() { }

	[CompilerGenerated]
	private void <StartFloat>b__15_0() { }

	private void Awake() { }

	public void EndFloat() { }

	public void Init(bool isVanishEffect) { }

	private void OnBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnDestroy() { }

	private void OnEndDrag(DragDropItemBase arg1, PointerEventData arg2) { }

	private void OnLevelPostInit() { }

	public bool OverrideBasicDropBehavior(LevelItem item) { }

	private void StartFloat() { }

}

