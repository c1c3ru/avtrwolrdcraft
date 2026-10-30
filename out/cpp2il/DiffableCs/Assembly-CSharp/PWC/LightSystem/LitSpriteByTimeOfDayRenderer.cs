namespace PWC.LightSystem;

public class LitSpriteByTimeOfDayRenderer : LitSpriteRenderer
{
	[SerializeField]
	private ColorByTimeOfDay _colorByTimeOfDay; //Field offset: 0x70

	public LitSpriteByTimeOfDayRenderer() { }

	public virtual void ApplyIntensity() { }

	public void SetColors(ColorByTimeOfDay colorByTimeOfDay) { }

}

