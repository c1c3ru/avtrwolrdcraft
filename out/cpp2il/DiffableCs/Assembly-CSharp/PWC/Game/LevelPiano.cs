namespace PWC.Game;

public class LevelPiano : MonoBehaviour
{
	[SerializeField]
	private LevelPianoKey[] _pianoKeys; //Field offset: 0x20
	[CompilerGenerated]
	private Action<Int32> OnKeyClickedAction; //Field offset: 0x28

	public event Action<Int32> OnKeyClickedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelPiano() { }

	[CompilerGenerated]
	public void add_OnKeyClickedAction(Action<Int32> value) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnPianoKeyClicked(int index) { }

	public void PlayNote(int index) { }

	[CompilerGenerated]
	public void remove_OnKeyClickedAction(Action<Int32> value) { }

	public void TurnOffAllKeys() { }

}

