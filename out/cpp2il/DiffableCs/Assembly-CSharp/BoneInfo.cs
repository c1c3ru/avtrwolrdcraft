//Type is in global namespace

public class BoneInfo
{
	public string boneName; //Field offset: 0x10
	public float bonePosX; //Field offset: 0x18
	public float bonePosY; //Field offset: 0x1C
	public float boneScaleX; //Field offset: 0x20
	public float boneScaleY; //Field offset: 0x24
	public float boneRotation; //Field offset: 0x28

	public BoneInfo() { }

	public void PrintBoneInfo() { }

	public void SetInfo(string name, float posX, float posY, float scaleX, float scaleY, float rotation) { }

}

