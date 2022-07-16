using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float agroDistance = 5;

    public float chaseSpeed = 3;

    public float reloadTime = 2;

    private GameObject PlayerCharacter;

    private Rigidbody2D body;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        PlayerCharacter = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 towardsPlayer = (transform.position - PlayerCharacter.transform.position);

        if ( towardsPlayer.magnitude < agroDistance )
        {
            body.velocity = towardsPlayer.normalized * -chaseSpeed;
        }
        else
        {
            body.velocity = new Vector3(random.range(-1.0f, 1.0f), random.range(-1.0f, 1.0f), random.range(-1.0f, 1.0f).normalized );
        }
    }
}
