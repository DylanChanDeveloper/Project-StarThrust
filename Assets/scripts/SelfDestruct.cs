using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]float destroyTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //if you want to destroy a child of the gameObject but need to put the script on the parent object
    //void destroyingGameObject()
    //{
    //    foreach (Transform child in transform)
    //    {
    //        GameObject.Destroy(child.gameObject,3f);
    //    }
    //}
}
