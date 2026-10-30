namespace Spine;

public abstract class SkeletonLoader
{
	protected readonly AttachmentLoader attachmentLoader; //Field offset: 0x10
	protected float scale; //Field offset: 0x18

	public float Scale
	{
		 get { } //Length: 8
		 set { } //Length: 128
	}

	public SkeletonLoader(Atlas[] atlasArray) { }

	public SkeletonLoader(AttachmentLoader attachmentLoader) { }

	public float get_Scale() { }

	public abstract SkeletonData ReadSkeletonData(string path) { }

	public void set_Scale(float value) { }

}

