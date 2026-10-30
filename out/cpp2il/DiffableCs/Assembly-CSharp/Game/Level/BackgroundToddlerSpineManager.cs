namespace Game.Level;

public class BackgroundToddlerSpineManager : ToddlerSpineSkinsManager
{
	[SerializeField]
	private int _backgroundCharacterID; //Field offset: 0xC0
	private string _defaultIdleAnimation; //Field offset: 0xC8

	public BackgroundToddlerSpineManager() { }

	public void SetAnimation(string newAnimation) { }

	private void Start() { }

}

