public static class DecideEnding {

    public static void DecideScenePlayEnding()
    {
        string endingSceneName;
        if (Parameters.CleanEnergyUsed > Parameters.UnClearEnergyUsed * 1.5) endingSceneName = "VeryCleanEnd";
        else if (Parameters.CleanEnergyUsed > Parameters.UnClearEnergyUsed) endingSceneName = "DecentCleanEnd";
        else if (Parameters.CleanEnergyUsed * 1.2 > Parameters.UnClearEnergyUsed) endingSceneName = "DecentDirtyEnd";
        else if (Parameters.CleanEnergyUsed * 1.2 < Parameters.UnClearEnergyUsed) endingSceneName = "DirtyEnd";
        else endingSceneName = "DecentEnd";
        SceneChanger.ChangeScene(endingSceneName);
    }
}
