using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*

        0 - 5: gameplay rooms
        6: starting room
        7: goal room

    */

    public void GenerateMap(int rnum, int goals){

        //creates an array to hold the rooms to generate
        RoomHolder[] Rooms = new RoomHolder[1 + rnum + goals];

        //generates the starting room as room 0
        Rooms[0] = new RoomHolder(6);

        //loops for each of the rooms to generate
        for(int i = 1; i <= rnum; i++){

            //picks a room to build the new room off of
            int CurrentRoom = Random.Range(0, i);

            //checks if the room is invalid
            while(checkDoors(Rooms[CurrentRoom])){
                //finds a new room if the room is invalid
                CurrentRoom = Random.Range(0, i);
            }

            //finds what side of the room to connect the new room to
            int side = Random.Range(0, 4);

            //checks if the side is unoccupied
            while(Rooms[CurrentRoom].neighbourIndexs[side] != -1){
                //finds a new side if the side is occupied
                side = Random.Range(0, 4);
            }

            Rooms[i] = new RoomHolder(Random.Range(0,6));

            Rooms[i].neighbourIndexs[(side - 2) % 4] = CurrentRoom;
            Rooms[CurrentRoom].neighbourIndexs[side] = side;

        }
    }

    private bool checkDoors(RoomHolder r){
        for(int i = 0; i < 4; i++){
            if(r.neighbourIndexs[i] == -1){
                return false;
            }
        }

        return true;
    }
}
