namespace PWC.Multiplayer;

public static class MPDataHelper_Transform
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Vector2, PJVector2> <>9__0_0; //Field offset: 0x8
		public static Action <>9__1_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <HandleData>b__1_0() { }

		internal PJVector2 <TrySendEvent>b__0_0(Vector2 x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1_0
	{
		public PDSceneObject sceneObject; //Field offset: 0x10
		public List<IMultiplayer_TransformChange> interfaceTargets; //Field offset: 0x18
		public Action<Single> <>9__1; //Field offset: 0x20
		public Action <>9__2; //Field offset: 0x28

		public <>c__DisplayClass1_0() { }

		internal void <HandleData>b__1(float x) { }

		internal void <HandleData>b__2() { }

	}


	public static void HandleData(MPData_Transform data) { }

	public static void TrySendEvent(PDSceneObject sceneObject, List<Vector2> positions, bool isFlipped = false, float duration = 0, bool shouldAddParent = false) { }

}

