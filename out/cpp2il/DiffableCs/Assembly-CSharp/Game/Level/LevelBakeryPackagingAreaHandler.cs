namespace Game.Level;

public class LevelBakeryPackagingAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <PackItem>b__0(LevelItem item) { }

	}

	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x28
	[SerializeField]
	private LevelSpawn[] _foodPackages; //Field offset: 0x30
	[SerializeField]
	private LevelSpawn[] _drinkPackages; //Field offset: 0x38
	[SerializeField]
	private string _drinkPackageSound; //Field offset: 0x40
	[SerializeField]
	private string _foodPackageSound; //Field offset: 0x48

	public LevelBakeryPackagingAreaHandler() { }

	private void Awake() { }

	private bool IsTakeAwayBag(LevelItem levelItem) { }

	private void OnDestroy() { }

	private void PackItem(LevelItem levelItem) { }

}

