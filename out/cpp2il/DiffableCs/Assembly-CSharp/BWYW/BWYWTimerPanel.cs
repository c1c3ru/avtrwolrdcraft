namespace BWYW;

public class BWYWTimerPanel : BWYWSlotBase
{
	[SerializeField]
	private TMP_Text _hoursText; //Field offset: 0x50
	[SerializeField]
	private TMP_Text _minutesText; //Field offset: 0x58

	public BWYWTimerPanel() { }

	public void ForceEndTimer() { }

	public void UpdateClock(int totalSeconds) { }

}

