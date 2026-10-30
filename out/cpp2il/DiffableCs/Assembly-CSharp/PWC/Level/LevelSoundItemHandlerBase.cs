namespace PWC.Level;

public abstract class LevelSoundItemHandlerBase : MonoBehaviour
{
	[SerializeField]
	protected string _soundName; //Field offset: 0x20

	protected LevelSoundItemHandlerBase() { }

	public override void PlaySound() { }

}

