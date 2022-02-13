using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem rightParticle;

    [SerializeField]
    private ParticleSystem leftParticle;

    [SerializeField]
    private ParticleSystem upParticle;

    [SerializeField]
    private float thrust = 150;

    [SerializeField]
    private float rotationSpeed = 30;
    [SerializeField]
    private AudioClip thrustSoundClip;

    private Rigidbody playerRigidBody;
    private AudioSource playerAudioSource;

    private bool isThrusting = false;
    private void Start()
    {
        playerRigidBody =  this.gameObject.GetComponent<Rigidbody>();
        playerAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        var axisHorizontal = Input.GetAxis("Horizontal");
        if (axisHorizontal != 0) 
        {
            if (axisHorizontal > 0)
            {
                Debug.Log("play particle");
                if (!isThrusting) 
                {
                    this.leftParticle.Play();
                }
                
                Rotate(-rotationSpeed);
            }
            else
            {
                if (!isThrusting) 
                {
                    this.rightParticle.Play();
                }
                
                Rotate(rotationSpeed);
            }
            isThrusting = true;
        }
        else 
        {
            isThrusting = false;
            this.rightParticle.Stop();
            this.leftParticle.Stop();
        }

        if (Input.GetKey(KeyCode.Space) && !playerAudioSource.isPlaying)
        {
            playerAudioSource.PlayOneShot(thrustSoundClip);
            upParticle.Play();
            Thrust();
        }
        else if (Input.GetKey(KeyCode.Space) && playerAudioSource.isPlaying) {
            Thrust();
        }
        else
        {
            upParticle.Stop();
            playerAudioSource.Stop();
        }

    }

    private void Thrust()
    {
        
        playerRigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
    }

    private void Rotate(float rotationThisFrame)
    {
        playerRigidBody.freezeRotation = true;
        Vector3 rotation = Vector3.forward * rotationThisFrame * Time.deltaTime;
        this.transform.Rotate(rotation);
        playerRigidBody.freezeRotation = false;
    }
}
