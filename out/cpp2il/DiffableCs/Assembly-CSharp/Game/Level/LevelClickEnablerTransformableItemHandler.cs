namespace Game.Level;

public class LevelClickEnablerTransformableItemHandler : MonoBehaviour
{
	[SerializeField]
	private LevelTransformableObjectHandlerBase _transformableObject; //Field offset: 0x20
	private bool _isUnlocked; //Field offset: 0x28

	public LevelClickEnablerTransformableItemHandler() { }

	private void Awake() { }

	private bool CanBeClicked() { }

	private void OnDestroy() { }

	public void SetState(bool isUnlocked) { }

}

