namespace Spine.Unity;

[CreateAssetMenu(menuName = "Spine/EventData Reference Asset", order = 100)]
public class EventDataReferenceAsset : ScriptableObject
{
	private const bool QuietSkeletonData = True; //Field offset: 0x0
	[SerializeField]
	protected SkeletonDataAsset skeletonDataAsset; //Field offset: 0x18
	[SerializeField]
	[SpineEvent(null, "skeletonDataAsset", True, False, False)]
	protected string eventName; //Field offset: 0x20
	private EventData eventData; //Field offset: 0x28

	public EventData EventData
	{
		 get { } //Length: 36
	}

	public EventDataReferenceAsset() { }

	public EventData get_EventData() { }

	public void Initialize() { }

	public static EventData op_Implicit(EventDataReferenceAsset asset) { }

}

