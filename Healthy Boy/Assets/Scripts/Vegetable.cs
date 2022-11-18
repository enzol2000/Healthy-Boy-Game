using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public GameObject PickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(PickUpSound);
            other.gameObject.GetComponent<Player>().AddScore();
            Destroy(gameObject);
        }
    }
}
