namespace Game.Level;

public class LevelItemConditionsResolver : ConditionResolverComponent, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x28
	[SerializeField]
	public UnityEvent onConditionsMet; //Field offset: 0x30
	private ILevelAvatar _avatar; //Field offset: 0x38

	public LevelItemConditionsResolver() { }

	private void Awake() { }

	private void OnBeginLandAction(LevelDropArea area) { }

	public override void OnConditionsCheck() { }

	private void OnDestroy() { }

	public void OnLevelPostInit() { }

	public void OnPlacedOnAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	public void OnRemovedFromAvatar(ILevelAvatar avatar) { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

}

