namespace PWC.CarsMaker;

public class CarLayer
{
	public CarCategoryType Category; //Field offset: 0x10
	public string PartSuffix; //Field offset: 0x18
	public string ColorGroup; //Field offset: 0x20
	public int ColorIndex; //Field offset: 0x28
	public bool FallsBackToDefaultArt; //Field offset: 0x2C
	public bool TakesNoColor; //Field offset: 0x2D
	public bool IsOptional; //Field offset: 0x2E
	public List<SpriteRenderer> Renderers; //Field offset: 0x30

	public CarLayer() { }

}

