using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("Prefab/GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    // SFX
    //[Header("SFX Clips")]

    // Musics
    //[Header("Music Clips")]

    // Sprites
    //[Header("Sprites")]

    // If you have any other types of assets to implement, set a header for it (ex: Header("Music Clips")]) !
}