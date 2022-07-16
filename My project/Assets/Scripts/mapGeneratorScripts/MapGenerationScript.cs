using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MapGenerationScript : MonoBehaviour
{

    private GameObject[] RoomTemplates = new GameObject[9];

    public Vector3[] DirectionVectors = new Vector3[] {new Vector3(0, 10, 0),
                                                       new Vector3(12, 0, 0),
                                                       new Vector3(0, -10, 0),
                                                       new Vector3(-12, 0, 0)};

    public float TimePassed = 0;
    public float MaxTime = 60;

    private TMP_Text text;

    public int goalFound = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 9; i++){
            RoomTemplates[i] = Resources.Load<GameObject>("Room/Room " + i);
        }

        GenerateMap(LoadData.RoomCount, LoadData.GoalCount);

        text = GameObject.Find("TimeRemaining").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;

        if(TimePassed > MaxTime){
            if(goalFound >= LoadData.GoalCount){
                SceneManager.LoadScene(0);
            }else{
                SceneManager.LoadScene(2);
            }
        }

        text.SetText((MaxTime - TimePassed).ToString("n2") + "s");

        if(TimePassed > (MaxTime / 4) * 3){
            text.color = new Color(0.8f, 0, 0, 1);
        }
    }

    /*

        0 - 5: gameplay rooms
        6: starting room
        7: goal room

    */

    public void GenerateMap(int rnum, int goals){

        //creates an array to hold the rooms to generate
        List<RoomHolder> Rooms = new List<RoomHolder>();

        //generates the starting room as room 0
        Rooms.Add(new RoomHolder(6, Vector3.zero));

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

            //finds the position of the new room
            Vector3 newPos = Rooms[CurrentRoom].position + DirectionVectors[side];

            //checks if it needs to generate a regular room or a goal room
            if(i <= rnum){
                //generates random regular room
                Rooms.Add(new RoomHolder(Random.Range(0,6), newPos));
            }else{
                //generates goal room
                Rooms.Add(new RoomHolder(7, newPos));
            }

            //pairs the room the neighbour that created it
            Rooms[i].neighbourIndexs[(side + 6) % 4] = CurrentRoom;
            Rooms[CurrentRoom].neighbourIndexs[side] = i;

            //loops for each side of the room
            for(int j = 0; j < 4; j++){
                //the position to test for an exsisting room
                Vector3 testPos = newPos + DirectionVectors[j];

                //attempts to find a room at the test position
                int index = contactIndex(Rooms, i, testPos);

                //checks if a room was found
                if(index != -1){

                    //pairs the current room with its found neighbour
                    Rooms[i].neighbourIndexs[j] = index;
                    Rooms[index].neighbourIndexs[(j + 6) % 4] = i;
                }
            }

        }

        for(int doub = 0; doub < 2; doub++){

            //counts the number of rooms to generate
            int roomC = Rooms.Count;

            for(int i = 0; i < roomC; i++){
                for(int j = 0; j < 4; j++){
                    if(Rooms[i].neighbourIndexs[j] == -1){

                        Vector3 newPos = Rooms[i].position + DirectionVectors[j];

                        Rooms.Add(new RoomHolder(8, newPos));

                        //loops for each side of the room
                        for(int k = 0; k < 4; k++){
                            //the position to test for an exsisting room
                            Vector3 testPos = newPos + DirectionVectors[k];

                            //attempts to find a room at the test position
                            int index = contactIndex(Rooms, Rooms.Count, testPos);

                            //checks if a room was found
                            if(index != -1){

                                //pairs the current room with its found neighbour
                                Rooms[Rooms.Count - 1].neighbourIndexs[k] = index;
                                Rooms[index].neighbourIndexs[(k + 6) % 4] = (Rooms.Count - 1);
                            }
                        }

                    }
                }
            }

        }

        //counts the number of rooms to generate
        int roomLen = Rooms.Count;

        //loops for each room
        for(int i = 0; i < roomLen; i++){

            //loads the gameObject for each room
            LoadRoom(Rooms[i]);
        }
    }

    //checks if this room has a space neighbouring it
    private bool checkDoors(RoomHolder r){
        //loops for each side
        for(int i = 0; i < 4; i++){
            //if the room has free space returns false
            if(r.neighbourIndexs[i] == -1){
                return false;
            }
        }

        //returns true, this room has no space for neighbours
        return true;
    }

    private void LoadRoom(RoomHolder r){
        //copys the room template to a new gameobject
        GameObject rum = Instantiate(RoomTemplates[r.roomType]);
        //places the room at the desired position
        rum.transform.position = r.position;

        //sets the room to be a child of the MapOrigin object
        rum.transform.parent = transform;
    }

    private bool isOccupied(List<RoomHolder> Rooms, int CurrentRoom, int i, int side){
        //checsk if the current neighbour is occupied
        if(Rooms[CurrentRoom].neighbourIndexs[side] != -1){
            return true;
        }

        return false;
    }

    private int contactIndex(List<RoomHolder> Rooms, int i, Vector3 pos){
        //loops for each room generated so far
        for(int j = 0; j < i; j++){

            //checks if the current room occupies the specified position
            if(Rooms[j].position == pos){
                //returns the index of that room
                return j;
            }
        }

        //returns -1 to show no rooms were found
        return -1;
    }
}
