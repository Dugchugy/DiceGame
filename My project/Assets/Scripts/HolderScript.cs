using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScript : MonoBehaviour
{
    private ContactFilter2D Filter = new ContactFilter2D();
    public Collider2D HolderCollider;

    // Start is called before the first frame update
    void Start()
    {
        Filter.NoFilter();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] Results = new Collider2D[0];
        if(HolderCollider.OverlapCollider(Filter, Results) > 0)
        {
            for(int i = 0; i < Results.Length; i++)
            {
                if(Results[i].gameObject.tag == "Dice")
                {

                }
            }
        }
    }
}
