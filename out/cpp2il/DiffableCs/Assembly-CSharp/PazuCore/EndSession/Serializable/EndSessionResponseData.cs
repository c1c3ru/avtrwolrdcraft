namespace PazuCore.EndSession.Serializable;

public class EndSessionResponseData
{
	public int id; //Field offset: 0x10
	public List<CardsDataItem> cards; //Field offset: 0x18
	public EndSessionBaseData baseData; //Field offset: 0x20
	public long snapshotCardsInterval; //Field offset: 0x28
	public string snapshotTopSectionTitleKey; //Field offset: 0x30
	public string snapshotBottomSectionTitleKey; //Field offset: 0x38

	public EndSessionResponseData() { }

}

