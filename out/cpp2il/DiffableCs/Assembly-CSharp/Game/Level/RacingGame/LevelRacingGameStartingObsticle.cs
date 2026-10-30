namespace Game.Level.RacingGame;

public class LevelRacingGameStartingObsticle : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelRacingGameStartingObsticle <>4__this; //Field offset: 0x10
		public Vector3 scale; //Field offset: 0x18
		public Vector2 initialPosition; //Field offset: 0x24

		public <>c__DisplayClass4_0() { }

		internal void <Init>b__0(float value) { }

		internal void <Init>b__1() { }

	}

	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Transform _endPoint; //Field offset: 0x28
	[SerializeField]
	private float _endScale; //Field offset: 0x30
	private LevelRacingGameManager _manager; //Field offset: 0x38

	public LevelRacingGameStartingObsticle() { }

	public void Init(LevelRacingGameManager manager, float speed) { }

	public void ToggleVisable(bool value) { }

}

