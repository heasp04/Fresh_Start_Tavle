using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Vector2 velocity, bool isGrounded, Vector2 input)
    {
        if (input.x != 0)
        {
            transform.localScale = new Vector3(input.x, 1, 1);
        }
        if (isGrounded)
        {
            _animator.Play(input.x != 0 ? "Player_Walk" : "Player_Idle");
        }
        else
        {
            _animator.Play(input.x != 0 ? "Player_Jump" : "Player_Fall");
        }
    }
}