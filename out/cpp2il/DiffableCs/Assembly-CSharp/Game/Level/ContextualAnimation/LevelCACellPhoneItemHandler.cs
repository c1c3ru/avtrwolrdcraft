namespace Game.Level.ContextualAnimation;

public class LevelCACellPhoneItemHandler : LevelCAItemHandlerBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public LevelCharacter character; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal void <ReactToSelfie>b__0() { }

	}

	private const string TEXTING_ANIMATION_NAME = "Texting_Loop"; //Field offset: 0x0
	private const string SELFIE_REACT_ANIMATION_NAME = "CA/Phone/React_To_Selfie"; //Field offset: 0x0
	private const string TALKING_WINKS_NAME = "Talking_Winks"; //Field offset: 0x0
	private const string TALKING_LAUGHING_NAME = "Talking_Laughing"; //Field offset: 0x0
	private const string TALKING_ANGRY_HANG_UP_NAME = "Talking_Angry_Hang_Up"; //Field offset: 0x0
	private const string GAMING_ANIMATION_NAME = "Gaming_Loop"; //Field offset: 0x0
	private const string SHARED_SELFIE_ANIMATION_NAME = "Shared_Selfie"; //Field offset: 0x0
	private const string CALLING_ANIMATION_NAME = "Calling"; //Field offset: 0x0
	private const string YELLING_ANIMATION_NAME = "Yells_Hangs_Up"; //Field offset: 0x0
	private const string PANIC_ANIMATION_NAME = "Speak_Panic"; //Field offset: 0x0
	private const string SELFIE_ANIMATION_NAME = "Take_Selfie"; //Field offset: 0x0
	private const string SCROLLING_ANIMATION_NAME = "Scrolling_Loop"; //Field offset: 0x0
	[SerializeField]
	private Sprite _phoneBackSprite; //Field offset: 0x88
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x90
	[SerializeField]
	private LevelCAItemHandlerData _overrideCAData; //Field offset: 0x98
	private Sprite _currentSprite; //Field offset: 0xA0
	private bool _isLayingInBed; //Field offset: 0xA8
	private LevelCharacter _levelCharacter; //Field offset: 0xB0
	private LevelSleepArea _sleepArea; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _configs; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _layingInBedConfigs; //Field offset: 0xC8

	public LevelCACellPhoneItemHandler() { }

	protected virtual void Awake() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual string GetLockedAnimationName() { }

	public virtual int GetPriority() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsSingleCAInMenu() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationPostBegin(ICATarget target, LevelCAConfig config, TrackEntry trackEntry) { }

	private void OnBeginDrag(DragDropItemBase dragDropItemBase, PointerEventData pointerEventData) { }

	private void OnBeginDropOnRestArea(LevelAvatarRestAreaBase levelAvatarRestArea) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void OnUpdateCAList(ICATarget target, bool isAdded, bool isSilent) { }

	private void ReactToSelfie(LevelCharacter currentCharacter) { }

	public void SetSpriteToBack() { }

	public void SetSpriteToFront() { }

}

