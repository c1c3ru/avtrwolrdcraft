namespace PWC.Level;

public class LevelLabelConditionsUnlockableObjectHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public LevelConsumerAreaBase itemConsumerArea; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <OnItemEndDrop>b__0(LevelConsumerAreaBase x) { }

	}

	[SerializeField]
	private LevelUnlockableObject unlockableObject; //Field offset: 0x20
	[SerializeField]
	private String[] _labels; //Field offset: 0x28
	[SerializeField]
	private bool _allowForgivingTest; //Field offset: 0x30
	[SerializeField]
	private string _soundName; //Field offset: 0x38

	public LevelLabelConditionsUnlockableObjectHandler() { }

	private void Awake() { }

	private bool CheckItemLabel(LevelItem levelItem, int consumerAreaId) { }

	private void OnDestroy() { }

	private void OnItemEndDrop(LevelItem item) { }

	private bool PerformLabelsTest() { }

}

