namespace Spine.Unity;

public class SpineAttachment : SpineAttributeBase
{
	internal struct Hierarchy
	{
		public string skin; //Field offset: 0x0
		public string slot; //Field offset: 0x8
		public string name; //Field offset: 0x10

		public Hierarchy(string fullPath) { }

	}

	public bool returnAttachmentPath; //Field offset: 0x23
	public bool currentSkinOnly; //Field offset: 0x24
	public bool placeholdersOnly; //Field offset: 0x25
	public string skinField; //Field offset: 0x28
	public string slotField; //Field offset: 0x30

	public SpineAttachment(bool currentSkinOnly = true, bool returnAttachmentPath = false, bool placeholdersOnly = false, string slotField = "", string dataField = "", string skinField = "", bool includeNone = true, bool fallbackToTextField = false) { }

	public static Attachment GetAttachment(string attachmentPath, SkeletonData skeletonData) { }

	public static Attachment GetAttachment(string attachmentPath, SkeletonDataAsset skeletonDataAsset) { }

	public static Hierarchy GetHierarchy(string fullPath) { }

}

