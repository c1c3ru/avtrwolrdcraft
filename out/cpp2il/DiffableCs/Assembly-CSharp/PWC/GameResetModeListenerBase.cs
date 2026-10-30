namespace PWC;

public abstract class GameResetModeListenerBase : MonoBehaviour
{

	protected GameResetModeListenerBase() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnEnterResetGameMode() { }

	private void OnExitResetGameMode() { }

	protected abstract void OnModeSet(bool isInResetGameMode) { }

}

