namespace PWC.AvatarMaker;

public class AvatarMakerToddlerMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{

	public AvatarMakerToddlerMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

