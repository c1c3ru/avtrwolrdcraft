namespace Spine;

public class SkeletonJson : SkeletonLoader
{
	private class LinkedMesh
	{
		internal string parent; //Field offset: 0x10
		internal string skin; //Field offset: 0x18
		internal int slotIndex; //Field offset: 0x20
		internal MeshAttachment mesh; //Field offset: 0x28
		internal bool inheritTimelines; //Field offset: 0x30

		public LinkedMesh(MeshAttachment mesh, string skin, int slotIndex, string parent, bool inheritTimelines) { }

	}

	private readonly List<LinkedMesh> linkedMeshes; //Field offset: 0x20

	public SkeletonJson(AttachmentLoader attachmentLoader) { }

	public SkeletonJson(Atlas[] atlasArray) { }

	private int FindSlotIndex(SkeletonData skeletonData, string slotName) { }

	private static bool GetBoolean(Dictionary<String, Object> map, string name, bool defaultValue) { }

	private static float GetFloat(Dictionary<String, Object> map, string name, float defaultValue) { }

	private static Single[] GetFloatArray(Dictionary<String, Object> map, string name, float scale) { }

	private static int GetInt(Dictionary<String, Object> map, string name) { }

	private static int GetInt(Dictionary<String, Object> map, string name, int defaultValue) { }

	private static Int32[] GetIntArray(Dictionary<String, Object> map, string name) { }

	private static string GetString(Dictionary<String, Object> map, string name, string defaultValue) { }

	private void ReadAnimation(Dictionary<String, Object> map, string name, SkeletonData skeletonData) { }

	private Attachment ReadAttachment(Dictionary<String, Object> map, Skin skin, int slotIndex, string name, SkeletonData skeletonData) { }

	private static int ReadCurve(object curve, CurveTimeline timeline, int bezier, int frame, int value, float time1, float time2, float value1, float value2, float scale) { }

	public static Sequence ReadSequence(object sequenceJson) { }

	public virtual SkeletonData ReadSkeletonData(string path) { }

	public SkeletonData ReadSkeletonData(TextReader reader) { }

	private static Timeline ReadTimeline(ref Enumerator<Object> keyMapEnumerator, CurveTimeline2 timeline, string name1, string name2, float defaultValue, float scale) { }

	private static Timeline ReadTimeline(ref Enumerator<Object> keyMapEnumerator, CurveTimeline1 timeline, float defaultValue, float scale) { }

	private void ReadVertices(Dictionary<String, Object> map, VertexAttachment attachment, int verticesLength) { }

	private static void SetBezier(CurveTimeline timeline, int frame, int value, int bezier, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2) { }

	private static float ToColor(string hexString, int colorIndex, int expectedLength = 8) { }

}

