namespace Game.Level.ArcadeBasketball;

public class LevelArcadeBasketballItemHandler : MonoBehaviour
{
	private LevelBSBasketballItemHandler _BSBasketballHandler; //Field offset: 0x20
	private float _scoreChance; //Field offset: 0x28

	public LevelArcadeBasketballItemHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private bool OverrideAnimationShootScoreChanceAction(LevelBSBasketballItemHandler handelr, out float scoreChance) { }

	public void SetScore(float scoreChance) { }

}

