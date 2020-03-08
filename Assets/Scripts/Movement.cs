using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int gato;
    protected Joystick joystick;
	protected Joybutton joybutton;
	protected bool attack;
    private bool isWalking;
    Animator anim;
    private SpriteRenderer renderer;
    private GameObject npc;
    public GameObject colisorAtaque;
    public float npcVida;
    void Start()
    {
		
		joystick = FindObjectOfType<Joystick>();
		joybutton = FindObjectOfType<Joybutton>();
		anim = GetComponent<Animator>();
        isWalking = false;
        renderer = GetComponent<SpriteRenderer>();
        colisorAtaque.SetActive(false);
        gato = 0;
        npc = GameObject.Find("alexia");
        
    }

    void Update()
    {
        var rigidBody = GetComponent<Rigidbody>();
        npcVida = npc.GetComponent<NPC>().vida;
        rigidBody.velocity = new Vector3(
            joystick.Horizontal * 10f,
            0,
            joystick.Vertical * 10f);
        if (!attack && joybutton.Pressed)
        {
            attack = true;
            anim.SetTrigger("attack");
            AttackEnemy();
        }
        if (attack && !joybutton.Pressed)
        {
            attack = false;
            colisorAtaque.SetActive(false);
        }
        if (rigidBody.velocity.x > 0)
        {
            isWalking = true;
            renderer.flipX = false;
            anim.SetBool("isWalking", isWalking);
        }
        else if (rigidBody.velocity.x < 0)
        {
            isWalking = true;
            renderer.flipX = true;
            anim.SetBool("isWalking", isWalking);
        }
        else
        {
            isWalking = false;
            anim.SetBool("isWalking", isWalking);

        }
    }
    void AttackEnemy()
    {
        colisorAtaque.SetActive(true);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Orc" )
        {
            anim.SetTrigger("attack");
            Destroy(collision.gameObject);            
        }
        else if (collision.gameObject.name == "Cat")
        {
            Destroy(collision.gameObject);
            gato = 1;
        }
        else if(collision.gameObject.name == "Cura")
        {
            npc.GetComponent<NPC>().setVida(50);
            Destroy(collision.gameObject);
        }
    }
}
