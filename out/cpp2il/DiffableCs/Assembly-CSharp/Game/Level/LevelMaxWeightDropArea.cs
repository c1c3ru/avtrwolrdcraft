namespace Game.Level;

public class LevelMaxWeightDropArea : LevelDropArea
{
	[SerializeField]
	private LevelWeightCalculater _weightCalculater; //Field offset: 0xD8
	[SerializeField]
	private LevelLight _levelLight; //Field offset: 0xE0

	public LevelMaxWeightDropArea() { }

	[CompilerGenerated]
	private void <CanConsumeItem>b__2_0() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

}

