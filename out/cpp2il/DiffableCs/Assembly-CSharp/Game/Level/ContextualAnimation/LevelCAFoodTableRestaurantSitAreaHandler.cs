namespace Game.Level.ContextualAnimation;

public class LevelCAFoodTableRestaurantSitAreaHandler : LevelCAParentHandlerBase
{
	private const string Eating_Fork_And_Knife = "Eating_Fork_And_Knife"; //Field offset: 0x0
	private LevelCharacter _character; //Field offset: 0x80
	private bool _isEatingForkAndKnife; //Field offset: 0x88
	private int _currentAnimationIndex; //Field offset: 0x8C
	private readonly Int32[] _forceToSitAnimationIndexes; //Field offset: 0x90
	private readonly List<LevelCAConfig> _configs; //Field offset: 0x98

	public LevelCAFoodTableRestaurantSitAreaHandler() { }

	protected void EnsureHand(LevelItem levelItem, ILevelHasHands target, AvatarHandType characterHandType, bool freeHands = true) { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	public virtual SpineType GetSpineType() { }

	public virtual bool IsForceToSitWhenPossible() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	private void OnPutItemInCharacterBone(LevelItem levelItem) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void OrderForkAndKnifeInHands(LevelCharacter character) { }

}

