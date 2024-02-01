// взято тут
// http://www.unity3d.ru/distribution/viewtopic.php?f=105&t=45047&p=278765

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _platformLayer;

    private Vector3 _direction;
    private bool _isGrounded;

    private void Start()
    {
        _direction = transform.right;

    }

    private void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void MovePlayer()
    {
        if (_isGrounded == false) _direction *= -1.0F;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + _direction * 0.2f, Vector3.down, 1, _platformLayer);
        _isGrounded = (hit.collider != null);

        Debug.Log(hit);

        // рисуем луч для отладки, чтобы убедится в его правильном расположении
        Debug.DrawRay(transform.position + _direction * 0.2f, Vector3.down);
    }
}
