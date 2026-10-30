namespace PWC.AvatarMaker;

public class AvatarMakerCharacterMenuSpecialInteractionsManager : AvatarMakerMenuSpecialInteractionsManagerBase
{
	private const string PREGNANT_ONEPIECE_CASUAL_FIRST_TIME_SCROLLING = "PreganatOnepieceCasualFirstTimeScrolling"; //Field offset: 0x0

	public AvatarMakerCharacterMenuSpecialInteractionsManager() { }

	public virtual bool DidPerformSpecialInteraction(int categoryType) { }

	public virtual void SetSpecialInteractionPerformed(int categoryType) { }

	public virtual bool ShouldPerformSpecialInteraction(int categoryType) { }

}

