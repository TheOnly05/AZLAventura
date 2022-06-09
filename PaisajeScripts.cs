using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaisajeScripts : MonoBehaviour
{
    private float leght, starPos;
    public GameObject camar;
    public float parallaxEffects;

    void Start()
    {
        starPos = transform.position.x;
        leght = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }
    void FixedUpdate()
    {
        float temp = (camar.transform.position.x * (1 - parallaxEffects));

        float dist = (camar.transform.position.x * parallaxEffects);

        transform.position = new Vector3(starPos + dist, transform.position.y, transform.position.z);

          
        if(temp > starPos + leght)
        {
            starPos += 1;
        }
        else if (temp < starPos - leght)
        {
            starPos -= 1;
        }
    }
}
