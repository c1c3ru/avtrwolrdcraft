namespace Game.Level;

public class LevelMidiControllerSpeaker : LevelStationaryItem
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public Transform item; //Field offset: 0x10
		public int loopCounter; //Field offset: 0x18
		public LTDescr tween; //Field offset: 0x20
		public Action <>9__1; //Field offset: 0x28

		public <>c__DisplayClass10_0() { }

		internal void <PlayCirclesTweens>b__0() { }

		internal void <PlayCirclesTweens>b__1() { }

	}

	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x60
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0x68
	[SerializeField]
	private Sprite _onSprite; //Field offset: 0x70
	[SerializeField]
	private Sprite _offSprite; //Field offset: 0x78
	[SerializeField]
	private float _volume; //Field offset: 0x80
	[SerializeField]
	private Transform[] _circles; //Field offset: 0x88
	private bool _isOn; //Field offset: 0x90

	public LevelMidiControllerSpeaker() { }

	private void PlayCirclesTweens() { }

	public void PlaySound(string clipName) { }

	public void SetDistortionActive(bool active) { }

	private void SetState(bool isOn) { }

	private void StopCirclesTweens() { }

	public void StopSound() { }

}

