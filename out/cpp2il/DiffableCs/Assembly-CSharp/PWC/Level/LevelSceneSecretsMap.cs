namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Level Scene Secrets Map")]
public class LevelSceneSecretsMap : ScriptableObject
{
	private static Dictionary<String, List`1<SecretFullId>> _secretsForScenes; //Field offset: 0x0
	public const string SCECNE_SECRETS_MAP_PATH = "Level/SceneSecretsMap/"; //Field offset: 0x0
	private static bool _didLoadData; //Field offset: 0x8
	public List<SecretFullId> secrets; //Field offset: 0x18

	public LevelSceneSecretsMap() { }

	public static void LoadDataIfNeeded() { }

	public static bool TryGetSecrets(string sceneName, out List<SecretFullId>& dict) { }

}

