using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject SpawnBoxObject;

    void start()
    {
        Vector3 newPosition = new Vector3(
            transform.localPosition.x + 1, // D�placer d'une unit� � droite
            transform.localPosition.y,     // Garde la position en Y
            transform.localPosition.z - 1  // D�placer d'une unit� en arri�re (sur l'axe Z)
        );

        // D�placer le prefab en utilisant le Transform
        SpawnBoxObject.transform.Translate(Vector3.right);
    }
}
