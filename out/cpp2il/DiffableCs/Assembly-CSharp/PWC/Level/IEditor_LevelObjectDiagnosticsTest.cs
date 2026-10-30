namespace PWC.Level;

public interface IEditor_LevelObjectDiagnosticsTest : IEditor_LevelPDPrefabDiagnosticsTest, IEditor_LevelSceneElementDiagnosticsTest
{

	public void Editor_PerformDiagnosticsTest(bool isInScene) { }

	private void PWC.Level.IEditor_LevelPDPrefabDiagnosticsTest.Editor_PerformDiagnosticsTest() { }

	private void PWC.Level.IEditor_LevelSceneElementDiagnosticsTest.Editor_PerformDiagnosticsTest() { }

}

