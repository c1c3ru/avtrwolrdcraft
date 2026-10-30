namespace Google.Play.Core.Internal;

public class PlayCoreEventHandler : MonoBehaviour
{
	private static PlayCoreEventHandler _instance; //Field offset: 0x0
	private readonly Queue<Action> _sharedEventQueue; //Field offset: 0x20
	private readonly Queue<Action> _localEventQueue; //Field offset: 0x28

	public PlayCoreEventHandler() { }

	private void Awake() { }

	public static void CreateInScene() { }

	public static void HandleEvent(Action action) { }

	private void HandleEventInternal(Action action) { }

	private void Update() { }

}

