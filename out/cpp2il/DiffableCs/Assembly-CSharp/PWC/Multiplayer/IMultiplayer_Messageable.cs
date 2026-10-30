namespace PWC.Multiplayer;

public interface IMultiplayer_Messageable : IMultiplayer_NetworkIdentityBase
{

	public void Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

}

