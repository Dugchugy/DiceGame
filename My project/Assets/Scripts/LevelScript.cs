using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{

    public int Variation;
    public int Goals;
    public int Rooms1;
    public int Rooms2;
    public int Rooms3;
    public int TotalRooms;
    public GameObject VariantHolder;
    public GameObject GoalHolder;
    public GameObject RoomHolder1;
    public GameObject RoomHolder2;
    public GameObject RoomHolder3;

    // Start is called before the first frame update
    void Start()
    {
        Variation = 0;
        Goals = 0;
        Rooms1 = 0;
        Rooms2 = 0;
        Rooms3 = 0;
        TotalRooms = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buttton()
    {
        VariantHolder = GameObject.FindGameObjectWithTag("Variant");
        GoalHolder = GameObject.FindGameObjectWithTag("Goal");
        RoomHolder1 = GameObject.FindGameObjectWithTag("Room1");
        RoomHolder2 = GameObject.FindGameObjectWithTag("Room2");
        RoomHolder3 = GameObject.FindGameObjectWithTag("Room3");

        Variation = VariantHolder.GetComponent<HolderScript>().heldNum;
        Goals = GoalHolder.GetComponent<HolderScript>().heldNum;
        Rooms1 = RoomHolder1.GetComponent<HolderScript>().heldNum;
        Rooms2 = RoomHolder2.GetComponent<HolderScript>().heldNum;
        Rooms3 = RoomHolder3.GetComponent<HolderScript>().heldNum;

        if(Variation == -1 || Goals == -1 || Rooms1 == -1 || Rooms2 == -1 || Rooms3 == -1)
        {
            Debug.Log("Holders must be filled!");
        }
        else
        {
            TotalRooms = Rooms1 + Rooms2 + Rooms3;
            LoadData.RoomCount = TotalRooms;
            LoadData.GoalCount = Goals;
            LoadData.RoomType = Variation;
            SceneManager.LoadScene(1);
        }
    }
}
