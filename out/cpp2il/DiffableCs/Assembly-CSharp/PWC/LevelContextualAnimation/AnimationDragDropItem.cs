namespace PWC.LevelContextualAnimation;

public class AnimationDragDropItem : DragDropItemBase
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x110
	private LevelContextualAnimationItem _animationItem; //Field offset: 0x118
	private string _animationName; //Field offset: 0x120

	public AnimationDragDropItem() { }

	[CompilerGenerated]
	internal static void <OnEndDragInternal>g__PlayAnimation|4_0() { }

	public void Init(LevelContextualAnimationItem animationItem, Sprite sprite, string animationName) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

}

