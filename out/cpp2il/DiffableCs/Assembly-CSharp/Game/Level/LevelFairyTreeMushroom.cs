namespace Game.Level;

public class LevelFairyTreeMushroom : LevelLight
{
	[CompilerGenerated]
	private static Action<Boolean> OnFairyTreeMushroomClickAction; //Field offset: 0x0
	public const int NUMBER_OF_FAIRY_MUSHROOMS = 3; //Field offset: 0x0

	public static event Action<Boolean> OnFairyTreeMushroomClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelFairyTreeMushroom() { }

	[CompilerGenerated]
	public static void add_OnFairyTreeMushroomClickAction(Action<Boolean> value) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnFairyTreeMushroomClickAction(Action<Boolean> value) { }

}

