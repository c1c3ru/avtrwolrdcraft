namespace PWC.Level;

public class LevelElectricScooterAnimationItemHandler : LevelSkateboardAnimationItemHandler
{
	[SerializeField]
	protected LevelSimpleToggleableSpine _rightWheel; //Field offset: 0x68
	[SerializeField]
	protected LevelSimpleToggleableSpine _leftWheel; //Field offset: 0x70
	[SerializeField]
	protected GameObject _rightWheelGameObject; //Field offset: 0x78
	[SerializeField]
	protected GameObject _leftWheelGameObject; //Field offset: 0x80
	protected int _rightTweenId; //Field offset: 0x88
	protected int _leftTweenId; //Field offset: 0x8C

	public LevelElectricScooterAnimationItemHandler() { }

	protected override void HandleWheels(SkatingMode mode) { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

}

