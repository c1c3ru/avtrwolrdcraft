namespace PWC.AvatarMaker;

public class AvatarMakerHorseMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{

	public AvatarMakerHorseMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

