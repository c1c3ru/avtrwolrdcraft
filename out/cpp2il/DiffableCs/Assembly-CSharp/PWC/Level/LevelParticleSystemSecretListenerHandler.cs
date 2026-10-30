namespace PWC.Level;

public class LevelParticleSystemSecretListenerHandler : MonoBehaviour, ICanListenForSecrets
{
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x20

	public LevelParticleSystemSecretListenerHandler() { }

	private void Awake() { }

	private void EnsureParticleSystem() { }

	public override void OnSecretSolvedHandler() { }

	public override void OnSecretUnsolvedHandler() { }

}

