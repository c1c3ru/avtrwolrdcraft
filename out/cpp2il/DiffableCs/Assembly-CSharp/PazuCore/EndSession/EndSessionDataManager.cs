namespace PazuCore.EndSession;

public class EndSessionDataManager : MonoBehaviour
{
	[CompilerGenerated]
	private static EndSessionDataManager <Instance>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private EndSessionResponseData <LastResponseData>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private EndSessionBaseData <CurrentBaseData>k__BackingField; //Field offset: 0x28

	public EndSessionBaseData CurrentBaseData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public private static EndSessionDataManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public EndSessionResponseData LastResponseData
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public EndSessionDataManager() { }

	private void Awake() { }

	[CompilerGenerated]
	public EndSessionBaseData get_CurrentBaseData() { }

	[CompilerGenerated]
	public static EndSessionDataManager get_Instance() { }

	[CompilerGenerated]
	public EndSessionResponseData get_LastResponseData() { }

	private void OnDestroy() { }

	[CompilerGenerated]
	public void set_CurrentBaseData(EndSessionBaseData value) { }

	[CompilerGenerated]
	private static void set_Instance(EndSessionDataManager value) { }

	[CompilerGenerated]
	public void set_LastResponseData(EndSessionResponseData value) { }

}

