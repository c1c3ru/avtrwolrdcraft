namespace PWC.Level;

public class LevelCharacterMovementOverrideHandler : MonoBehaviour
{
	[SerializeField]
	private string _movementCyclesWalkOverride; //Field offset: 0x20

	public string MovementCyclesWalkOverride
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public LevelCharacterMovementOverrideHandler() { }

	public string get_MovementCyclesWalkOverride() { }

	public void set_MovementCyclesWalkOverride(string value) { }

}

