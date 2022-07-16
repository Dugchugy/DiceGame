using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour
{
    private ContactFilter2D Filter = new ContactFilter2D();
    public Collider2D HolderCollider;
    private GameObject[] Die;
    public bool Snapped = false;
    public int HolderNum = -1;

    // Start is called before the first frame update
    void Start()
    {
        Die = GameObject.FindGameObjectsWithTag("Dice");
        Filter.NoFilter();
        HolderCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Die.Length; i++)
        {
            Vector2 CP = HolderCollider.ClosestPoint(Die[i].transform.position);
            if(Die[i].GetComponent<Collider2D>().OverlapPoint(CP) && Snapped == false)
            {
                Die[i].transform.position = transform.position;
                Snapped = true;
            }
            if(!Die[i].GetComponent<Collider2D>().OverlapPoint(CP) && Snapped == true)
            {
                Snapped = false;
                HolderNum = -1;
            }
            if(Die[i].GetComponent<Collider2D>().OverlapPoint(CP) && Snapped == true)
            {
                HolderNum = Die[i].GetComponent<DiceScript>().DiceNum;
            }
        }
    }
}
