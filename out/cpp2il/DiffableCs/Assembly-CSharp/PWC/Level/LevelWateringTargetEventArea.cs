namespace PWC.Level;

public class LevelWateringTargetEventArea : LevelConsumerAreaBase, ILevelPlantWateringTarget, ILevelConsumer, ILevelPlant
{
	[SerializeField]
	private UnityEvent onWatered; //Field offset: 0x58
	[Min(1)]
	[SerializeField]
	private int _wateringTicksToGrow; //Field offset: 0x60
	private int _wateringTicks; //Field offset: 0x64
	private bool _didGrow; //Field offset: 0x68

	public LevelWateringTargetEventArea() { }

	public override bool DidGrowComplete() { }

	public override ILevelPlant GetPlant() { }

	public override bool IsAlive() { }

	public override float PlayIncrementSound() { }

	public override void SetPlantPot(LevelPlantPot plantPot) { }

	public override bool TryIncrementPlant() { }

}

