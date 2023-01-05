using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    [Header("Needed Player Components")] 
    [SerializeField] private Transform playerGameObject;

    [Header("Third Person Camera Component")] 
    [SerializeField] private Transform cam;

    [Header("Player Movement Values")]
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float turnSmoothTime;
    private float turnSmoothVelocity;
    private Vector3 calculatedMovement;

    private void Update()
    {
        PlayerMove();
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = calculatedMovement;
    }

    private void PlayerMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        calculatedMovement = new Vector3(horizontal, 0, vertical).normalized;

        if (!(calculatedMovement.magnitude >= 0.1f)) return;
        
        var targetAngle = Mathf.Atan2(calculatedMovement.x, calculatedMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        var angle = Mathf.SmoothDampAngle(playerGameObject.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        playerGameObject.rotation = Quaternion.Euler(0f, angle, 0f);

        var moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
        calculatedMovement = moveDir * movementSpeed;
    }
}
