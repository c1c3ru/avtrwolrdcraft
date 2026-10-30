namespace UnityEngine.ResourceManagement.Util;

internal class DelayedActionManager : ComponentSingleton<DelayedActionManager>
{
	private struct DelegateInfo
	{
		private static int s_Id; //Field offset: 0x0
		private int m_Id; //Field offset: 0x0
		private Delegate m_Delegate; //Field offset: 0x8
		private Object[] m_Target; //Field offset: 0x10
		[CompilerGenerated]
		private float <InvocationTime>k__BackingField; //Field offset: 0x18

		public private float InvocationTime
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 8
			[CompilerGenerated]
			private set { } //Length: 8
		}

		public DelegateInfo(Delegate d, float invocationTime, Object[] p) { }

		[CompilerGenerated]
		[IsReadOnly]
		public float get_InvocationTime() { }

		public void Invoke() { }

		[CompilerGenerated]
		private void set_InvocationTime(float value) { }

		public virtual string ToString() { }

	}

	private List<DelegateInfo>[] m_Actions; //Field offset: 0x20
	private LinkedList<DelegateInfo> m_DelayedActions; //Field offset: 0x28
	private Stack<LinkedListNode`1<DelegateInfo>> m_NodeCache; //Field offset: 0x30
	private int m_CollectionIndex; //Field offset: 0x38
	private bool m_DestroyOnCompletion; //Field offset: 0x3C

	public static bool IsActive
	{
		 get { } //Length: 284
	}

	public DelayedActionManager() { }

	public static void AddAction(Delegate action, float delay = 0, Object[] parameters) { }

	private void AddActionInternal(Delegate action, float delay, Object[] parameters) { }

	public static void Clear() { }

	private void DestroyWhenComplete() { }

	public static bool get_IsActive() { }

	private LinkedListNode<DelegateInfo> GetNode(ref DelegateInfo del) { }

	private void InternalLateUpdate(float t) { }

	private void LateUpdate() { }

	private void OnApplicationQuit() { }

	public static bool Wait(float timeout = 0, float timeAdvanceAmount = 0) { }

}

