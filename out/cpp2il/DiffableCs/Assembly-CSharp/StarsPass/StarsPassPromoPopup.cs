namespace StarsPass;

public class StarsPassPromoPopup : GamePopup
{
	private const string DID_SHOW_KEY = "StarsPassPromoPopup_DidShow"; //Field offset: 0x0

	public StarsPassPromoPopup() { }

	public virtual void OnButtonPress(bool value) { }

	public static GamePopup Present() { }

	public static void PresentOnce() { }

}

