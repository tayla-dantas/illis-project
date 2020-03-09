using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public float vida;
    private float enemyAttack;
    private Animator enemyAnim;
    public float damageCD;
    public float cd;
    public int playerGato;
    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.Find("Orc");
        enemyAttack = enemy.GetComponent<FollowNPC>().attack;
        enemyAnim = enemy.GetComponent<Animator>();
        player = GameObject.Find("Marie");
        playerGato = player.GetComponent<Movement>().gato;
        animator = GetComponent<Animator>();
        damageCD = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        cd += Time.deltaTime;
        if (cd > damageCD + 0.1f)
        {
            cd = 0;
        }
        playerGato = player.GetComponent<Movement>().gato;
    }

   

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Orc" || collision.gameObject.name == "Orc2" || collision.gameObject.name == "Orc3")
        {
            if (cd >= damageCD)
            {
                vida = vida - enemyAttack;
            }
            else if(vida <= 0)
            {
                StartCoroutine(OpenLevel("lose"));
            }
        }  
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Marie" && playerGato == 1)
        {
            StartCoroutine(OpenLevel("win"));
            animator.SetBool("saved", true);
            GetComponent<AudioSource>().Play();
        }
    }

    public void setVida(float vidaCurada)
    {
        vida = vida + vidaCurada;
    }

    public IEnumerator OpenLevel(string level)
    {
        //GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(level);

    }


}
