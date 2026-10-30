namespace UnityEngine.ResourceManagement.Diagnostics;

public class DiagnosticEventCollectorSingleton : ComponentSingleton<DiagnosticEventCollectorSingleton>
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<DiagnosticEvent, Int32> <>9__8_0; //Field offset: 0x8
		public static Action<DiagnosticEvent> <>9__11_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <Awake>b__11_0(DiagnosticEvent diagnosticEvent) { }

		internal int <RegisterEventHandler>b__8_0(DiagnosticEvent evt) { }

	}

	private static Guid s_editorConnectionGuid; //Field offset: 0x0
	internal Dictionary<Int32, DiagnosticEvent> m_CreatedEvents; //Field offset: 0x20
	internal List<DiagnosticEvent> m_UnhandledEvents; //Field offset: 0x28
	internal DelegateList<DiagnosticEvent> s_EventHandlers; //Field offset: 0x30
	private float m_lastTickSent; //Field offset: 0x38
	private int m_lastFrame; //Field offset: 0x3C
	private float fpsAvg; //Field offset: 0x40

	public static Guid PlayerConnectionGuid
	{
		 get { } //Length: 252
	}

	public DiagnosticEventCollectorSingleton() { }

	private void Awake() { }

	public static Guid get_PlayerConnectionGuid() { }

	protected virtual string GetGameObjectName() { }

	public void PostEvent(DiagnosticEvent diagnosticEvent) { }

	public static bool RegisterEventHandler(Action<DiagnosticEvent> handler, bool register, bool create) { }

	internal void RegisterEventHandler(Action<DiagnosticEvent> handler) { }

	public void UnregisterEventHandler(Action<DiagnosticEvent> handler) { }

	private void Update() { }

}

