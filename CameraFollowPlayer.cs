using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
     
    void Update()
    {
        Vector3 posCam = transform.position;
        posCam.x = player.transform.position.x;
        transform.position = posCam;
    }
}
