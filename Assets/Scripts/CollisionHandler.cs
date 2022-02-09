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
        var nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log($"Current Build Index: {nextIndex}");
        var nextIndexName = SceneManager.GetSceneByBuildIndex(nextIndex).name;
        Debug.Log($"Next Build Name: {nextIndexName}");
        SceneManager.LoadScene(nextIndexName);
    }
}
