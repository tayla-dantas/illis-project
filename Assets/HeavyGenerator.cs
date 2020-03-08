using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyGenerator : MonoBehaviour
{
    GameObject Objective;
    float dist;
    private Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Objective = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         if (Objective)
        {
            dist = Vector3.Distance(Objective.transform.position, transform.position);
            if(dist <= 10.0f){
                playerClose = true;
            }else{
                playerClose = false;
            }
        }
        if(playerClose){
            SpawnEnemy();
        }
    }
    public GameObject EnemyRef;
    public bool playerClose = false;
    public bool generate = false;
    public float genTime = 5.0f;
    public float genCounter =  0.0f;
    public float minGenTime =1.0f;
    public float maxGenTime =5.0f; 
	void SpawnEnemy(){
        genCounter += Time.deltaTime;
        spawnPosition.x = 0.5262715f;
        spawnPosition.y = 0.088f;
        spawnPosition.z = 0.3892839f;
        if (genCounter >= genTime){
            generate = true;
        }
        if(generate){
            GameObject instantiateEnemy = 
            (GameObject)Instantiate(
                EnemyRef,
                spawnPosition, 
                transform.rotation
            );
            float enemyX = instantiateEnemy.transform.position.x;
            float enemyY = instantiateEnemy.transform.position.y;
            float enemyZ = instantiateEnemy.transform.position.z;
            enemyX = 0.05262715f;
            enemyY = 0.08800001f;
            enemyZ = 0.3892839f;
            instantiateEnemy.name = "Orc";
            generate = false;
            genCounter = 0.0f;
            genTime = Random.Range(minGenTime,maxGenTime);
        }

	}
}
