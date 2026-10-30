namespace Game.Level;

public class LevelTweenSequencePlayer : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelTweenSequencePlayer <>4__this; //Field offset: 0x10
		public LevelTweenData tweenData; //Field offset: 0x18
		public int index; //Field offset: 0x20

		public <>c__DisplayClass7_0() { }

		internal void <Tween>g__OnCompleteTween|0() { }

	}

	[SerializeField]
	private LevelTweenData[] _tweenSequenceData; //Field offset: 0x20
	private Vector3 _startPosition; //Field offset: 0x28
	private Vector3 _startScale; //Field offset: 0x34
	private Quaternion _startRotation; //Field offset: 0x40
	private int _currentTweenID; //Field offset: 0x50

	public LevelTweenSequencePlayer() { }

	private void Awake() { }

	public void PlayTween() { }

	public void Stop() { }

	private void Tween(int index, LevelTweenData tweenData, bool reset) { }

}

