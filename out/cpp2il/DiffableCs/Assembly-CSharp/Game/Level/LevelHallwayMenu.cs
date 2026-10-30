namespace Game.Level;

public class LevelHallwayMenu : MonoBehaviour
{
	[SerializeField]
	private LevelToggleableSprite _toggleableSprite; //Field offset: 0x20
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x28

	public LevelHallwayMenu() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPreSaveProgressAction(Scene scene) { }

	private void SaveIndex() { }

}

