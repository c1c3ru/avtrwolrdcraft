namespace PWC;

[CreateAssetMenu(menuName = "PazuWorld/Color By Time of Day")]
public class ColorByTimeOfDay : ScriptableObject
{
	public Color DayColor; //Field offset: 0x18
	public Color SunsetColor; //Field offset: 0x28
	public Color NightColor; //Field offset: 0x38

	public ColorByTimeOfDay() { }

}

