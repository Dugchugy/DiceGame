using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float Speed = 20;

    public Vector3 shotDirection;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = shotDirection.normalized * Speed;
    }

    void OnCollisionEnter2D(Collision2D c){
        Destroy(gameObject);
    }
}
