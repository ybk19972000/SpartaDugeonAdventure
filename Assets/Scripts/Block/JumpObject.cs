using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public float forcePower = 4.0f;
    public float boostPower = 8.0f; // 점프 오브젝트에 닿았을 때 추가되는 힘
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    } 

    void AddForceJump()
    {
        //rigidbody.AddForce(transform.up * forcePower);
        rigidbody.AddForce(transform.up * forcePower, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(Vector3.up * boostPower, ForceMode.Impulse);
            }
        }
    }
}
