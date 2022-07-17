using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float agroDistance = 5;

    public float chaseSpeed = 3;

    public float chaseDist = 2;

    public float idleSpeed = 0.2f;

    public float maxIdleSpeed = 0.8f;

    public int health  = 4;

    public float Reload = 0.75f;

    private GameObject PlayerCharacter;

    private Rigidbody2D body;

    private float Firetime = 0;

    private GameObject ProjTemplate;

    public Animator EnemyAnim;



    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        PlayerCharacter = GameObject.Find("PlayerCharacter");

        ProjTemplate = Resources.Load<GameObject>("Enemies/EnemyProjectile");

        GetComponent<Animator>().SetInteger("Variant", LoadData.RoomType);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Firetime += Time.fixedDeltaTime;

        Vector3 towardsPlayer = (transform.position - PlayerCharacter.transform.position);

        if ( towardsPlayer.magnitude < agroDistance && towardsPlayer.magnitude > chaseDist )
        {
            body.velocity = towardsPlayer.normalized * -chaseSpeed;
        }else if(towardsPlayer.magnitude < agroDistance){
            body.velocity = towardsPlayer .normalized * chaseSpeed;
        }
        else
        {
            if(body.velocity.magnitude > maxIdleSpeed){

                body.velocity += body.velocity.normalized * -1 * (body.velocity.magnitude - maxIdleSpeed);
            }else{
                body.velocity += (new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized) * idleSpeed;
            }
        }

        if ( towardsPlayer.magnitude < agroDistance) {
            if(Firetime > Reload){

                //shoots
                GameObject proj = Instantiate(ProjTemplate);

                proj.transform.position = transform.position - (towardsPlayer.normalized * 1.1f);

                proj.GetComponent<EnemyProjectile>().shotDirection = -towardsPlayer.normalized;

                Firetime = 0;

            }
        }


    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.tag == "Bullet"){
            health --;

            if(health < 1){

                LoadData.Score += 50;

                Destroy(gameObject);
            }
        }
    }
}
