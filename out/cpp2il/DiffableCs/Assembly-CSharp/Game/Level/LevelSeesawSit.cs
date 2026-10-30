namespace Game.Level;

public class LevelSeesawSit : MonoBehaviour
{
	[SerializeField]
	private LevelSitArea _sitArea; //Field offset: 0x20
	[CompilerGenerated]
	private Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnBeginDropAction; //Field offset: 0x28
	[CompilerGenerated]
	private Action<LevelSeesawSit, LevelItem> OnEndDropAction; //Field offset: 0x30
	[CompilerGenerated]
	private Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnPickUpAction; //Field offset: 0x38
	[CompilerGenerated]
	private Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnInterrupteAction; //Field offset: 0x40
	private bool _dropCharacterInProgress; //Field offset: 0x48
	private bool _isInterrupted; //Field offset: 0x49

	public event Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnBeginDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelSeesawSit, LevelItem> OnEndDropAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnInterrupteAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> OnPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelSeesawSit() { }

	[CompilerGenerated]
	public void add_OnBeginDropAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

	[CompilerGenerated]
	public void add_OnEndDropAction(Action<LevelSeesawSit, LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnInterrupteAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

	[CompilerGenerated]
	public void add_OnPickUpAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

	private void Awake() { }

	public ILevelAvatar GetAvatarOnSit() { }

	public LevelCASeesawBaseSitAreaHandler GetRelevantLevelCAParentHandler(ILevelAvatar avatar = null) { }

	private void OnAvatarBeginDrop(LevelAvatarRestAreaBase base, ILevelAvatar avatar) { }

	private void OnAvatarEndDrop(LevelAvatarRestAreaBase base, ILevelAvatar avatar) { }

	private void OnAvatarPickUp(LevelAvatarRestAreaBase base, ILevelAvatar avatar) { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void remove_OnBeginDropAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

	[CompilerGenerated]
	public void remove_OnEndDropAction(Action<LevelSeesawSit, LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnInterrupteAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

	[CompilerGenerated]
	public void remove_OnPickUpAction(Action<LevelSeesawSit, LevelItem, LevelCASeesawBaseSitAreaHandler> value) { }

}

