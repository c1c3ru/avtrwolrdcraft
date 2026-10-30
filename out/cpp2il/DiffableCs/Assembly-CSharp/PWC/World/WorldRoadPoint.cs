namespace PWC.World;

public class WorldRoadPoint : MonoBehaviour
{
	[SerializeField]
	private List<WorldRoadPoint> _nextPoints; //Field offset: 0x20

	public WorldRoadPoint() { }

	public WorldRoadPoint GetFirstNextPoint() { }

	public WorldRoadPoint GetRandomNextPoint() { }

}

