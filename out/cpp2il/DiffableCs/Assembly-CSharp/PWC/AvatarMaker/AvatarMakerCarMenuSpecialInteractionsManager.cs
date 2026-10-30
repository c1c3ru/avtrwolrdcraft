namespace PWC.AvatarMaker;

public class AvatarMakerCarMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{

	public AvatarMakerCarMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

