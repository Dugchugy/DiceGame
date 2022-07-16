using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    public int RollTime;
    public int DiceNum;
    public Animator Anim;
    public float Delay = 0;
    public double MaxDelay = 0.1;
    public bool Dragging;
    public Collider2D Collider;
    public Camera cam;

    public float sensitivity = 35.0f;

    private Rigidbody2D body;
    private DiceCompliment compliment;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Collider = GetComponent<Collider2D>();
        Dragging = false;
        RollTime = 50;

        body = GetComponent<Rigidbody2D>();

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        compliment = cam.gameObject.GetComponent<DiceCompliment>();
    }

    // Update is called once per frame
    void Update()
    {
        Delay += Time.deltaTime;
        if(RollTime > 0)
        {
            if(Delay > MaxDelay)
            {
                Delay = 0;
                DiceRoll();
                RollTime--;
                MaxDelay += 0.005;
            }
        }
        else
        {
            Vector3 SMPos = Input.mousePosition;
            Vector3 MousePos = cam.ScreenToWorldPoint(SMPos);

            if(Input.GetMouseButton(0))
            {

                if(Collider.OverlapPoint(MousePos) && compliment.MouseCanDrag)
                {
                    Dragging = true;
                    compliment.MouseCanDrag = false;
                }
            }else{
                if(Dragging){
                    compliment.MouseCanDrag = true;
                    body.velocity = Vector2.zero;
                }
                Dragging = false;
            }

            if(Dragging){
                MousePos.z = 0;

                Vector2 vel = (MousePos - transform.position) * sensitivity;

                body.velocity = vel;
            }else{
            }
        }
    }

    // Roll the dice
    void DiceRoll()
    {
        // Picks a number between 1 and 6
        DiceNum = Random.Range(1, 7);

        if (DiceNum == 1)
        {
            Anim.SetInteger("Side", 1);
        }

        if (DiceNum == 2)
        {
            Anim.SetInteger("Side", 2);
        }

        if (DiceNum == 3)
        {
            Anim.SetInteger("Side", 3);
        }

        if (DiceNum == 4)
        {
            Anim.SetInteger("Side", 4);
        }

        if (DiceNum == 5)
        {
            Anim.SetInteger("Side", 5);
        }

        if (DiceNum == 6)
        {
            Anim.SetInteger("Side", 6);
        }
    }
}
