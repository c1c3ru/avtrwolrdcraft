namespace PazuCore.PazuCoreAddressables.AFC.RD;

public class AFCRDHandlersManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public AFCRDCloudCallHandler <handler>5__2; //Field offset: 0x10
		public AFCRDOpenForParentsHandler <handler>5__3; //Field offset: 0x18
		public AFCRDOpenGameHandler <handler>5__4; //Field offset: 0x20
		public AFCRDOpenUrlHandler <handler>5__5; //Field offset: 0x28

		public <>c__DisplayClass4_0() { }

		internal void <OnRDHandlerCreated>b__0(CloudCallData data) { }

		internal void <OnRDHandlerCreated>b__1(OpenForParentsData data) { }

		internal void <OnRDHandlerCreated>b__2(OpenGameData data) { }

		internal void <OnRDHandlerCreated>b__3(OpenUrlData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public string id; //Field offset: 0x0

		public <>c__DisplayClass5_0`1() { }

		internal bool <SetData>b__0(T x) { }

	}

	private AFCRDHandlersData _data; //Field offset: 0x20

	public AFCRDHandlersManager() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnRDHandlerCreated(AFCRDHandlerBase handlerBase) { }

	public void SetData(AFCRDHandlersData data) { }

	private void SetData(List<T> list, string id, Action<T> onSuccess) { }

}

