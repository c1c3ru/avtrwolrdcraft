namespace PWC.LevelContextualAnimation;

public class LevelContextualAnimationItem : GameUIElement, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public LevelContextualAnimationItem <>4__this; //Field offset: 0x10
		public bool setInteractableOnComplete; //Field offset: 0x18
		public Action <>9__1; //Field offset: 0x20

		public <>c__DisplayClass16_0() { }

		internal void <AnimateThumbIfNeeded>b__0() { }

		internal void <AnimateThumbIfNeeded>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public bool value; //Field offset: 0x10
		public LevelContextualAnimationItem <>4__this; //Field offset: 0x18

		public <>c__DisplayClass20_0() { }

		internal void <Animate>b__0() { }

	}

	[CompilerGenerated]
	private static Action<LevelCAHandlerBase, LevelCAConfig> OnAnimationItemClickAction; //Field offset: 0x0
	[SerializeField]
	private Image _image; //Field offset: 0x28
	[SerializeField]
	private GameObject _indication; //Field offset: 0x30
	private bool _isInteractable; //Field offset: 0x38
	private LevelCAHandlerBase _handler; //Field offset: 0x40
	private LevelCAConfig _animationConfig; //Field offset: 0x48
	private int _siblingIndex; //Field offset: 0x50
	private int _siblingsNumber; //Field offset: 0x54
	private int _tweenID; //Field offset: 0x58
	private float _imageInitialLocalYPosition; //Field offset: 0x5C

	public static event Action<LevelCAHandlerBase, LevelCAConfig> OnAnimationItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelContextualAnimationItem() { }

	[CompilerGenerated]
	private void <OnCAAnimationInterrupt>b__15_0() { }

	[CompilerGenerated]
	public static void add_OnAnimationItemClickAction(Action<LevelCAHandlerBase, LevelCAConfig> value) { }

	public float Animate(bool value, bool isImmediate) { }

	private void AnimateThumbIfNeeded(bool setInteractableOnComplete) { }

	private void Awake() { }

	public float GetSpriteWidth() { }

	public void Init(LevelCAHandlerBase handler, LevelCAConfig animationConfig, Sprite sprite) { }

	private void OnAnimationItemClick(LevelCAHandlerBase handler, LevelCAConfig animationConfig) { }

	private void OnCAAnimationInterrupt(ICATarget target) { }

	private void OnDestroy() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnAnimationItemClickAction(Action<LevelCAHandlerBase, LevelCAConfig> value) { }

	private void UpdateIndication() { }

}

