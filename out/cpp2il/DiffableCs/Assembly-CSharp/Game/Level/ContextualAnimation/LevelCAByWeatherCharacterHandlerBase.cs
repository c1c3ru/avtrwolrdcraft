namespace Game.Level.ContextualAnimation;

public class LevelCAByWeatherCharacterHandlerBase : LevelCAHandlerBase
{
	private bool _isActiveIndoor; //Field offset: 0x80
	private bool _isActiveOutdoor; //Field offset: 0x81

	public bool IsActiveIndoor
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool IsActiveOutdoor
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelCAByWeatherCharacterHandlerBase() { }

	public bool get_IsActiveIndoor() { }

	public bool get_IsActiveOutdoor() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public override bool IsOnGround(LevelItem levelItem, LevelDropArea dropArea) { }

	public virtual bool IsRelevantForTarget(ICATarget target) { }

	public void set_IsActiveIndoor(bool value) { }

	public void set_IsActiveOutdoor(bool value) { }

}

