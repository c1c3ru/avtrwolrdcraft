namespace Game.Level;

public class LevelMicrophoneItemHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject _orientedGameObject; //Field offset: 0x20
	[SerializeField]
	private float _onStandAngle; //Field offset: 0x28

	public LevelMicrophoneItemHandler() { }

	public void RotateToStandPosition(bool isSnap = false) { }

}

