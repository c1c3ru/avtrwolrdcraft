namespace Game.Level.Arcade.RhythmGame;

public class LevelLifesRhythmGame : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Boolean> OnGameLost; //Field offset: 0x0
	[SerializeField]
	private SpriteRenderer[] _Lifes; //Field offset: 0x20
	[SerializeField]
	private Sprite _fullLifeSprite; //Field offset: 0x28
	[SerializeField]
	private Sprite _emptyLifeSprite; //Field offset: 0x30
	private int _lifesIndex; //Field offset: 0x38

	public static event Action<Boolean> OnGameLost
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelLifesRhythmGame() { }

	[CompilerGenerated]
	public static void add_OnGameLost(Action<Boolean> value) { }

	private void Awake() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public static void remove_OnGameLost(Action<Boolean> value) { }

	public void RemoveLife() { }

	private void RestoreLifes(bool _) { }

}

