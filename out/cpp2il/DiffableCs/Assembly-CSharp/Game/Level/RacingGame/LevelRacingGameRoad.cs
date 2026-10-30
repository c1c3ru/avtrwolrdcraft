namespace Game.Level.RacingGame;

public class LevelRacingGameRoad : MonoBehaviour
{
	[SerializeField]
	private Texture2D[] _roads; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _groundSprites; //Field offset: 0x28
	[SerializeField]
	private SpriteRenderer _groundRenderer; //Field offset: 0x30
	private Material _material; //Field offset: 0x38
	private Flat3DPlane _flat3DPlance; //Field offset: 0x40
	private int _currentRoadIndex; //Field offset: 0x48

	public LevelRacingGameRoad() { }

	public int ChangeRoadTexture(bool isNewGame) { }

	public void Init() { }

	public void UpdateGame(float deltaTime, float speed) { }

}

