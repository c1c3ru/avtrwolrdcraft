namespace Game.Level;

public class LevelLightAutoTurnOffHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public LevelLightAutoTurnOffHandler <>4__this; //Field offset: 0x10
		public bool isEnabled; //Field offset: 0x18

		public <>c__DisplayClass4_0() { }

		internal void <OnLampClickHandler>b__0() { }

	}

	[SerializeField]
	private float _timer; //Field offset: 0x20
	private LevelLight _levelLight; //Field offset: 0x28

	public LevelLightAutoTurnOffHandler() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnLampClickHandler(bool isOn) { }

}

