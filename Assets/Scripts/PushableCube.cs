using UnityEngine;

public class PushableCube : MonoBehaviour
{
    public float moveDistance = 1f;
    private bool hasMoved = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasMoved && collision.gameObject.CompareTag("Player"))
        {
            Vector3 pushDirection = collision.transform.position.x < transform.position.x ? Vector3.right : Vector3.left;
            transform.position += pushDirection * moveDistance;
            hasMoved = true;
        }
    }
}
