namespace BWYW;

public class BWYWMenuCharacter : BWYWSlotBase
{
	private const int TIME_TO_GET_ATTENSION = 7; //Field offset: 0x0
	[SerializeField]
	private AvatarSpineSkinsManagerBase _skinsManager; //Field offset: 0x50
	[SerializeField]
	private AvatarMakerLobbyFilledSlotAnimationsHandler _animationsHandler; //Field offset: 0x58
	[SerializeField]
	private Image _titleImage; //Field offset: 0x60
	private SkillType _skillType; //Field offset: 0x68
	private AnimationsSetParams _wavingAnimation; //Field offset: 0x70
	private AnimationsSetParams _lookDownAnimation; //Field offset: 0x78
	private AnimationsSetParams _lookAndJumpAnimation; //Field offset: 0x80
	private AnimationsSetParams _applauseAnimation; //Field offset: 0x88
	private AnimationsSetParams _attentionAnimation; //Field offset: 0x90
	private List<AnimationsSetParams> _skillAndAttensionAnimations; //Field offset: 0x98
	private Coroutine _waitCoroutine; //Field offset: 0xA0

	public SkillType skillType
	{
		 get { } //Length: 8
	}

	public BWYWMenuCharacter() { }

	[CompilerGenerated]
	private void <OnPlayerGetAttentions>b__18_0() { }

	public SkillType get_skillType() { }

	public void Init(SkillType skillType, int characterID, Sprite titleSprite) { }

	public void InitAnimations(SkillType skillType) { }

	internal void OnGiftClaim() { }

	private void OnPlayerGetAttentions() { }

	internal void OnTaskClaim() { }

	private void SetIdle() { }

}

