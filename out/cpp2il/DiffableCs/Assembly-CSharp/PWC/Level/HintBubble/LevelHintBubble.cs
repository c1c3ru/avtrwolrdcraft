namespace PWC.Level.HintBubble;

public class LevelHintBubble : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _leftItem; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _rightItem; //Field offset: 0x28
	private int _tweenId; //Field offset: 0x30

	public LevelHintBubble() { }

	[CompilerGenerated]
	private void <Hide>b__6_0() { }

	[CompilerGenerated]
	internal static void <SetSprites>g__SetSprite|4_0(SpriteRenderer spriteRenderer, Sprite sprite) { }

	public void Hide() { }

	public void SetSprites(Sprite leftSprite, Sprite rightSprite) { }

	public void Show() { }

	public static LevelHintBubble Spawn(Transform parent) { }

}

