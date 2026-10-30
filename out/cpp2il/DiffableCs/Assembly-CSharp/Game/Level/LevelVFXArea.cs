namespace Game.Level;

public class LevelVFXArea : LevelAreaBase
{
	internal enum VFXAreaEffectType
	{
		HardGround = 0,
		SoftGround = 1,
		WaterSurface = 2,
		VerticalGlass = 3,
	}

	public static List<VFXAreaData> vfxAreaDataList; //Field offset: 0x0
	[SerializeField]
	private List<WeatherType> _supportedWeatherTypes; //Field offset: 0x38
	[SerializeField]
	private VFXAreaEffectType _vfxAreaEffectType; //Field offset: 0x40
	[SerializeField]
	private float _emissionRateMultiplier; //Field offset: 0x44
	[SerializeField]
	private List<ExtraDataListEntry> extraDataEntries; //Field offset: 0x48

	public float EmissionRateMultiplier
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public List<ExtraDataListEntry> ExtraDataEntries
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public List<WeatherType> SupportedWeatherTypes
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public VFXAreaEffectType VfxAreaEffectType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	private static LevelVFXArea() { }

	public LevelVFXArea() { }

	public static void AddVFXAreaData(VFXAreaData data) { }

	public float get_EmissionRateMultiplier() { }

	public List<ExtraDataListEntry> get_ExtraDataEntries() { }

	public List<WeatherType> get_SupportedWeatherTypes() { }

	public VFXAreaEffectType get_VfxAreaEffectType() { }

	public void set_EmissionRateMultiplier(float value) { }

	public void set_ExtraDataEntries(List<ExtraDataListEntry> value) { }

	public void set_SupportedWeatherTypes(List<WeatherType> value) { }

	public void set_VfxAreaEffectType(VFXAreaEffectType value) { }

}

