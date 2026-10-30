namespace PWC.Multiplayer;

public class MPChangeSceneCollectedData
{
	public MPSceneData sceneData; //Field offset: 0x10
	public float creationTime; //Field offset: 0x18
	public bool shouldSendNowEvenIfHasNoData; //Field offset: 0x1C
	public MPData_SceneChangeRequest request; //Field offset: 0x20

	public string RequestGuid
	{
		 get { } //Length: 24
	}

	public string SceneName
	{
		 get { } //Length: 24
	}

	public int TargetPlayerUID
	{
		 get { } //Length: 24
	}

	public MPChangeSceneCollectedData() { }

	public string get_RequestGuid() { }

	public string get_SceneName() { }

	public int get_TargetPlayerUID() { }

}

