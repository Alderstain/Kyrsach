using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ark : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<SpaceShip>().AddHealth();
            Destroy(gameObject);
        }
    }
}
