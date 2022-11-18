using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.visible = true;
            PlayerHUD Hud = FindObjectOfType<PlayerHUD>();
            Hud.mFinishLevel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
