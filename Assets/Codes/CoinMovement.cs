using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float fallSpeed = 2f;
    private float bottomY = -5f; // Adjust this value according to your scene

    void Update()
    {
        // Move the coin downwards
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Check if the coin is below the bottom threshold
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}