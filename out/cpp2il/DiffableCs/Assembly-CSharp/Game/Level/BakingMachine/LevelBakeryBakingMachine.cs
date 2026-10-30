namespace Game.Level.BakingMachine;

public class LevelBakeryBakingMachine : LevelBakingMachine
{
	[SerializeField]
	private string _doorOpenSoundName; //Field offset: 0x98
	[SerializeField]
	private string _doorCloseSoundName; //Field offset: 0xA0
	[SerializeField]
	private string _pipeFillSoundName; //Field offset: 0xA8
	[SerializeField]
	private string _pipeEmptySoundName; //Field offset: 0xB0
	private bool _isDoorOpen; //Field offset: 0xB8
	private bool _isFull; //Field offset: 0xB9
	private bool _canOpenDoor; //Field offset: 0xBA
	private Slot liquid; //Field offset: 0xC0

	public LevelBakeryBakingMachine() { }

	[CompilerGenerated]
	private void <FillDropArea>b__11_0(float t) { }

	[CompilerGenerated]
	private void <ProcessCreateOutcome>b__14_0() { }

	private void FillDropArea() { }

	protected virtual void FinishInstantiate(Item item) { }

	private void InitializeButtons() { }

	protected virtual void OnLevelPostInit() { }

	protected virtual void ProcessChooseBase() { }

	protected virtual void ProcessCompleted() { }

	protected virtual void ProcessCreateOutcome() { }

	protected virtual void ProcessIdle() { }

	public virtual void ProcessItem(LevelItem levelItem) { }

	protected virtual void ReturnToProperIdleAnimation() { }

	public void ToggleDoor() { }

}

