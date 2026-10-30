namespace Game.Level;

[AddComponentMenu(null)]
public class LevelDayNightInteractionHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onNightEvent; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onDayEvent; //Field offset: 0x28
	private bool _hasPlayedDayEvent; //Field offset: 0x30

	public LevelDayNightInteractionHandler() { }

	private void Awake() { }

	private void OnBackgroundPlanetClick() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

}

