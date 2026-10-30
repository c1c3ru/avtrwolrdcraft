namespace Game.Level;

public class LevelIceCreamContainerMachine : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public LevelEffectColorHandler effectColorHandler; //Field offset: 0x10
		public LevelIceCreamContainerMachine <>4__this; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass21_0() { }

		internal void <CreateIceCream>b__0() { }

		internal void <CreateIceCream>b__1() { }

	}

	[SerializeField]
	private LevelDropArea _levelDropArea; //Field offset: 0x20
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x28
	[SerializeField]
	private string _workingSoundName; //Field offset: 0x30
	[SerializeField]
	private LevelButton _button; //Field offset: 0x38
	[SerializeField]
	private GameObject _blocker; //Field offset: 0x40
	[SerializeField]
	[SpineAnimation(null, "_skeletonAnimation", True, False, False)]
	private String[] _animationsNames; //Field offset: 0x48
	private LevelCustomIceCreamContainerItemHandler _container; //Field offset: 0x50
	private LevelEatableItemHandler _currentFood; //Field offset: 0x58
	private string _topping; //Field offset: 0x60
	private string _toppingPrefabReference; //Field offset: 0x68
	private Animation _idleOffAnimation; //Field offset: 0x70
	private Animation _idleOnAnimation; //Field offset: 0x78
	private Animation _workingAnimation; //Field offset: 0x80
	private bool _isWorking; //Field offset: 0x88

	public LevelIceCreamContainerMachine() { }

	private void AddTopping(LevelItem topping) { }

	private void Awake() { }

	public void CreateIceCream() { }

	private void FindLastFoodAndTopping(GameObject levelItem) { }

	private bool IsTopping(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnItemDrop(LevelDropArea levelDropArea, LevelItem levelItem) { }

	private void OnItemPickUp(LevelDropArea levelDropArea, LevelItem levelItem) { }

	private void OnLevelPostInit() { }

}

