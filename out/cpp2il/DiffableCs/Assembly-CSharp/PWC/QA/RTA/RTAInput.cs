namespace PWC.QA.RTA;

public static class RTAInput
{
	[CompilerGenerated]
	private struct <PrepareInteractionAsync_Internal>d__5 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<PointerEventData> <>t__builder; //Field offset: 0x8
		public bool forceMoveCamera; //Field offset: 0x20
		public Vector2 worldPos; //Field offset: 0x24
		private Camera <mainCamera>5__2; //Field offset: 0x30
		private TaskAwaiter <>u__1; //Field offset: 0x38

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TryClickAsync>d__2 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		public Component component; //Field offset: 0x20
		private TaskAwaiter<PointerEventData> <>u__1; //Field offset: 0x28
		private TaskAwaiter <>u__2; //Field offset: 0x30

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	[CompilerGenerated]
	private struct <TrySwipeAsync>d__3 : IAsyncStateMachine
	{
		public int <>1__state; //Field offset: 0x0
		public AsyncTaskMethodBuilder<Boolean> <>t__builder; //Field offset: 0x8
		public Component component; //Field offset: 0x20
		public float swipeXDelta; //Field offset: 0x28
		private Vector2 <worldPos>5__2; //Field offset: 0x2C
		private PointerEventData <eventData>5__3; //Field offset: 0x38
		private TaskAwaiter<PointerEventData> <>u__1; //Field offset: 0x40
		private TaskAwaiter <>u__2; //Field offset: 0x48

		private override void MoveNext() { }

		[DebuggerHidden]
		private override void SetStateMachine(IAsyncStateMachine stateMachine) { }

	}

	private static int POST_CLICK_DELAY_MS; //Field offset: 0x0
	private static float GAME_CAMERA_TWEEN_DURATION; //Field offset: 0x4

	private static RTAInput() { }

	private static Camera GetCamera_Internal() { }

	private static Vector2 GetComponentPosition_Internal(Component component) { }

	[AsyncStateMachine(typeof(<PrepareInteractionAsync_Internal>d__5))]
	private static Task<PointerEventData> PrepareInteractionAsync_Internal(Vector2 worldPos, bool forceMoveCamera = false) { }

	[AsyncStateMachine(typeof(<TryClickAsync>d__2))]
	public static Task<Boolean> TryClickAsync(Component component) { }

	[AsyncStateMachine(typeof(<TrySwipeAsync>d__3))]
	public static Task<Boolean> TrySwipeAsync(Component component, float swipeXDelta) { }

}

