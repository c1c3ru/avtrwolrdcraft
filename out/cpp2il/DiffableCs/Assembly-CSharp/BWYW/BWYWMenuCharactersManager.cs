namespace BWYW;

public class BWYWMenuCharactersManager : MonoBehaviour
{
	[CompilerGenerated]
	private static BWYWMenuCharactersManager <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private BWYWMenuCharacter _characterPrefab; //Field offset: 0x20
	private BWYWMenuCharacter _currentCharacter; //Field offset: 0x28

	public private static BWYWMenuCharactersManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public BWYWMenuCharactersManager() { }

	public void AddCharacter(SkillType skillType, int characterID, Sprite titleSprite) { }

	public void Awake() { }

	[CompilerGenerated]
	public static BWYWMenuCharactersManager get_Instance() { }

	public void Init(SkillType skillType, int activeChapter, int focusedChapter) { }

	public void OnGiftClaim() { }

	public void OnTaskClaim() { }

	[CompilerGenerated]
	private static void set_Instance(BWYWMenuCharactersManager value) { }

}

