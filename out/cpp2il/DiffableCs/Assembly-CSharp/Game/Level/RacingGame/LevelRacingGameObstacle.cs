namespace Game.Level.RacingGame;

public class LevelRacingGameObstacle : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite[] _grassObstacles; //Field offset: 0x28
	[SerializeField]
	private Sprite[] _snowObstacles; //Field offset: 0x30
	[SerializeField]
	private Sprite[] _desertObstacles; //Field offset: 0x38
	[SerializeField]
	private Sprite[] _carSprites; //Field offset: 0x40
	[SerializeField]
	private Sprite[] _gifts; //Field offset: 0x48
	private LevelRacingGameManager _manager; //Field offset: 0x50
	[CompilerGenerated]
	private int <LaneIndex>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private bool <IsCar>k__BackingField; //Field offset: 0x5C
	[CompilerGenerated]
	private bool <IsGift>k__BackingField; //Field offset: 0x5D
	[CompilerGenerated]
	private int <GiftIndex>k__BackingField; //Field offset: 0x60

	public private int GiftIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private bool IsCar
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private bool IsGift
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private int LaneIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LevelRacingGameObstacle() { }

	[CompilerGenerated]
	private void <Init>b__23_0(float value) { }

	[CompilerGenerated]
	private void <Init>b__23_1() { }

	[CompilerGenerated]
	public int get_GiftIndex() { }

	[CompilerGenerated]
	public bool get_IsCar() { }

	[CompilerGenerated]
	public bool get_IsGift() { }

	[CompilerGenerated]
	public int get_LaneIndex() { }

	public void Init(LevelRacingGameManager manager, int laneIndex, Vector2[][] _lanes, bool isCar, float speed, int seasonIndex, bool isGift = false) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	private void set_GiftIndex(int value) { }

	[CompilerGenerated]
	private void set_IsCar(bool value) { }

	[CompilerGenerated]
	private void set_IsGift(bool value) { }

	[CompilerGenerated]
	private void set_LaneIndex(int value) { }

}

