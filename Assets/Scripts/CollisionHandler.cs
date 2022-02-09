using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    ParticleSystem explosion;

    [SerializeField]
    ParticleSystem finish;

    private bool gameOver = false;
    private void OnCollisionEnter(Collision other) {
        if (!gameOver) {
            switch(other.gameObject.tag.ToLower()) 
            {
                case "obstacle" :  {
                    this.explosion.Play();
                    GameOver();
                    break;
                }
                case "finish" :  {
                    this.finish.Play();
                    GameOver();
                    break;
                }
                default : {
                    break;
                }
            }
        }
    }

    private void GameOver()
    {
        this.gameOver = true;
        this.Invoke("ResetLevel", 5f);
    }

    private void ResetLevel()
    {
        
    }
}
