using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    private const string NameParametrAnimation = "State";
    private const int RunState = 0;
    private const int AttackState = 1;

    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    public void Run()
    {
        _animation.SetInteger(NameParametrAnimation, RunState);
    }

    public void Attack()
    {
        _animation.SetInteger(NameParametrAnimation, AttackState);
    }
}
