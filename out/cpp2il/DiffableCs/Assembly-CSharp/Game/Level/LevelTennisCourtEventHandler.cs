namespace Game.Level;

public class LevelTennisCourtEventHandler : MonoBehaviour
{
	[SerializeField]
	public UnityEvent OnServedBall; //Field offset: 0x20
	[SerializeField]
	public UnityEvent OnOpponentServeAction; //Field offset: 0x28

	public LevelTennisCourtEventHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnOpponentServe(LevelCATennisballItemHandler handler) { }

	private void OnServe(LevelCATennisballItemHandler handler) { }

}

