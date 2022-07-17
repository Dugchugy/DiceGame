using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public Collider2D GoalCollider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when the object is collided with
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            LoadData.Score += 100;
            LoadData.Goalsfound ++;
            Destroy(gameObject);
        }
        else
        {
            // Do Nothing
        }

    }
}
