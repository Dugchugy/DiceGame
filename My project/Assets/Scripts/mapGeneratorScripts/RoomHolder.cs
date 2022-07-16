using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHolder
{
    //stores what type of room this is
    public int roomType;
    //stores the indexes of this rooms neighbours
    public int[] neighbourIndexs = new int[] {-1, -1, -1, -1};

    //stores this rooms position
    public Vector3 position = new Vector3(0, 0, 0);

    //creates a new room
    public RoomHolder(int type, Vector3 pos){
        //sets the type and position of the room (room initialize with no neighbours)
        roomType = type;
        position = pos;
    }
}
