namespace PWC.LevelPhone;

public class ContactsThumb : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass30_0
	{
		public Action onCompleteAction; //Field offset: 0x10
		public ContactsThumb <>4__this; //Field offset: 0x18
		public bool value; //Field offset: 0x20

		public <>c__DisplayClass30_0() { }

		internal void <AnimateScale>b__0() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass35_0
	{
		public Color color; //Field offset: 0x10
		public ContactsThumb <>4__this; //Field offset: 0x20

		public <>c__DisplayClass35_0() { }

		internal void <OverlaySetActive>b__0(float alphaValue) { }

	}

	public const float ANIMATION_TIME = 0,15; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Boolean> OnContactsThumbEndAnimationAction; //Field offset: 0x0
	[CompilerGenerated]
	private int <ID>k__BackingField; //Field offset: 0x20
	[SerializeField]
	private Material _phoneMaskableMaterial; //Field offset: 0x28
	[SerializeField]
	private Material _phoneSpriteMaskableMaterial; //Field offset: 0x30
	[SerializeField]
	private Image _shadow; //Field offset: 0x38
	[SerializeField]
	private Image _fill; //Field offset: 0x40
	[SerializeField]
	private SpriteRenderer _overlay; //Field offset: 0x48
	[SerializeField]
	private SpriteRenderer _stroke; //Field offset: 0x50
	[SerializeField]
	private Transform _spineParent; //Field offset: 0x58
	[SerializeField]
	private ContactsThumbFavoriteButton _favoriteButton; //Field offset: 0x60
	private float _animationDelay; //Field offset: 0x68
	private Vector3 _minScale; //Field offset: 0x6C
	private bool _didInitOnce; //Field offset: 0x78
	private readonly Color _makerFillColor; //Field offset: 0x7C
	private readonly Color _premadeFillColor; //Field offset: 0x8C
	private AvatarSpineSkinsManagerBase _skinsManager; //Field offset: 0xA0
	private SpineType _currentSpineType; //Field offset: 0xA8
	private AvatarSizeType _currentAvatarSize; //Field offset: 0xAC
	private string _currentBreed; //Field offset: 0xB0
	private ContactsPage _myPage; //Field offset: 0xB8

	public static event Action<Boolean> OnContactsThumbEndAnimationAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public private int ID
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public ContactsThumb() { }

	[CompilerGenerated]
	private void <Init>b__28_0() { }

	[CompilerGenerated]
	private bool <Init>b__28_1(ILevelAvatar levelCharacter) { }

	[CompilerGenerated]
	private void <ResetContact>b__32_0() { }

	[CompilerGenerated]
	private bool <SyncOverlay>b__34_0(ILevelAvatar levelCharacter) { }

	[CompilerGenerated]
	public static void add_OnContactsThumbEndAnimationAction(Action<Boolean> value) { }

	private void AnimateScale(bool value, Action onCompleteAction = null) { }

	private void Awake() { }

	private void CallOnEndAnimationEventIfNeeded(bool value) { }

	[CompilerGenerated]
	public int get_ID() { }

	public void Init(int id, bool isAddButtonActive, int stencilRefBuffer, ContactsContent content, ContactsPage page) { }

	private void InitElementsIfNeeded(int stencilRefBuffer) { }

	private void OnCharacterConsumed(int id) { }

	private void OnContactsThumbEndAnimation(bool value) { }

	private void OnDestroy() { }

	public void OverlaySetActive(bool value, bool isImmediate = false) { }

	[CompilerGenerated]
	public static void remove_OnContactsThumbEndAnimationAction(Action<Boolean> value) { }

	public void ResetContact(bool isAnimate) { }

	[CompilerGenerated]
	private void set_ID(int value) { }

	private void SyncOverlay() { }

}

