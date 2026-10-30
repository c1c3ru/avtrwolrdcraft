namespace PazuCore.EndSession;

public class EndSessionCard : ButtonBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public int localId; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal bool <Init>b__0(Game x) { }

	}

	private TextureComponent _textureComponent; //Field offset: 0x20
	private CardsModel _cardsModel; //Field offset: 0x28
	[SerializeField]
	private int _localId; //Field offset: 0x30
	[SerializeField]
	private int _scrollPosition; //Field offset: 0x34
	private bool _isDefaultCard; //Field offset: 0x38
	private bool _isNextGameCard; //Field offset: 0x39
	[CompilerGenerated]
	private String[] <NextGameAnalyticsContext>k__BackingField; //Field offset: 0x40

	public int LocalId
	{
		 get { } //Length: 8
	}

	public String[] NextGameAnalyticsContext
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public int ScrollPosition
	{
		 get { } //Length: 8
	}

	public EndSessionCard() { }

	[CompilerGenerated]
	private bool <OnClick>b__18_0(Game x) { }

	public int get_LocalId() { }

	[CompilerGenerated]
	public String[] get_NextGameAnalyticsContext() { }

	public int get_ScrollPosition() { }

	public void Init(CardsModel cardsModel, int localId, int scrollPosition) { }

	public void InitDefault() { }

	public void InitNextGame(string coverPhotoUrl) { }

	protected virtual void OnClick() { }

	[CompilerGenerated]
	public void set_NextGameAnalyticsContext(String[] value) { }

	private void Start() { }

}

