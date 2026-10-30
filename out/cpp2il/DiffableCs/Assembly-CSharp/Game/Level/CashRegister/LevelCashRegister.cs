namespace Game.Level.CashRegister;

public class LevelCashRegister : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public LevelCashRegister <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <OnItemEndDrop>b__0() { }

	}

	[SerializeField]
	protected LevelCashRegisterMonitor _monitor; //Field offset: 0x20
	[SerializeField]
	protected LevelDropArea _dropArea; //Field offset: 0x28
	[SerializeField]
	protected LevelDropArea _characterDropArea; //Field offset: 0x30

	public LevelCashRegister() { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem levelItem) { }

	private bool TryGetCachier(out LevelCashRegisterCharacterHandler characterHandler) { }

}

