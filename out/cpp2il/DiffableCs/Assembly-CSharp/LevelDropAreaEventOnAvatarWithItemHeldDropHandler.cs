//Type is in global namespace

[HideParentPropertiesInInspector(new IL2CPP_TYPE_STRING[] {"_invokeDropEventOnPostInit", "_invokePickUpEventOnPostInit"})]
public class LevelDropAreaEventOnAvatarWithItemHeldDropHandler : LevelDropAreaEventOnItemDropHandler
{
	[SerializeField]
	private PDPrefabReference _heldItem; //Field offset: 0x80

	public LevelDropAreaEventOnAvatarWithItemHeldDropHandler() { }

	protected virtual void Awake() { }

	protected virtual bool IsConditionMet(LevelItem levelItem) { }

	private bool IsConditionMetForItemHeld(LevelItem handHeldItem) { }

	protected virtual void OnAvatarEndDrop(LevelAvatarRestAreaBase _, ILevelAvatar levelAvatar) { }

	protected virtual void OnAvatarPickUp(LevelAvatarRestAreaBase _, ILevelAvatar levelAvatar) { }

	protected virtual void OnItemEndDrop(LevelItem levelItem) { }

	protected virtual void OnItemPickUp(LevelItem levelItem) { }

}

