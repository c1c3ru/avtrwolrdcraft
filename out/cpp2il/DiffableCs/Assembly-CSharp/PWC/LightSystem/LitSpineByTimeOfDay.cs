namespace PWC.LightSystem;

public class LitSpineByTimeOfDay : LitSpine
{
	[SerializeField]
	private ColorByTimeOfDay _colorByTimeOfDay; //Field offset: 0x78

	public LitSpineByTimeOfDay() { }

	public virtual void ApplyIntensity() { }

}

