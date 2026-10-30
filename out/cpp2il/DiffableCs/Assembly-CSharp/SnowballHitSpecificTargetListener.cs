//Type is in global namespace

public class SnowballHitSpecificTargetListener : MonoBehaviour
{
	[SerializeField]
	private int _desiredID; //Field offset: 0x20
	[SerializeField]
	private UnityEvent OnDesiredTargetHit; //Field offset: 0x28

	public SnowballHitSpecificTargetListener() { }

	private void Awake() { }

	private void HandleBallHit(int ID) { }

	private void OnDestroy() { }

}

