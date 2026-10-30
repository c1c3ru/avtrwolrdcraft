namespace Game.Level;

public class LevelAddCAOnAllCharactersHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public AvatarSpineSkinsManagerBase skinsManager; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <TryAddCaScriptToAvatar>b__0(SpineTypeCondition x) { }

	}

	internal enum CAScriptsEnum
	{
		None = 0,
		LevelCAFurnitureShopCharacterHandler = 1,
		LevelCAAirportF2CharacterHandler = 2,
		LevelCAMusicStudioCharacterHandler = 3,
		LevelCAStarsBoulevardCharacterHandler = 4,
		LevelCAKPopShopCharacterHandler = 5,
		LevelCAWalkwayCharacterHandler = 6,
		LevelCAHospitalCharacterHandler = 7,
		LevelCAHospitalIllCharacterHandler = 8,
		LevelCAFarmingFieldsCharacterHandler = 9,
		LevelCACampusAuditoriumCharacterHandler = 10,
		LevelCAGarageCharacterHandler = 11,
	}

	private static readonly Dictionary<CAScriptsEnum, Type> _map; //Field offset: 0x0
	[SerializeField]
	private CAScriptsEnum _caScriptToAdd; //Field offset: 0x20
	[SerializeField]
	private bool _acceptAllAvatars; //Field offset: 0x24
	[SerializeField]
	private List<SpineTypeCondition> _conditions; //Field offset: 0x28
	private Type type; //Field offset: 0x30

	private static LevelAddCAOnAllCharactersHandler() { }

	public LevelAddCAOnAllCharactersHandler() { }

	private void AddCaScriptToAvatar(ICATarget levelAvatar) { }

	private void Awake() { }

	private void OnAfterAvatarSpawn(ILevelAvatar avatar) { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private bool TryAddCaScriptToAvatar(ILevelAvatar levelAvatar) { }

}

