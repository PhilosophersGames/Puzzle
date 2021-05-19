using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRooms : MonoBehaviour
{

    private GameObject player;

    private GameObject skinManager;

    private Vector3 savePosition;

    public float speed;

    private GameObject actualRooms;

    public GameObject[] columnZero;

    public GameObject[] columnOne;

    public GameObject[] columnTwo;

    public GameObject[] columnThree;

    public GameObject[] columnFour;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        skinManager = GameObject.FindGameObjectWithTag("SkinManager");
        actualRooms = player;
    }

    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if ((columnZero[i] && savePosition == columnZero[i].transform.position) || (columnOne[i] && savePosition == columnOne[i].transform.position) || (columnTwo[i] && savePosition == columnTwo[i].transform.position) || (columnThree[i] && savePosition == columnThree[i].transform.position) || (columnFour[i] && savePosition == columnFour[i].transform.position))
                GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().StartChangeBool();
            // ======================================================================================================== COLUMN ZERO ========================================================================================================
            if (columnZero[i] && IsPlayerHere(player, columnZero[i]) && actualRooms != columnZero[i])
            {
                if (columnZero[i - 1] && !columnZero[i - 1].active)
                {
                    GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().thereIsColliders = false;
                    GameObject.FindGameObjectWithTag("RoomsContainer").GetComponent<SlideManager>().drawBorderCollider = true;
                    columnZero[i - 1].SetActive(true);
                    savePosition = columnZero[i - 1].transform.position;
                    columnZero[i - 1].transform.position = new Vector3(columnZero[i - 1].transform.position.x, columnZero[i - 1].transform.position.y + 2, 0);                 
                    Vector3.MoveTowards(columnZero[i - 1].transform.position, savePosition, Time.deltaTime * speed);
                }
                if (columnZero[i + 1] && !columnZero[i + 1].active)
                {
                    columnZero[i + 1].SetActive(true);
                    savePosition = columnZero[i + 1].transform.position;
                    columnZero[i + 1].transform.position = new Vector3(columnZero[i + 1].transform.position.x, columnZero[i + 1].transform.position.y - 2, 0);
                    Vector3.MoveTowards(columnZero[i + 1].transform.position, savePosition, Time.deltaTime * speed);
                }
                if (columnOne[i] && !columnOne[i].active)
                    columnOne[i].SetActive(true);
                actualRooms = columnZero[i];
                skinManager.GetComponent<TileSwap>().GenerateSkinAndColliders();
            }
            // ======================================================================================================== COLUMN ONE ========================================================================================================
            else if (columnOne[i] && IsPlayerHere(player, columnOne[i]) && actualRooms != columnOne[i])
            {
                if (columnOne[i - 1] && !columnOne[i - 1].active)
                    columnOne[i - 1].SetActive(true);
                if (columnOne[i + 1] && !columnOne[i + 1].active)
                    columnOne[i + 1].SetActive(true);
                if (columnZero[i] && !columnZero[i].active)
                    columnOne[i].SetActive(true);
                if (columnTwo[i] && !columnTwo[i].active)
                    columnTwo[i].SetActive(true);
                actualRooms = columnOne[i];
                skinManager.GetComponent<TileSwap>().GenerateSkinAndColliders();
            }
            // ======================================================================================================== COLUMN TWO ========================================================================================================
            else if (columnTwo[i] && IsPlayerHere(player, columnTwo[i]) && actualRooms != columnTwo[i])
            {
                if (columnTwo[i - 1] && !columnTwo[i - 1].active)
                    columnTwo[i - 1].SetActive(true);
                if (columnTwo[i + 1] && !columnTwo[i + 1].active)
                    columnTwo[i + 1].SetActive(true);
                if (columnOne[i] && !columnOne[i].active)
                    columnOne[i].SetActive(true);
                if (columnThree[i] && !columnThree[i].active)
                    columnTwo[i].SetActive(true);
                actualRooms = columnTwo[i];
                skinManager.GetComponent<TileSwap>().GenerateSkinAndColliders();
            }
            // ======================================================================================================== COLUMN THREE ========================================================================================================
            else if (columnThree[i] && IsPlayerHere(player, columnThree[i]) && actualRooms != columnThree[i])
            {
                if (columnThree[i - 1] && !columnThree[i - 1].active)
                    columnThree[i - 1].SetActive(true);
                if (columnThree[i + 1] && !columnThree[i + 1].active)
                    columnThree[i + 1].SetActive(true);
                if (columnTwo[i] && !columnTwo[i].active)
                    columnTwo[i].SetActive(true);
                if (columnFour[i] && !columnFour[i].active)
                    columnFour[i].SetActive(true);
                actualRooms = columnThree[i];
                skinManager.GetComponent<TileSwap>().GenerateSkinAndColliders();
            }
            // ======================================================================================================== COLUMN FOUR ========================================================================================================
            else if (columnFour[i] && IsPlayerHere(player, columnFour[i]) && actualRooms != columnFour[i])
            {
                if (columnFour[i - 1] && !columnFour[i - 1].active)
                    columnFour[i - 1].SetActive(true);
                if (columnFour[i + 1] && !columnFour[i + 1].active)
                    columnFour[i + 1].SetActive(true);
                if (columnThree[i] && !columnThree[i].active)
                    columnThree[i].SetActive(true);
                actualRooms = columnFour[i];
                skinManager.GetComponent<TileSwap>().GenerateSkinAndColliders();
            }
        }
    }

    public bool IsPlayerHere(GameObject player, GameObject room)
    {
        if (player.transform.parent.transform.parent.transform.parent.gameObject == room)
            return (true);
        else
            return (false);
    }
}