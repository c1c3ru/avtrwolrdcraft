namespace PWC.Level.BasketballSystem;

public class LevelBSNotBouncingBasketballItemHandler : LevelBSBasketballItemHandler
{

	public LevelBSNotBouncingBasketballItemHandler() { }

	protected virtual void MissInternal(Vector2 vector, LevelBSHoop hoop) { }

	protected virtual void ScoreInternal(LevelBSHoop hoop) { }

}

