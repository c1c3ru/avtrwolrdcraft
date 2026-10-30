namespace Game.Level;

public class LevelWeatherData
{
	public float LevelWidth; //Field offset: 0x10
	public VFXAreaData[] vfxAreaDataArray; //Field offset: 0x18

	public LevelWeatherData(VFXAreaData[] vfxArray, float levelWidth) { }

}

