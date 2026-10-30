namespace Spine;

public class Skin
{
	internal struct SkinEntry
	{
		internal readonly int slotIndex; //Field offset: 0x0
		internal readonly string name; //Field offset: 0x8
		internal readonly Attachment attachment; //Field offset: 0x10

		public Attachment Attachment
		{
			 get { } //Length: 8
		}

		public string Name
		{
			 get { } //Length: 8
		}

		public int SlotIndex
		{
			 get { } //Length: 8
		}

		public SkinEntry(int slotIndex, string name, Attachment attachment) { }

		public Attachment get_Attachment() { }

		public string get_Name() { }

		public int get_SlotIndex() { }

	}

	private struct SkinKey
	{
		internal readonly int slotIndex; //Field offset: 0x0
		internal readonly string name; //Field offset: 0x8
		internal readonly int hashCode; //Field offset: 0x10

		public SkinKey(int slotIndex, string name) { }

	}

	private class SkinKeyComparer : IEqualityComparer<SkinKey>
	{
		internal static readonly SkinKeyComparer Instance; //Field offset: 0x0

		private static SkinKeyComparer() { }

		public SkinKeyComparer() { }

		private override bool System.Collections.Generic.IEqualityComparer<Spine.Skin.SkinKey>.Equals(SkinKey e1, SkinKey e2) { }

		private override int System.Collections.Generic.IEqualityComparer<Spine.Skin.SkinKey>.GetHashCode(SkinKey e) { }

	}

	internal string name; //Field offset: 0x10
	private Dictionary<SkinKey, SkinEntry> attachments; //Field offset: 0x18
	internal readonly ExposedList<BoneData> bones; //Field offset: 0x20
	internal readonly ExposedList<ConstraintData> constraints; //Field offset: 0x28

	public ICollection<SkinEntry> Attachments
	{
		 get { } //Length: 80
	}

	public ExposedList<BoneData> Bones
	{
		 get { } //Length: 8
	}

	public ExposedList<ConstraintData> Constraints
	{
		 get { } //Length: 8
	}

	public string Name
	{
		 get { } //Length: 8
	}

	public Skin(string name) { }

	public void AddSkin(Skin skin) { }

	internal void AttachAll(Skeleton skeleton, Skin oldSkin) { }

	public void Clear() { }

	public void CopySkin(Skin skin) { }

	public ICollection<SkinEntry> get_Attachments() { }

	public ExposedList<BoneData> get_Bones() { }

	public ExposedList<ConstraintData> get_Constraints() { }

	public string get_Name() { }

	public Attachment GetAttachment(int slotIndex, string name) { }

	public void GetAttachments(int slotIndex, List<SkinEntry> attachments) { }

	public void RemoveAttachment(int slotIndex, string name) { }

	public void SetAttachment(int slotIndex, string name, Attachment attachment) { }

	public virtual string ToString() { }

}

