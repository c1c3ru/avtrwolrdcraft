namespace PWC.Level;

public class LevelCraftableItemHandler : MonoBehaviour, ILevelHintBubbleSubTarget, ILevelHintBubbleTarget
{
	[SerializeField]
	private LevelCraftingType _type; //Field offset: 0x20
	private Sprite _sprite; //Field offset: 0x28

	public LevelCraftingType CraftingType
	{
		 get { } //Length: 8
	}

	public LevelCraftableItemHandler() { }

	private void Awake() { }

	public LevelCraftingType get_CraftingType() { }

	private void OnDestroy() { }

	private override int PWC.Level.HintBubble.ILevelHintBubbleSubTarget.GetSubMatchID() { }

	private override LevelHintBubbleType PWC.Level.HintBubble.ILevelHintBubbleTarget.GetHintBubbleType() { }

	private override int PWC.Level.HintBubble.ILevelHintBubbleTarget.GetMatchID() { }

	private override Sprite PWC.Level.HintBubble.ILevelHintBubbleTarget.GetSprite() { }

	private override bool PWC.Level.HintBubble.ILevelHintBubbleTarget.IsMatching(ILevelHintBubbleTarget other) { }

}

