namespace Game.Level;

public class LevelSafeWithOneTimeEvent : MonoBehaviour
{
	[SerializeField]
	private LevelSafePermutationSprite[] _numberButtons; //Field offset: 0x20
	[SerializeField]
	private OneTimeEvent _oneTimeEvent; //Field offset: 0x28
	private bool _isSolved; //Field offset: 0x30

	public LevelSafeWithOneTimeEvent() { }

	protected void Awake() { }

	private bool CanOpenDoor() { }

	private void Init() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void TryOpenSafe() { }

}

