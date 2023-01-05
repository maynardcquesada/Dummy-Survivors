using UnityEngine;

public class PlayerAnimationUpdate : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Punch = Animator.StringToHash("Punch");

    private void Update()
    {
        AnimationController();
    }

    private void AnimationController()
    {
        var speed = playerRigidBody.velocity.magnitude;
        animator.SetFloat(Speed, speed);

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(Punch);
        }
    }
}
