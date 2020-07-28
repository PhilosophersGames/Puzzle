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
            if (_i == null) _i = (Instantiate(Resources.Load("Prefabs/UI/GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    // SFX
    [Header("SFX Clips")]

    public AudioClip AshkanMouseOverSFX;
    public AudioClip AshkanMouseClickSFX;
    // Musics

    // Sprites
    //[Header("Sprites")]

    // If you have any other types of assets to implement, set a header for it (ex: Header("Music Clips")]) !
}