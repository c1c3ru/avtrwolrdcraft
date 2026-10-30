namespace TMPro;

public class TMP_TextInfo
{
	internal static Vector2 k_InfinityVectorPositive; //Field offset: 0x0
	internal static Vector2 k_InfinityVectorNegative; //Field offset: 0x8
	public TMP_Text textComponent; //Field offset: 0x10
	public int characterCount; //Field offset: 0x18
	public int spriteCount; //Field offset: 0x1C
	public int spaceCount; //Field offset: 0x20
	public int wordCount; //Field offset: 0x24
	public int linkCount; //Field offset: 0x28
	public int lineCount; //Field offset: 0x2C
	public int pageCount; //Field offset: 0x30
	public int materialCount; //Field offset: 0x34
	public TMP_CharacterInfo[] characterInfo; //Field offset: 0x38
	public TMP_WordInfo[] wordInfo; //Field offset: 0x40
	public TMP_LinkInfo[] linkInfo; //Field offset: 0x48
	public TMP_LineInfo[] lineInfo; //Field offset: 0x50
	public TMP_PageInfo[] pageInfo; //Field offset: 0x58
	public TMP_MeshInfo[] meshInfo; //Field offset: 0x60
	private TMP_MeshInfo[] m_CachedMeshInfo; //Field offset: 0x68

	private static TMP_TextInfo() { }

	public TMP_TextInfo() { }

	internal TMP_TextInfo(int characterCount) { }

	public TMP_TextInfo(TMP_Text textComponent) { }

	public void Clear() { }

	internal void ClearAllData() { }

	public void ClearAllMeshInfo() { }

	public void ClearLineInfo() { }

	public void ClearMeshInfo(bool updateMesh) { }

	internal void ClearPageInfo() { }

	public void ClearUnusedVertices(MaterialReference[] materials) { }

	public TMP_MeshInfo[] CopyMeshInfoVertexData() { }

	public void ResetVertexLayout(bool isVolumetric) { }

	public static void Resize(ref T[] array, int size) { }

	public static void Resize(ref T[] array, int size, bool isBlockAllocated) { }

}

