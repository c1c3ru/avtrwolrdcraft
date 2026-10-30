namespace PWC.CarsMaker;

public class CarMakerDoorOpener : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public CarMakerDoorOpener <>4__this; //Field offset: 0x10
		public int categoryType; //Field offset: 0x18

		public <>c__DisplayClass5_0() { }

		internal void <OnCategoryButtonClick>b__0() { }

	}

	[SerializeField]
	private CarCategoryType _openOnCategory; //Field offset: 0x20
	[SerializeField]
	private List<Int32> _doorIndexes; //Field offset: 0x28
	[SerializeField]
	private List<String> _excludedBreeds; //Field offset: 0x30

	public CarMakerDoorOpener() { }

	private void Awake() { }

	private bool IsExcludedBreed(string breed) { }

	private bool IsWantedDoor(int doorIndex) { }

	private void OnCategoryButtonClick(int categoryType) { }

	private void OnDestroy() { }

	private void SetOpen(bool isOpen) { }

}

