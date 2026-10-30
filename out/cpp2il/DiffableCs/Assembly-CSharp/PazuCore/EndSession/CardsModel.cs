namespace PazuCore.EndSession;

public class CardsModel
{
	public readonly int id; //Field offset: 0x10
	public readonly CardsModelType cardsModelType; //Field offset: 0x14
	public readonly CardsDataBase data; //Field offset: 0x18
	public readonly long timeOfCreation; //Field offset: 0x20

	public CardsModel(CardsModelType cardsModelType, CardsDataBase data) { }

}

