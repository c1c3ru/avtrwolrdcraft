namespace Game.Level.Arcade;

public class LevelArcadeSecretLight : LevelLight
{
	[CompilerGenerated]
	private static Action<Direction> OnLightClick; //Field offset: 0x0
	[SerializeField]
	private Direction direction; //Field offset: 0xC0
	private bool _isAnimated; //Field offset: 0xC4

	public static event Action<Direction> OnLightClick
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelArcadeSecretLight() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__5_0() { }

	[CompilerGenerated]
	public static void add_OnLightClick(Action<Direction> value) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public static void remove_OnLightClick(Action<Direction> value) { }

}

