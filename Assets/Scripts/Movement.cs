using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private bool aClique = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !aClique)
        {
            StartCoroutine(Deplacer(Vector3.back));
            aClique = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && !aClique)
        {
            StartCoroutine(Deplacer(Vector3.forward));
            aClique = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && !aClique)
        {
            StartCoroutine(Deplacer(Vector3.right));
            aClique = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && !aClique)
        {
            StartCoroutine(Deplacer(Vector3.left));
            aClique = true;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            aClique = false;
        }
    }

    private IEnumerator Deplacer(Vector3 direction)
    {
        float tempsTotal = 0.2f;
        float tempsEcoule = 0f;

        Vector3 positionInitiale = transform.position;
        Vector3 positionFinale = positionInitiale + direction;

        while (tempsEcoule < tempsTotal)
        {
            tempsEcoule += Time.deltaTime;
            transform.position = Vector3.Lerp(positionInitiale, positionFinale, tempsEcoule / tempsTotal);
            yield return null;
        }

        transform.position = positionFinale;
    }
}
