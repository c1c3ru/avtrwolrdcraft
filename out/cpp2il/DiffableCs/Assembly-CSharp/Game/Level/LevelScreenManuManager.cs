namespace Game.Level;

public class LevelScreenManuManager : MonoBehaviour
{
	internal struct ManuItem
	{
		public Themes theme; //Field offset: 0x0
		public Sprite[] sprites; //Field offset: 0x8
		public PDPrefabReference[] References; //Field offset: 0x10

	}

	internal enum Themes
	{
		Classic = 0,
		Kawaii = 1,
		ScaryBurger = 2,
		CandyBurger = 3,
	}

	[SerializeField]
	private ManuItem[] _manuBGSprites; //Field offset: 0x20
	[SerializeField]
	private SpriteRenderer _manuRenderer; //Field offset: 0x28
	[SerializeField]
	private LevelOrderTable _orderTable; //Field offset: 0x30
	[SerializeField]
	private LevelBurgerMachineCashRegister _cashRegister; //Field offset: 0x38
	public Action<Int32> OnThemeSelectedAction; //Field offset: 0x40
	private int _currentTheme; //Field offset: 0x48
	private bool _canPressButtons; //Field offset: 0x4C

	public bool CanPressButtons
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public LevelScreenManuManager() { }

	[CompilerGenerated]
	private void <OnThemeClick>b__12_0() { }

	public void CreateItem(PDPrefabReference pdReference) { }

	public bool get_CanPressButtons() { }

	public void OnThemeClick(int index) { }

	public void set_CanPressButtons(bool value) { }

	private void SetTheme(int theme) { }

}

