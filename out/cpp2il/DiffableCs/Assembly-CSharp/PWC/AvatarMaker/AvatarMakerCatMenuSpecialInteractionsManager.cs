namespace PWC.AvatarMaker;

public class AvatarMakerCatMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{

	public AvatarMakerCatMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

