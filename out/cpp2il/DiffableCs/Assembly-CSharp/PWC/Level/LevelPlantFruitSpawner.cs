namespace PWC.Level;

public class LevelPlantFruitSpawner : MonoBehaviour
{
	[SerializeField]
	protected bool _tweenAwayOnPickUp; //Field offset: 0x20
	[SerializeField]
	protected PDPrefabReference _fruitPrefab; //Field offset: 0x28
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x30

	public LevelPlantFruitSpawner() { }

	[CompilerGenerated]
	private void <OnItemPickUp>b__6_0() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem levelItem) { }

	public void SpawnFruit() { }

}

