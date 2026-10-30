namespace PazuCore.PazuCoreAddressables.AFC;

public class AFCImageCarousel : MonoBehaviour
{
	internal enum Direction
	{
		Left = 0,
		Right = 1,
		Up = 2,
		Down = 3,
	}

	[SerializeField]
	private Direction _direction; //Field offset: 0x20
	[Min(0)]
	[SerializeField]
	[Space]
	private float _movementSpeed; //Field offset: 0x24
	[Min(0)]
	[SerializeField]
	private float _destination; //Field offset: 0x28
	[SerializeField]
	private Transform[] _objects; //Field offset: 0x30

	public AFCImageCarousel() { }

	private void Update() { }

}

