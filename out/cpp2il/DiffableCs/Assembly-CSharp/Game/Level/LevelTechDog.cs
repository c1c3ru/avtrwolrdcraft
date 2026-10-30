namespace Game.Level;

public class LevelTechDog : LevelAnimal
{
	[SerializeField]
	private LevelCATechDogHandler _cAHandler; //Field offset: 0x400
	private bool _isTurnedOn; //Field offset: 0x408
	private String[] _overrideIdleAnimations; //Field offset: 0x410
	[CompilerGenerated]
	private Action OnTurnOnAction; //Field offset: 0x418

	public event Action OnTurnOnAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public bool IsTurnedOn
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelTechDog() { }

	[CompilerGenerated]
	public void add_OnTurnOnAction(Action value) { }

	protected virtual bool CanEat() { }

	public bool get_IsTurnedOn() { }

	protected virtual String[] GetIdleAnimations() { }

	public virtual Dictionary<String, Object> GetPersistentData() { }

	protected virtual string GetPickUpLoopAnimationName() { }

	protected virtual string GetSittingDownAnimationName() { }

	protected virtual string GetSittingIdleAnimationName() { }

	protected virtual string GetStandingIdleAnimationName() { }

	public virtual bool HasSwimmingAnimations() { }

	protected virtual bool HasWalkingAnimations() { }

	public virtual void OnBeginDrag(PointerEventData eventData) { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	[CompilerGenerated]
	public void remove_OnTurnOnAction(Action value) { }

	public void set_IsTurnedOn(bool value) { }

	public virtual void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void TurnOn() { }

}

