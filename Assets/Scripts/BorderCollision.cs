using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    private bool canMove = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            canMove = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            canMove = true;
        }
    }

    public bool CanMove()
    {
        return canMove;
    }
}
