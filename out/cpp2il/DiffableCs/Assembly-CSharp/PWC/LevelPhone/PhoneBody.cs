namespace PWC.LevelPhone;

public class PhoneBody : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Int32> OnCharacterConsumedAction; //Field offset: 0x0
	[SerializeField]
	private CShape _cShape; //Field offset: 0x20
	private bool _didInit; //Field offset: 0x28

	public static event Action<Int32> OnCharacterConsumedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public PhoneBody() { }

	[CompilerGenerated]
	public static void add_OnCharacterConsumedAction(Action<Int32> value) { }

	[CompilerGenerated]
	public static void remove_OnCharacterConsumedAction(Action<Int32> value) { }

	public bool TryConsumeCharacter(LevelCharacter character) { }

}

