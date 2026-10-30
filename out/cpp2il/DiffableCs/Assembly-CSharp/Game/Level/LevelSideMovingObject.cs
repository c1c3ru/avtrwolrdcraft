namespace Game.Level;

public class LevelSideMovingObject : MonoBehaviour, IExcludeFromBulkData
{
	[SerializeField]
	private float _targetXPosition; //Field offset: 0x20
	[SerializeField]
	private bool _isDestroyedOnDestination; //Field offset: 0x24
	[SerializeField]
	private float _movementSpeed; //Field offset: 0x28

	public LevelSideMovingObject() { }

	[CompilerGenerated]
	private void <StartMove>b__4_0() { }

	private void Awake() { }

	private void StartMove() { }

}

