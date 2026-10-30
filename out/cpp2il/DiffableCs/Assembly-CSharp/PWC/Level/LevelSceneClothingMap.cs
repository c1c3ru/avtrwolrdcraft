namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Scene Clothing Map")]
public class LevelSceneClothingMap : ScriptableObject
{
	internal class Clothing
	{
		public SpineType spineType; //Field offset: 0x10
		public string skinName; //Field offset: 0x18
		public Vector2 position; //Field offset: 0x20

		public Clothing() { }

	}

	private static Dictionary<String, Dictionary`2<ValueTuple`2<SpineType, String>, Clothing>> _clothingsForScenes; //Field offset: 0x0
	public const string SCECNE_CLOTHING_MAP_PATH = "Level/SceneClothingMap/"; //Field offset: 0x0
	private static Dictionary<ValueTuple`2<SpineType, String>, Clothing> _clothings; //Field offset: 0x8
	private static bool _didLoadData; //Field offset: 0x10
	public List<Clothing> clothings; //Field offset: 0x18

	public LevelSceneClothingMap() { }

	public static void LoadDataIfNeeded() { }

	public static bool TryGetClothing(ValueTuple<SpineType, String> key, out Clothing character) { }

	public static bool TryGetClothings(string sceneName, out Dictionary<ValueTuple`2<SpineType, String>, Clothing>& dict) { }

}

