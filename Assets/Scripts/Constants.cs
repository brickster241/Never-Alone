using System;
using System.Collections;
using System.Collections.Generic;



public enum AudioType {
    GAME_BACKGROUND,
    PLAYER_DASH,
    LEVEL_COMPLETE,
    LEVEL_OVER,
    BUTTON_CLICK
}


public class Constants {
    public const float MOVE_DURATION = 1000f;
    public const float MIN_DISTANCE = 0.1f;
    public const int MAIN_MENU_BUILD_INDEX = 0;
    public const string UNLOCKED_LEVEL = "UnlockedLevel";
    public const string FIRE = "Fire";
}