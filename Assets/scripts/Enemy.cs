using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]GameObject DeathFX;//controls the vfx and sound fx when a enemy ship is destroyed.
    [SerializeField]GameObject hitVFX;

    [SerializeField] int ScoreIncreaseAmount = 2;//for passing in as a paramter
    [SerializeField] int hitPonts = 2;

    ScoreBoard myScoreBoard;
    GameObject parentGameObject;//used for tag
    //AudioSource myAudioClip;    

    void Start()
    {
        //myAudioClip = GetComponent<AudioSource>();

        myScoreBoard = FindObjectOfType<ScoreBoard>();//find object of type looks through are entire project and says the very first scoreboard you find
                                                      //thats the scoreboard we're refering too. Is very rescource intensive in update.    
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");//finds the game with the tag in the string
        AddRigidbody();
    }

     void AddRigidbody()
    {
        Rigidbody myrb = gameObject.AddComponent<Rigidbody>();//adds a rigidbody and stores it in the  myrb variable
        myrb.useGravity = false;
    }

    void OnParticleCollision(GameObject particleDector)
    {
            ProcessingHit();
       
        if (hitPonts < 1)//if the enemy hitpoint is less than 1 because having 0 could cause issues then we will process death.
        {
            ProcessDeath();
        }
    }

     void ProcessDeath()
    {
        myScoreBoard.IncreaseScore(ScoreIncreaseAmount);//where accessing the scoreboard class with the myScorboard variable created above,
                                                        //then were accessing the public Increase score method and passing in a scoreIncrease amount into it.
        GameObject storeVFX = Instantiate(DeathFX, transform.position, Quaternion.identity);//spawns a Deathfx(with the hit audio sound)on the current position of the gameobject quaternion identy is no rotation. Then stores the instantiated gameobject in a gameobject variable.
        storeVFX.transform.parent = parentGameObject.transform;//the transform, the entity has a parent and that particular parent is going to be the parent variable we serilized and pointed too.
        //Debug.Log($"{name} I'm hit by {particleDector.gameObject.name}");             
        Destroy(gameObject);
        //or
        //  Destroy(this.gameObject); //destroys the game object because we use this. : this means this script the game object is on
    }

    

     void ProcessingHit()
    {
        //myAudioClip.Play();
        GameObject storeVFX = Instantiate(hitVFX, transform.position, Quaternion.identity);//quaternion identy is no rotation
        storeVFX.transform.parent = parentGameObject.transform;//the transform, the entity has a parent and that particular parent is going to be the parent variable we serilized and pointed too.
        hitPonts = hitPonts - 1;// or hitpoints --; decreases the enemy hitpoint by 1 every time the players shots hit an enemy      
       
    }
}
