namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelContainerItemWithParticlesAndLiquid : LevelContainerItemWithParticles
{
	[SerializeField]
	private GameObject _liquid; //Field offset: 0x370

	public LevelContainerItemWithParticlesAndLiquid() { }

	protected virtual void OnAnimate(bool value) { }

}

