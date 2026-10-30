namespace Game.Level;

public class LevelEventOnWeightReachedHandler : MonoBehaviour
{
	[SerializeField]
	private LevelWeightAvatarIDHandler _weightHandler; //Field offset: 0x20
	[SerializeField]
	private float _targetWeight; //Field offset: 0x28
	[SerializeField]
	private bool _canFireMultipleTimes; //Field offset: 0x2C
	[SerializeField]
	private UnityEvent _onWeightReached; //Field offset: 0x30
	private bool _hasFired; //Field offset: 0x38

	public LevelEventOnWeightReachedHandler() { }

	private void Awake() { }

	private void CheckWeight(float weight) { }

	private void OnDestroy() { }

}

