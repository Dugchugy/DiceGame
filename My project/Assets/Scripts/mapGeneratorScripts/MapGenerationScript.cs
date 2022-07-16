using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{

    public GameObject[] RoomTemplates = new GameObject[8];

    public Vector3[] DirectionVectors = new Vector3[] {new Vector3(0, 10, 0),
                                                       new Vector3(12, 0, 0),
                                                       new Vector3(0, -10, 0),
                                                       new Vector3(-12, 0, 0)};

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8; i++){
            RoomTemplates[i] = Resources.Load<GameObject>("Room/Room " + i);
        }

        GenerateMap(18, 6);
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
        Rooms[0] = new RoomHolder(6, Vector3.zero);

        //loops for each of the rooms to generate
        for(int i = 1; i <= (rnum + goals); i++){

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
            while(isOccupied(Rooms, CurrentRoom, i, side)){
                //finds a new side if the side is occupied
                side = Random.Range(0, 4);
            }

            Vector3 newPos = Rooms[CurrentRoom].position + DirectionVectors[side];


            if(i <= rnum){
                Rooms[i] = new RoomHolder(Random.Range(0,6), newPos);
            }else{
                Rooms[i] = new RoomHolder(7, newPos);
            }

            Rooms[i].neighbourIndexs[(side + 6) % 4] = CurrentRoom;
            Rooms[CurrentRoom].neighbourIndexs[side] = i;

            for(int j = 0; j < 4; j++){
                Vector3 testPos = newPos + DirectionVectors[j];

                int index = contactIndex(Rooms, i, testPos);

                if(index != -1){

                    Rooms[i].neighbourIndexs[j] = index;
                    Rooms[index].neighbourIndexs[(j + 6) % 4] = i;
                }
            }

        }


        for(int i = 0; i < Rooms.Length; i++){

            LoadRoom(Rooms[i]);
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

    private void LoadRoom(RoomHolder r){
        GameObject rum = Instantiate(RoomTemplates[r.roomType]);
        rum.transform.position = r.position;

        //Debug.Log(r.position);

        rum.transform.parent = transform;
    }

    private bool isOccupied(RoomHolder[] Rooms, int CurrentRoom, int i, int side){
        if(Rooms[CurrentRoom].neighbourIndexs[side] != -1){
            return true;
        }

        return false;

        /*
        Vector3 newPos = Rooms[CurrentRoom].position + DirectionVectors[side];

        for(int j = 0; j < i; j++){
            if(Rooms[j].position == newPos){
                return true;
            }
        }

        return false;
        */
    }

    private int contactIndex(RoomHolder[] Rooms, int i, Vector3 pos){
        for(int j = 0; j < i; j++){
            Debug.Log("loop: " + j);
            Debug.Log(Rooms[j].position + " vs " + pos);

            if(Rooms[j].position == pos){
                return j;
            }
        }

        return -1;
    }
}
