using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiEvent : MonoBehaviour
{
    public class InvalidateExp
    {
        public static InvalidateExp Instance = new InvalidateExp();
    }

    public class InvalidateLevel
    {
        public static InvalidateLevel Instance = new InvalidateLevel();
    }

    public class InvalidateHp
    {
        public static InvalidateHp Instance = new InvalidateHp();
    }

    public class InvalidateTime
    {
        public static InvalidateTime Instance = new InvalidateTime();
    }
}
