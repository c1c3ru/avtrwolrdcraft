//Type is in global namespace

public class levelElectricScooterWithSitAnimationItemHandler : LevelElectricScooterAnimationItemHandler
{
	[SerializeField]
	private string _regularIdleAnimationName; //Field offset: 0x90
	[SerializeField]
	private string _sittingIdleAnimationName; //Field offset: 0x98

	public levelElectricScooterWithSitAnimationItemHandler() { }

	public virtual void PlaySuitableIdle(SkatingMode mode, bool isAdd = false) { }

}

