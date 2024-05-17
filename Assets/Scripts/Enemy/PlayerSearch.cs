using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerSearch : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance = 0.5f;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        DetectionPlayer();
    }

    private void DetectionPlayer()
    {
        float coordinateOffset = 0.5f;

        Vector2 origin = transform.position;
        Vector2 direction = _player.transform.position + Vector3.up * coordinateOffset - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, _distance);

        Debug.DrawLine(origin, _player.transform.position * _distance + Vector3.up * coordinateOffset, Color.red );

        if (hit.collider != null && hit.collider.gameObject == _player.gameObject)
        {
            float angleRotationY = Mathf.Round(transform.rotation.eulerAngles.y);

            if (transform.position.x < (_player.transform.position).x && angleRotationY == 0)
            {
                Debug.Log("1");
                //ChangeDirection();
            }

            if (transform.position.x > (_player.transform.position).x && angleRotationY == 0)
            {
                Debug.Log("2");
                //ChangeDirection();
            }
        }
    }

}
