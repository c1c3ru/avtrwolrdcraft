namespace Game.Level;

public class LevelLightTurnOnOffEventListener : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onLampTurnOn; //Field offset: 0x20
	[SerializeField]
	private UnityEvent _onLampTurnOff; //Field offset: 0x28
	private LevelLight _lamp; //Field offset: 0x30

	public LevelLightTurnOnOffEventListener() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLampClick(bool isOn) { }

}

