using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject point;
    public GameObject Player;

    private void OnTriggerEnter(Collider other) {
        Player.transform.position = point.transform.position;
    }
}
