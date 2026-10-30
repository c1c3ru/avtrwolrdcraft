namespace Spine.Unity;

[ExecuteAlways]
[HelpURL("http://esotericsoftware.com/spine-unity#BoundingBoxFollowerGraphic")]
public class BoundingBoxFollowerGraphic : MonoBehaviour
{
	internal static bool DebugMessages; //Field offset: 0x0
	public SkeletonGraphic skeletonGraphic; //Field offset: 0x20
	[SpineSlot(null, "skeletonGraphic", True, True, False)]
	public string slotName; //Field offset: 0x28
	public bool isTrigger; //Field offset: 0x30
	public bool usedByEffector; //Field offset: 0x31
	public bool usedByComposite; //Field offset: 0x32
	public bool clearStateOnDisable; //Field offset: 0x33
	private Slot slot; //Field offset: 0x38
	private BoundingBoxAttachment currentAttachment; //Field offset: 0x40
	private string currentAttachmentName; //Field offset: 0x48
	private PolygonCollider2D currentCollider; //Field offset: 0x50
	private bool skinBoneEnabled; //Field offset: 0x58
	public readonly Dictionary<BoundingBoxAttachment, PolygonCollider2D> colliderTable; //Field offset: 0x60
	public readonly Dictionary<BoundingBoxAttachment, String> nameTable; //Field offset: 0x68

	public BoundingBoxAttachment CurrentAttachment
	{
		 get { } //Length: 8
	}

	public string CurrentAttachmentName
	{
		 get { } //Length: 8
	}

	public PolygonCollider2D CurrentCollider
	{
		 get { } //Length: 8
	}

	public bool IsTrigger
	{
		 get { } //Length: 8
	}

	public Slot Slot
	{
		 get { } //Length: 8
	}

	private static BoundingBoxFollowerGraphic() { }

	public BoundingBoxFollowerGraphic() { }

	private void AddCollidersForSkin(Skin skin, int slotIndex, PolygonCollider2D[] previousColliders, float scale, ref int collidersCount) { }

	public void ClearState() { }

	private void DisposeExcessCollidersAfter(int requiredCount) { }

	public BoundingBoxAttachment get_CurrentAttachment() { }

	public string get_CurrentAttachmentName() { }

	public PolygonCollider2D get_CurrentCollider() { }

	public bool get_IsTrigger() { }

	public Slot get_Slot() { }

	private void HandleRebuild(SkeletonGraphic sr) { }

	public void Initialize(bool overwrite = false) { }

	private void LateUpdate() { }

	private void MatchAttachment(Attachment attachment) { }

	private void OnDisable() { }

	private void OnEnable() { }

	private void Start() { }

}

