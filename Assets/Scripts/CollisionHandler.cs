using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    ParticleSystem explosion;

    [SerializeField]
    ParticleSystem finish;

    private bool gameOver = false;

    private void Start() {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (!gameOver) {
            switch(other.gameObject.tag.ToLower()) 
            {
                case "obstacle" :  {
                    this.explosion.Play();
                    this.gameOver = true;
                    this.Invoke("ResetLevel", 3f);
                    break;
                }
                case "finish" :  {
                    this.finish.Play();
                    this.gameOver = true;
                    this.Invoke("NextLevel", 3f);
                    break;
                }
                default : {
                    break;
                }
            }
        }
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextIndex = 0; 
        if (SceneManager.sceneCountInBuildSettings != (sceneIndex + 1)) 
        {
            nextIndex = sceneIndex + 1;
        }

        SceneManager.LoadScene(nextIndex);
    }
}
