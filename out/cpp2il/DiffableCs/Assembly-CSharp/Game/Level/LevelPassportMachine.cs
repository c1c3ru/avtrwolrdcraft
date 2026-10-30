namespace Game.Level;

public class LevelPassportMachine : LevelConsumerAreaBase
{
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	[SerializeField]
	public UnityEvent OnEnterAction; //Field offset: 0x60
	private bool _isInProgress; //Field offset: 0x68
	private float _duration; //Field offset: 0x6C

	public LevelPassportMachine() { }

	[CompilerGenerated]
	private void <PrintBoardingPass>b__4_0() { }

	public void PrintBoardingPass() { }

}

