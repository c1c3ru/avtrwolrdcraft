namespace UnityEngine.AddressableAssets.Utility;

internal class DiagnosticInfo
{
	public string DisplayName; //Field offset: 0x10
	public int ObjectId; //Field offset: 0x18
	public Int32[] Dependencies; //Field offset: 0x20

	public DiagnosticInfo() { }

	public DiagnosticEvent CreateEvent(string category, DiagnosticEventType eventType, int frame, int val) { }

}

