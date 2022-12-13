using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public static bool isLevel1;
    public static bool isLevel2;
    public void Level1()
    {
        isLevel1 = true;
        isLevel2 = false;
    }
    public void Level2()
    {
        isLevel2 = true;
        isLevel1 = false;
    }
}
