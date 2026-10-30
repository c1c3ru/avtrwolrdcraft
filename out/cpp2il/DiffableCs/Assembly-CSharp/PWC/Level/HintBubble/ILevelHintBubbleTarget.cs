namespace PWC.Level.HintBubble;

public interface ILevelHintBubbleTarget
{

	public LevelHintBubbleType GetHintBubbleType() { }

	public int GetMatchID() { }

	public Sprite GetSprite() { }

	public bool IsMatching(ILevelHintBubbleTarget other) { }

}

