namespace PazuCore;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
	public static BackgroundMusic instance; //Field offset: 0x0
	private AudioSource audioSource; //Field offset: 0x20
	private Name_Audio bgMusics; //Field offset: 0x28

	public BackgroundMusic() { }

	public void AddAudio(Name_Audio audios) { }

	private void Awake() { }

	public void LoadBackgroundMusic(string clipName, float volume = 1, float pitch = 1) { }

	private void LoadBackgroundMusic(Scene scene) { }

	private void OnDestroy() { }

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }

	private void PlayBackgroundMusicIfNeeded(AudioClip audioClip, float volume = 1, float pitch = 1) { }

	public void SetMute(bool mute) { }

}

