namespace Game.Level;

public class LevelRotatingBurgerSecret : MonoBehaviour
{
	[SerializeField]
	private LevelDoor _levelDoor; //Field offset: 0x20
	[SerializeField]
	private LevelRotateInteractable[] _burgers; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onRoationCompletedEvent; //Field offset: 0x30

	public LevelRotatingBurgerSecret() { }

	private void Awake() { }

	private void CheckRoations() { }

	private void OnDestroy() { }

}

