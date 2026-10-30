namespace Game.Level;

public class VFXAreaData
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<ExtraDataListEntry, ExtraDataListEntry> <>9__8_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal ExtraDataListEntry <.ctor>b__8_0(ExtraDataListEntry e) { }

	}

	public MeshData meshData; //Field offset: 0x10
	public Vector3 positionOffset; //Field offset: 0x18
	public VFXAreaEffectType vfxAreaEffectType; //Field offset: 0x24
	public List<WeatherType> supportedWeatherTypes; //Field offset: 0x28
	public string parentSceneGuid; //Field offset: 0x30
	public int sortingOrder; //Field offset: 0x38
	public float emissionRateMultiplier; //Field offset: 0x3C
	public List<ExtraDataListEntry> extraDataEntries; //Field offset: 0x40

	public VFXAreaData(Mesh mesh, Vector3 positionOffset, VFXAreaEffectType vfxAreaEffectType, List<WeatherType> supportedWeatherTypes, string parentSceneGuid, int sortingOrder, float emissionRateMultiplier = 1, List<ExtraDataListEntry> extraDataEntries = null) { }

	public Mesh ToMesh() { }

}

