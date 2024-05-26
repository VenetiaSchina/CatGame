using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catmovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool catIsAlive = true;
    [SerializeField] float deathYThreshhold = -3.9f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
 
    //Update is called once per frame
    void Update()
    {
        if (transform.position.y < deathYThreshhold)
        {
            logic.gameOver();
            catIsAlive = false;
           
        }

        if (Input.GetKeyDown(KeyCode.Space) && catIsAlive)
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
       logic.gameOver();
       catIsAlive = false;
       audioManager.PlaySFX(audioManager.die);
    }

    

}
