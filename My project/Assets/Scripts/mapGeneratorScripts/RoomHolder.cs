using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHolder
{
    public int roomType;
    public int[] neighbourIndexs = new int[] {-1, -1, -1, -1};

    public Vector3 position =new Vector3(0, 0, 0);

    public RoomHolder(int type){//, int[] pos){
        roomType = type;
        //position = pos;
    }
}
