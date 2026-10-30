namespace Game.Level.Baking;

public class LevelBakingMoldItemHandler : MonoBehaviour
{
	internal enum MoldShape
	{
		Square = 0,
		Star = 1,
		Round = 2,
		Butterfly = 3,
		Cat = 4,
		Flower = 5,
		Heart = 6,
	}

	private const string TOPPING_DIRECTORY_PATH = "Food_BakeryToppings/"; //Field offset: 0x0
	private const string SHAPE_L20_SUFFIX = "Shape_L20"; //Field offset: 0x0
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private bool _isBigMold; //Field offset: 0x28
	[SerializeField]
	private MoldShape _shape; //Field offset: 0x2C
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x30
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference _coloredPastry; //Field offset: 0x40
	[SerializeField]
	private Color _defaultColor; //Field offset: 0x48

	public LevelBakingMoldItemHandler() { }

	private LevelItem CreateAsset(Color doughColor, string toppingPath, string toppingName) { }

	public void Cut(LevelItem dough) { }

	private string FindAssetsPath(string toppingName, bool isColored) { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	private string GetShape() { }

}

