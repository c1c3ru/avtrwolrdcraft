//Type is in global namespace

public class LevelSummonPilotSecret : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IMultiplayer_RequireSceneObject
{
	[SerializeField]
	private TextMesh _leftCode; //Field offset: 0x20
	[SerializeField]
	private TextMesh _centerCode; //Field offset: 0x28
	[SerializeField]
	private TextMesh _rightCode; //Field offset: 0x30
	[SerializeField]
	private LevelCharacterCaller _caller; //Field offset: 0x38
	[SerializeField]
	private GameObject _pressButton; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _onSecretSolvedEvent; //Field offset: 0x48
	private bool _isSecretSolved; //Field offset: 0x50

	public LevelSummonPilotSecret() { }

	private bool CheckIfSecretSolved() { }

	private void IncreaseText(TextMesh text) { }

	public override void OnPointerClick(PointerEventData eventData) { }

	private override GameObject PWC.Multiplayer.IMultiplayer_RequireSceneObject.Multiplayer_GetGameObjectToEnsureSceneObjectOn() { }

}

