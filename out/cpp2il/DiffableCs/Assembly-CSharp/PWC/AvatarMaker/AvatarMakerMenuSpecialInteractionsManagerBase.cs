namespace PWC.AvatarMaker;

public abstract class AvatarMakerMenuSpecialInteractionsManagerBase : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<Int32> OnSpecialInteractionPerformedAction; //Field offset: 0x0

	public static event Action<Int32> OnSpecialInteractionPerformedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected AvatarMakerMenuSpecialInteractionsManagerBase() { }

	[CompilerGenerated]
	public static void add_OnSpecialInteractionPerformedAction(Action<Int32> value) { }

	public abstract bool DidPerformSpecialInteraction(int categoryType) { }

	[CompilerGenerated]
	public static void remove_OnSpecialInteractionPerformedAction(Action<Int32> value) { }

	public override void SetSpecialInteractionPerformed(int categoryType) { }

	public abstract bool ShouldPerformSpecialInteraction(int categoryType) { }

}

