using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPC : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    public float attack;
    private Rigidbody rig;
    private Animator animE;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        animE = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        ;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform);


        if (dist <= 10f)
        {
            animE.SetTrigger("attack");
            animE.SetBool("isWalking", false);
        }
        else if (dist >= 10f)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            animE.SetBool("isWalking", true);
        }

    }

}