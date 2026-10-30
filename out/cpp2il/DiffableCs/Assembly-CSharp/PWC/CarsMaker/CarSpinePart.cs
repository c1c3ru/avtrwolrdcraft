namespace PWC.CarsMaker;

public class CarSpinePart
{
	public CarCategoryType Category; //Field offset: 0x10
	public string ColorGroup; //Field offset: 0x18
	public SkeletonAnimation Skeleton; //Field offset: 0x20
	public string TextureName; //Field offset: 0x28
	public int ColorIndex; //Field offset: 0x30
	public bool DidEnsureMaterials; //Field offset: 0x34

	public CarSpinePart() { }

}

