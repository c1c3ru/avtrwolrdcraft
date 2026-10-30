namespace RotaryHeart.Lib.SerializableDictionary;

public class RequiredReferences : ScriptableObject
{
	[SerializeField]
	private GameObject _gameObject; //Field offset: 0x18
	[SerializeField]
	private Material _material; //Field offset: 0x20
	[SerializeField]
	private AudioClip _audioClip; //Field offset: 0x28

	public RequiredReferences() { }

}

