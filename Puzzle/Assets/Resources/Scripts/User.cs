using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public int wallet;

    void Start()
    {
        LoadUserData();
    }

    public void LoadUserData()
    {
        wallet = PlayerPrefs.GetInt("wallet");
    }

    public void UpdateUserMoney(int coins)
    {
        wallet += coins;
        PlayerPrefs.SetInt("wallet", wallet);
    }
}
