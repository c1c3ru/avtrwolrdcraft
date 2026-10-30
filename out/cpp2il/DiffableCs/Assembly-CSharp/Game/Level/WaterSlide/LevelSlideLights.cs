namespace Game.Level.WaterSlide;

public class LevelSlideLights : MonoBehaviour
{
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x20
	[SerializeField]
	private LevelToggleableGameObject _toggleableSprite; //Field offset: 0x28

	public LevelSlideLights() { }

	private void Awake() { }

	private void ChangeLights() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnPlayerChangedScene(int id, string sceneName) { }

}

