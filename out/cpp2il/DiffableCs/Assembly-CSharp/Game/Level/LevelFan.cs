namespace Game.Level;

public class LevelFan : LevelStationaryItem, IPointerClickHandler, IEventSystemHandler, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private SkeletonAnimation _skeletonAnimation; //Field offset: 0x60
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0x68
	private FanAnimationType _fanAnimationType; //Field offset: 0x70
	private int _delayedCallTweenID; //Field offset: 0x74

	public LevelFan() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__4_0() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__4_1(TrackEntry x) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

