namespace PWC.Street;

public class StreetCloudSection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public int sortingOrder; //Field offset: 0x10
		public Transform endPoint; //Field offset: 0x18
		public WorldCloudsSpawner spawner; //Field offset: 0x20

		public <>c__DisplayClass1_0() { }

		internal void <Init>b__0(WorldCloud cloud) { }

	}

	[SerializeField]
	private List<WorldCloud> _clouds; //Field offset: 0x20

	public StreetCloudSection() { }

	public void Init(int sortingOrder, Transform endPoint, WorldCloudsSpawner spawner) { }

}

