using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
 private LogicScript logic;
    private AudioManager audioManager;

    private void Start()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
        if (logicObject != null)
        {
            logic = logicObject.GetComponent<LogicScript>();
        }

        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }

        if (logic == null)
        {
            Debug.LogError("LogicScript not found");
        }

        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            if (logic != null)
            {
                logic.addScore(1); // Add score using the existing method
                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.coin); // Play the coin sound effect
                }
                Destroy(collision.gameObject);
                Debug.Log("Coin collected");
            }
            else
            {
                Debug.LogError("LogicScript instance is null");
            }
        }
    }
}
