using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : GenericSingleton<GameConfig>
{
    public float playerSpeedZ;
    public float playerSpeedX;
    public float clampX;
}
