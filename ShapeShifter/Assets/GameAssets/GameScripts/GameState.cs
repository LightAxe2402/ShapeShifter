﻿using UnityEngine;

public static class GameState
{
    public static bool gamePaused = false;
    public static bool tutorialInProgress = false;

    [Header("Progression Variables")]
    public static bool forcedTutorialCompleted = false;
}
