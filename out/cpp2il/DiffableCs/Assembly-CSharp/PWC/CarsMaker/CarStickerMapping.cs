namespace PWC.CarsMaker;

public class CarStickerMapping
{
	public SpriteRenderer Target; //Field offset: 0x10
	public SpriteRenderer MapFrom; //Field offset: 0x18
	[FormerlySerializedAs("Offset")]
	[Range(-0.5, 0.5)]
	public float OffsetAcross; //Field offset: 0x20
	[Range(-0.5, 0.5)]
	public float OffsetUp; //Field offset: 0x24
	[Range(-1, 1)]
	public float Skew; //Field offset: 0x28

	public CarStickerMapping() { }

}

