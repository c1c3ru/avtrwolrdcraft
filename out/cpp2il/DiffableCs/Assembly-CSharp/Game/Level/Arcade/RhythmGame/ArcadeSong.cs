namespace Game.Level.Arcade.RhythmGame;

[CreateAssetMenu]
public class ArcadeSong : ScriptableObject
{
	[SerializeField]
	private TextAsset _songFile; //Field offset: 0x18
	public List<Single> Left; //Field offset: 0x20
	public List<Single> Right; //Field offset: 0x28

	public ArcadeSong() { }

	private void EditJson(Dictionary<String, Object> data) { }

}

