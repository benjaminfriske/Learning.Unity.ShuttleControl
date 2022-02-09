using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrust = 150;

    [SerializeField]
    private float rotationSpeed = 30;
    [SerializeField]
    private AudioClip thrustSoundClip;

    private Rigidbody playerRigidBody;
    private AudioSource playerAudioSource;
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
                Rotate(-rotationSpeed);
            }
            else
            {
                Rotate(rotationSpeed);
            }

        }

        if (Input.GetKey(KeyCode.Space) && !playerAudioSource.isPlaying)
        {
            playerAudioSource.PlayOneShot(thrustSoundClip);
            Thrust();
            
        }
        else if (Input.GetKey(KeyCode.Space) && playerAudioSource.isPlaying) {
            Thrust();
        }
        else
        {
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
        Vector3 rotateLeft = Vector3.forward * rotationThisFrame * Time.deltaTime;
        this.transform.Rotate(rotateLeft);
        playerRigidBody.freezeRotation = false;
    }
}
