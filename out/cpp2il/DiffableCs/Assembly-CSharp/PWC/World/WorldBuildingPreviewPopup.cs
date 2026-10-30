namespace PWC.World;

public class WorldBuildingPreviewPopup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public Color color; //Field offset: 0x10
		public WorldBuildingPreviewPopup <>4__this; //Field offset: 0x20

		public <>c__DisplayClass11_0() { }

		internal void <Init>b__2(float alpha) { }

	}

	private static WorldBuildingPreviewPopup _instance; //Field offset: 0x0
	[SerializeField]
	private GameObject _content; //Field offset: 0x20
	[SerializeField]
	private RawImage _coverImage; //Field offset: 0x28
	[SerializeField]
	private VideoComponent _videoComponent; //Field offset: 0x30
	[SerializeField]
	private Image _buttonImage; //Field offset: 0x38
	[SerializeField]
	private Sprite _trialCTASprite; //Field offset: 0x40
	[SerializeField]
	private Sprite _noTrialCTASprite; //Field offset: 0x48

	public WorldBuildingPreviewPopup() { }

	[CompilerGenerated]
	private void <Init>b__11_0(bool success) { }

	[CompilerGenerated]
	private void <Init>b__11_1() { }

	[CompilerGenerated]
	private void <Init>b__11_3() { }

	private void Awake() { }

	public void Hide() { }

	private void Init(WorldBuildingType buildingType, ZoneBuildingItem item) { }

	public void OnCTAClick() { }

	private void OnDestroy() { }

	private void OnDisable() { }

	private void OnUserSync(SyncType syncType) { }

	public static void Show(WorldBuildingType buildingType, ZoneBuildingItem item) { }

}

