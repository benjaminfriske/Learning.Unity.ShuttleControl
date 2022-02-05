using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float thrust = 150;

    [SerializeField]
    private float rotationSpeed = 30;

    private Rigidbody playerRigidBody;
    private void Start()
    {
        playerRigidBody =  this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var axisHorizontal = Input.GetAxis("Horizontal");
        if (axisHorizontal != 0) 
        {
            if (axisHorizontal > 0)
            {
                RotateRight();
            }
            else
            {
                RotateLeft();
            }

        }

        if (Input.GetKey(KeyCode.Space))
        {
            Thrust();
        }

    }

    private void Thrust()
    {
        playerRigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
    }

    private void RotateLeft()
    {
        Vector3 rotateLeft = Vector3.forward * rotationSpeed * Time.deltaTime;
        this.transform.Rotate(rotateLeft);
    }

    private void RotateRight()
    {
        Vector3 rotateRight = -Vector3.forward * rotationSpeed * Time.deltaTime;
        this.transform.Rotate(rotateRight);
    }
}
