namespace PWC;

public class GameCameraBezierGroup : MonoBehaviour
{
	[SerializeField]
	private Transform _point1; //Field offset: 0x20
	[SerializeField]
	private Transform _handle1; //Field offset: 0x28
	[SerializeField]
	private Transform _handle2; //Field offset: 0x30
	[SerializeField]
	private Transform _point2; //Field offset: 0x38

	public Transform Handle1
	{
		 get { } //Length: 8
	}

	public Transform Handle2
	{
		 get { } //Length: 8
	}

	public Transform Point1
	{
		 get { } //Length: 8
	}

	public Transform Point2
	{
		 get { } //Length: 8
	}

	public GameCameraBezierGroup() { }

	public Transform get_Handle1() { }

	public Transform get_Handle2() { }

	public Transform get_Point1() { }

	public Transform get_Point2() { }

}

