using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 10;

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
            if (axisHorizontal > 0) {
            //right
            Vector3 rotationForce =  Vector3.forward * 1 * Time.deltaTime;
                playerRigidBody.AddRelativeForce(rotationForce);
            }
            
            else {
            //left
                Vector3 rotationForce =  new Vector3(0, axisHorizontal * rotationSpeed *  Time.deltaTime, 0);
                playerRigidBody.AddRelativeForce(rotationForce);
            }
           
        }
    }
}
