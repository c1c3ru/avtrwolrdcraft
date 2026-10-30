namespace Game.Level;

public class LevelTVSpeaker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public Transform item; //Field offset: 0x10
		public int loopCounter; //Field offset: 0x18
		public LTDescr tween; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass7_0() { }

		internal void <PlayCirclesTweens>b__0() { }

		internal void <PlayCirclesTweens>b__1() { }

	}

	[SerializeField]
	private LevelToggleableSpriteOverTime _toggleableSprite; //Field offset: 0x20
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x28
	[SerializeField]
	private Transform[] _circles; //Field offset: 0x30

	public LevelTVSpeaker() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnToggleSetActive(bool value) { }

	private void ParticleSystemSetActive(bool value) { }

	private void PlayCirclesTweens() { }

	private void StopCirclesTweens() { }

}

