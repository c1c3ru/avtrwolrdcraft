namespace Game.Level;

public class Lighthouse : MonoBehaviour
{
	[SerializeField]
	protected SpriteRenderer _top; //Field offset: 0x20
	[SerializeField]
	protected SpriteMask _mask; //Field offset: 0x28
	[SerializeField]
	private string _turnOnSoundName; //Field offset: 0x30
	[SerializeField]
	private string _turnOffSoundName; //Field offset: 0x38
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x40
	private float _xMin; //Field offset: 0x48
	private float _xMax; //Field offset: 0x4C
	private float _yPosition; //Field offset: 0x50

	public Lighthouse() { }

	[CompilerGenerated]
	private void <MoveLeft>b__11_0() { }

	[CompilerGenerated]
	private void <MoveRight>b__10_0() { }

	private void MoveLeft() { }

	private void MoveRight() { }

	public void TurnOff() { }

	public void TurnOn() { }

}

