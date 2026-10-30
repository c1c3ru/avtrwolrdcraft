namespace Game.Level;

public class LevelConfettiCannonItemHandler : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer; //Field offset: 0x20
	[SerializeField]
	private Sprite _firedCannon; //Field offset: 0x28
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x30
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x38
	[SerializeField]
	private LevelCAConfettiCannonItemHandler _caHandler; //Field offset: 0x40
	private bool _wasFired; //Field offset: 0x48

	public LevelConfettiCannonItemHandler() { }

	[CompilerGenerated]
	private void <FireConfettiCannon>b__6_0() { }

	public void FireConfettiCannon() { }

	public void FireConfettiCannonBackwards() { }

}

