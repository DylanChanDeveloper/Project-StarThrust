using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General setup settings")]//header and tooltip 
    [SerializeField][Tooltip("Controls the speed of the ship")] float shipSpeed = 20f;
    [SerializeField][Tooltip("Controls the x rnage for math.clamp")] float xRange = 5f;
    [SerializeField][Tooltip("Controls the y range for math.clamp")] float yRange = 5f;

    [Header("General screen based tuning")]
    [SerializeField][Tooltip("controls the ships position pitch")]  float positionPitchFactor = -2f;//Pitch factors
    [SerializeField] [Tooltip("controls the ships Yaw factor")] float positionYawFactor = 5f;//controls the yaw of the player    
  
    [Header("player input based tuning")]
    [SerializeField][Tooltip("controls the ships pitch factor")] float controlPitchFactor = -10f;//controls the pitch of the player    
    [SerializeField][Tooltip("controls the ships roll factor")]  float controlRollFactor = -25f;//controls the roll of the player

    [Header("Game arrays")]
    [SerializeField][Tooltip("arrays for lasers")] GameObject[] lasersArray;

    float yThrow;//member variables.
    float xThrow;

    //  [SerializeField]
    //   float controlYawFactor = 10f;
    //  [SerializeField]//roll factors 
    //   float positionRollFactor = -20f;

    void Update()
    {
        processTranlation();
        proccessRotation();
        processPlayerFiring();
    }

    void proccessRotation()
    {
        //example rick done
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        //float YawDueToPosition = transform.localPosition.x * positionYawFactor; //your way
        //float DueToControlThrow = xThrow * controlYawFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;      
        float yaw = transform.localPosition.x * positionYawFactor; //ricks way
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void processTranlation()
    {
         xThrow = Input.GetAxis("Horizontal");//gets the player input x and y axis
         yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * shipSpeed * Time.deltaTime;//makes the movement framerate indempendant.
        float yOffset = yThrow * shipSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;//gets the objects transform position and accessing its x localposition(localposition is relitive to the object and not its global position). Then adding 1 to move it
        float rawYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);//clamps the position so the ship can only make a certain distance in the x and y ranges.
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void processPlayerFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetActivateLasers(true);
        }

        else
        {
            SetActivateLasers(false);
        }
    }

    void SetActivateLasers(bool laserActive)
    {
        foreach(GameObject activingLasers in lasersArray)
        {
            var laserEnabled = activingLasers.GetComponent<ParticleSystem>().emission;
                laserEnabled.enabled = laserActive;
        }
    }

   

}
