namespace PWC.UGC;

[CreateAssetMenu(fileName = "AmbienceData_", menuName = "PazuWorld/Level/New Zone Ambiance Data")]
public class ZoneViewAmbienceData : ScriptableObject
{
	public string dayAmbient; //Field offset: 0x18
	public string sunsetAmbient; //Field offset: 0x20
	public string nightAmbient; //Field offset: 0x28

	public ZoneViewAmbienceData() { }

}

