namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAToddlerItemCraftingHandlerBase : LevelCAItemCraftingHandlerBase
{

	protected LevelCAToddlerItemCraftingHandlerBase() { }

	protected void EnsureSitting(ICATarget target, bool returnToIdle = true) { }

	protected void EnsureStanding(ICATarget target, bool returnToIdle = true) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEvent(ICATarget target, TrackEntry trackEntry, Event spineEvent) { }

	public virtual void OnItemAddedToTarget(ICATarget target, LevelItem levelItem) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected bool TryCraftCurrentItem(LevelToddler toddler) { }

	protected virtual bool TryGetItemToCraft(ICATarget target, out LevelItem levelItem, out List<ValueTuple`2<PDPrefab, Sprite>>& outcomes, out Sprite hudThumb) { }

}

