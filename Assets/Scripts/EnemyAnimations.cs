using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    const string NameParametrAnimation = "State";
    const int RunState = 0;
    const int AttackState = 1;

    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    public void Attack()
    {
        _animation.SetInteger(NameParametrAnimation, (int)AttackState);
    }

    public void Run()
    {
        _animation.SetInteger(NameParametrAnimation, (int)RunState);
    }
}
