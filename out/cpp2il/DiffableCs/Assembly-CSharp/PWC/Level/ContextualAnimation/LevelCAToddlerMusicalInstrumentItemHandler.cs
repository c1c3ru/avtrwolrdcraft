namespace PWC.Level.ContextualAnimation;

public class LevelCAToddlerMusicalInstrumentItemHandler : LevelCAItemHandlerWithData, IHaveAnimationSearch
{
	[SerializeField]
	private LevelCAWithSkinHelper _caWithSkinHelper; //Field offset: 0x90
	[SerializeField]
	private List<Renderer> _renderersToHide; //Field offset: 0x98
	[SerializeField]
	private string _skinName; //Field offset: 0xA0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xA8
	[SerializeField]
	private String[] _soundNames; //Field offset: 0xB0

	public LevelCAToddlerMusicalInstrumentItemHandler() { }

	public override LevelCAConfig GetCAConfigByAnimationName(string animationName) { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void SoundPlayerSetActive(bool value, int index, string name) { }

}

