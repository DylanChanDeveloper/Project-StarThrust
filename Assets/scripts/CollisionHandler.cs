using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float LevelDelayTimer = 1f;

   [SerializeField] ParticleSystem explosionVFX;

    void OnTriggerEnter(Collider TriggerDetection)
    {
        switch (TriggerDetection.gameObject.tag)
        {
            case "Enemy":
                startCollisionSequence();
                break;

            case "Terrain":
                startCollisionSequence();
                break;
        }
    }

    void startCollisionSequence()
    {
        explosionVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled = false;//disables the player controller script.
        Invoke("ReloadLevel", LevelDelayTimer);//Invoke adds a delay to the string methods specified and waits a certain amount of seconds in this case LevelDelayTimer.
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//accesses the scene manager gets the current active scene and returns the buildindex number of that scene in this case 0
        SceneManager.LoadScene(currentSceneIndex);
    }

    //THIS COMMENT SECTION IS FOR COLLISION UNDERSTANDING

    // void OnTriggerEnter(Collider TriggerDetection)
    //{
    //   if(TriggerDetection.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log(this.name + " collidered with" + TriggerDetection.gameObject.name);//the this means all the things that this script is on, name means that it gets the name of the object the scripts on
    //    }                                            //TriggerDetection.gameObject.name gets the name of the gameobjects information triggered when collided with the object that this script was on
    //}

    //OR

    //void OnTriggerEnter(Collider TriggerDetection)
    //{     
    //  Debug.Log(this.name + " collidered with" + TriggerDetection.gameObject.name);//the this means all the things that this script is on, name means that it gets the name of the object the scripts on
    //                                              //TriggerDetection.gameObject.name gets the name of the gameobjects information triggered when collided with the object that this script was on


    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log($"{this.name} ** Triggered by ** {collision.gameObject.name}");    
    //}

}
