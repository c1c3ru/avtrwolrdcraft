namespace AvatarWorld.Core.Persistence
{
    /// <summary>Por que o original grava o progresso (PWC.PersistentData.PersistentDataManager).</summary>
    public enum SaveTrigger
    {
        /// <summary>OnBeforeSceneLoadStage2 -> SaveProgressInAllScenes, durante LoadScene; nao consulta CanSaveScene.</summary>
        SceneChange = 0,
        /// <summary>OnApplicationPause(true) -> CanSaveScene() -> SaveProgressInAllScenes.</summary>
        ApplicationPause = 1,
    }

    /// <summary>
    /// Regra de gravacao recuperada do original (docs/loops/results/L03.md; tools/recon_save_triggers.py).
    /// CanSaveScene (0x21e5f74) = !GameSceneManager.IsSceneChangingInProgress
    ///                           &amp;&amp; (LevelManager.Instance == null || LevelManager.Instance.IsPostInit).
    /// Gravar na troca de cena ignora essa regra: LoadScene liga IsSceneChangingInProgress antes de disparar Stage2.
    /// Nao ha gravacao em OnApplicationQuit/OnApplicationFocus (o manager nao tem esses metodos).
    /// </summary>
    public static class SaveGate
    {
        public static bool CanSaveScene(bool isSceneChangingInProgress, bool levelManagerExists, bool levelManagerIsPostInit)
        {
            if (isSceneChangingInProgress) return false;
            return !levelManagerExists || levelManagerIsPostInit;
        }

        /// <param name="applicationPausing">Argumento de OnApplicationPause; despausar nunca grava.</param>
        public static bool ShouldSave(SaveTrigger trigger, bool applicationPausing,
                                      bool isSceneChangingInProgress, bool levelManagerExists, bool levelManagerIsPostInit)
        {
            if (trigger == SaveTrigger.SceneChange) return true;
            return applicationPausing && CanSaveScene(isSceneChangingInProgress, levelManagerExists, levelManagerIsPostInit);
        }
    }
}
