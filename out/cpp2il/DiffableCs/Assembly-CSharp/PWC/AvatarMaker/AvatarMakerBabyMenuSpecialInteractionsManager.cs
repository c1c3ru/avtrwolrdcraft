namespace PWC.AvatarMaker;

public class AvatarMakerBabyMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{

	public AvatarMakerBabyMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

