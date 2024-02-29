using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsRunning = "IsRunning";
    private const string IsJumping = "IsJumping";
    private const string IsAttacking = "IsAttacking";

    //    private const string IsMovement = "IsMovement";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartJumping() => _animator.SetBool(IsJumping, true);
    public void StopJumping() => _animator.SetBool(IsJumping, false);

    public void StartAttacking() => _animator.SetBool(IsAttacking, true);
    public void StopAttacking() => _animator.SetBool(IsAttacking, false);

    //public void StartMovement() => _animator.SetBool(IsMovement, true);
    //public void StopMovement() => _animator.SetBool(IsMovement, false);
}
