using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPC : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    public int attack;
    private Rigidbody rig;
    private Animator animE;
    private SpriteRenderer render;
    private bool andar;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        animE = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        andar = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform);

        if (dist > 10f)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            animE.SetBool("isWalking", andar);
        }
        else
        {
            animE.SetBool("isWalking", andar);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        andar = false;

        if (collision.gameObject.name == player.name)
        {
            animE.SetBool("attack", true);
            animE.SetBool("isWalking", false);
        }

    }

}