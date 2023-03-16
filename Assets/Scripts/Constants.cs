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
    public const float MOVE_DURATION = 3f;
    public const float MAX_MOVE = 10f;
    public const float DISABLE_ENABLE_GRAVITY_INTERVAL = 5f;
    public const float MIN_DISTANCE = 0.1f;
    public const int MAIN_MENU_BUILD_INDEX = 0;
    public const float COLOR_ANIMATE_INTERVAL = 2f;
    public const float TIME_DISABLED_SCALE = 0.000001f;
    public const float TIME_ENABLED_SCALE = 1f;
    public const string UNLOCKED_LEVEL = "UnlockedLevel";
    public const string FIRE = "Fire";
}