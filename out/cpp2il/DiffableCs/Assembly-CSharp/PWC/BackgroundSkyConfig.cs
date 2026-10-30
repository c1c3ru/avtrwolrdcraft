namespace PWC;

[CreateAssetMenu(menuName = "PazuWorld/Background Sky Config")]
public class BackgroundSkyConfig : ScriptableObject
{
	public Color[] nightToSunriseTopColors; //Field offset: 0x18
	public Color[] nightToSunriseBottomColors; //Field offset: 0x20
	public Color[] sunriseToDayTopColors; //Field offset: 0x28
	public Color[] sunriseToDayBottomColors; //Field offset: 0x30
	public Color[] dayToSunsetTopColors; //Field offset: 0x38
	public Color[] dayToSunsetBottomColors; //Field offset: 0x40
	public Color[] sunsetToNightTopColors; //Field offset: 0x48
	public Color[] sunsetToNightBottomColors; //Field offset: 0x50

	public BackgroundSkyConfig() { }

	private void CopyArray(ref Color[] destination, Color[] source) { }

	public void SetFrom(BackgroundSkyConfig config) { }

}

