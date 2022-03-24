using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
     void Awake()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;// we are finding the object of type music player and getting accessing the array length and counting the array.
                                                                           // Then we are storing it in a int variable to use below.

        if(numberOfMusicPlayers > 1)//if there is more then one music gameObject being created it will be destroyed.
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);//DontDestroyOn Load will stop the gameObject from being destroyed if there is currently one music game object running.
        }
    }
}
