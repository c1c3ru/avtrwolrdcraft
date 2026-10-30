namespace PazuCore.AF.Feed;

public class FeedItemCTA
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public FeedItemCTA <>4__this; //Field offset: 0x10
		public Action<Boolean> onFinish; //Field offset: 0x18
		public int gameId; //Field offset: 0x20

		public <>c__DisplayClass5_0() { }

		internal void <Execute>b__0(bool success) { }

		internal void <Execute>b__2(bool success) { }

		internal void <Execute>b__3() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_1
	{
		public int gameBundleId; //Field offset: 0x10
		public <>c__DisplayClass5_0 CS$<>8__locals1; //Field offset: 0x18

		public <>c__DisplayClass5_1() { }

		internal void <Execute>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Action aciton; //Field offset: 0x10
		public bool callOnFinishOnPass; //Field offset: 0x18
		public Action<Boolean> onFinish; //Field offset: 0x20

		public <>c__DisplayClass6_0() { }

		internal void <ExecuteWithParentalGate>b__0() { }

		internal void <ExecuteWithParentalGate>b__1() { }

	}

	[CompilerGenerated]
	private static Action<FeedItemCTA> OnCTAExecutedAction; //Field offset: 0x0
	private readonly FeedItemData _feedItemModel; //Field offset: 0x10

	public static event Action<FeedItemCTA> OnCTAExecutedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public FeedItemCTA(FeedItemData feedItemModel) { }

	[CompilerGenerated]
	public static void add_OnCTAExecutedAction(Action<FeedItemCTA> value) { }

	public void Execute(Action<Boolean> onFinish = null) { }

	private void ExecuteWithParentalGate(Action aciton, Action<Boolean> onFinish, bool callOnFinishOnPass = true) { }

	private void OnCTAExecuted() { }

	[CompilerGenerated]
	public static void remove_OnCTAExecutedAction(Action<FeedItemCTA> value) { }

}

