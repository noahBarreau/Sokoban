using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public GameObject SpawnBoxObject;

    void start()
    {
        Vector3 newPosition = new Vector3(
            transform.localPosition.x + 1, // Déplacer d'une unité à droite
            transform.localPosition.y,     // Garde la position en Y
            transform.localPosition.z - 1  // Déplacer d'une unité en arrière (sur l'axe Z)
        );

        // Déplacer le prefab en utilisant le Transform
        SpawnBoxObject.transform.Translate(Vector3.right);
    }
}
