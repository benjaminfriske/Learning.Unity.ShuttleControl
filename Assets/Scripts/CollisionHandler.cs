using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private ParticleSystem finish;

    [SerializeField]
    private AudioClip crashAudio;

    [SerializeField]
    private AudioClip successAudio;

    [SerializeField]
    private float resetTimer = 2f;

    private AudioSource playerAudioSource;
    private Movement cachedMovement;
    private bool gameOver = false;


    private void Start() {
        cachedMovement = this.GetComponent<Movement>();
        playerAudioSource = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other) {
        if (!gameOver) {
            switch(other.gameObject.tag.ToLower()) 
            {
                case "obstacle" :  {
                    this.explosion.Play();
                    playerAudioSource.PlayOneShot(crashAudio);
                    this.gameOver = true;
                    cachedMovement.enabled = false;
                    this.Invoke("ResetLevel", resetTimer);
                    break;
                }
                case "finish" :  {
                    this.finish.Play();
                    playerAudioSource.PlayOneShot(successAudio);
                    this.gameOver = true;
                    cachedMovement.enabled = false;
                    this.Invoke("NextLevel", resetTimer);
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
