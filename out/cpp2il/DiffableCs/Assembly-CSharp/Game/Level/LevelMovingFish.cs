namespace Game.Level;

public class LevelMovingFish : MonoBehaviour
{
	[SerializeField]
	private GameObject _fish; //Field offset: 0x20
	[SerializeField]
	private float _timeLoop; //Field offset: 0x28
	[SerializeField]
	private float _heightLoop; //Field offset: 0x2C
	[SerializeField]
	private float _horizontalLoopTime; //Field offset: 0x30
	[SerializeField]
	private float _horizontalLoop; //Field offset: 0x34

	public LevelMovingFish() { }

	[CompilerGenerated]
	private void <FlipFish>b__8_0() { }

	[CompilerGenerated]
	private void <MoveFish>b__7_0() { }

	private void Awake() { }

	private void FlipFish() { }

	private void MoveFish() { }

	private void OnDestroy() { }

}

