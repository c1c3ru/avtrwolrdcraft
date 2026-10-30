namespace Game.PersistentData;

public class LevelUGCMeshSkewPD
{
	public string panel1Guid; //Field offset: 0x10
	public string panel2Guid; //Field offset: 0x18
	public float angle; //Field offset: 0x20
	public Vector2 pivot; //Field offset: 0x24
	public Vector2 size; //Field offset: 0x2C
	public Vector2 textureOffset; //Field offset: 0x34
	public Vector2 textureScale; //Field offset: 0x3C
	public bool flipUVX; //Field offset: 0x44
	public bool flipUVY; //Field offset: 0x45
	public bool moveUVWithPositions; //Field offset: 0x46
	public bool preventColliderSync; //Field offset: 0x47
	public MeshSkewType meshSkewType; //Field offset: 0x48

	public LevelUGCMeshSkewPD() { }

}

