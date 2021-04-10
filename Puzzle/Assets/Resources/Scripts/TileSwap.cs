using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwap : MonoBehaviour
{
    public TileBase[] skinZero;
    public TileBase[] skinOne;

    private GameObject[] rooms;
    public int skinID;

    public void SkinChanger(int newSkin)
    {
        if (skinID != newSkin)
        {
            rooms = GameObject.FindGameObjectsWithTag("RoomSkin");
            foreach (GameObject room in rooms)
            {
                // SKIN 0
                if (skinID == 0)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                    {
                        room.GetComponent<RoomColorChanger>().path.SwapTile(skinZero[0], SwappedSkin(0, newSkin));
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinZero[1], SwappedSkin(1, newSkin));
                    }
                    else if (room.GetComponent<RoomColorChanger>().roomID == 1)
                    {
                        room.GetComponent<RoomColorChanger>().path.SwapTile(skinZero[2], SwappedSkin(2, newSkin));
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinZero[3], SwappedSkin(3, newSkin));
                    }

                }
                // SKIN 1
                else if (skinID == 1)
                {
                    if (room.GetComponent<RoomColorChanger>().roomID == 0)
                    {
                        room.GetComponent<RoomColorChanger>().path.SwapTile(skinOne[0], SwappedSkin(0, newSkin));
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinOne[1], SwappedSkin(1, newSkin));
                    }
                    else if (room.GetComponent<RoomColorChanger>().roomID == 1)
                    {
                        room.GetComponent<RoomColorChanger>().path.SwapTile(skinOne[2], SwappedSkin(2, newSkin));
                        room.GetComponent<RoomColorChanger>().colider.SwapTile(skinOne[3], SwappedSkin(3, newSkin));
                    }
                }
            }
        }
        skinID = newSkin;
    }

    TileBase SwappedSkin(int i, int newSkin)
    {
        if (newSkin == 0)
            return (skinZero[i]);
        if (newSkin == 1)
            return (skinOne[i]);
        return (null);
    }
}