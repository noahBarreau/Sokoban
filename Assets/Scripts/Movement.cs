using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private bool aClique = false;

    void Update()
    {
        RaycastHit hit;
        bool canMoove=false;

        if (Input.GetKeyDown(KeyCode.D) && !aClique)
        {
            
            if (Physics.Raycast(transform.position, Vector3.back, out hit, 1f))
            {
                if (hit.collider.CompareTag("Box")) // Si c'est une bordure, on ne bouge pas
                {
                    canMoove = PeutBouger(Vector3.back, 2.5f);
                }
                else
                {
                    canMoove = PeutBouger(Vector3.back, 1.5f);
                }
            }
            else
            {
                canMoove = PeutBouger(Vector3.back, 1.5f);
            }

            if (canMoove)
            {
                StartCoroutine(Deplacer(Vector3.back));
                aClique = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !aClique)
        {

            if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1f))
            {
                if (hit.collider.CompareTag("Box")) // Si c'est une bordure, on ne bouge pas
                {
                    canMoove = PeutBouger(Vector3.forward, 2.5f);
                }
                else
                {
                    canMoove = PeutBouger(Vector3.forward, 1.5f);
                }
            }
            else
            {
                canMoove = PeutBouger(Vector3.forward, 1.5f);
            }

            if (canMoove)
            {
                StartCoroutine(Deplacer(Vector3.forward));
                aClique = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && !aClique)
        {

            if (Physics.Raycast(transform.position, Vector3.right, out hit, 1f))
            {
                if (hit.collider.CompareTag("Box")) // Si c'est une bordure, on ne bouge pas
                {
                    canMoove = PeutBouger(Vector3.right, 2.5f);
                }
                else
                {
                    canMoove = PeutBouger(Vector3.right, 1.5f);
                }
            }
            else
            {
                canMoove = PeutBouger(Vector3.right, 1.5f);
            }

            if (canMoove)

                if (canMoove)
            {
                StartCoroutine(Deplacer(Vector3.right));
                aClique = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !aClique)
        {

            if (Physics.Raycast(transform.position, Vector3.left, out hit, 1f))
            {
                if (hit.collider.CompareTag("Box")) // Si c'est une bordure, on ne bouge pas
                {
                    canMoove = PeutBouger(Vector3.left, 2.5f);
                }
                else
                {
                    canMoove = PeutBouger(Vector3.left, 1.5f);
                }
            }
            else
            {
                canMoove = PeutBouger(Vector3.left, 1.5f);
            }

            if (canMoove)
            {
                StartCoroutine(Deplacer(Vector3.left));
                aClique = true;
            }
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

    // Vérifie s'il y a une bordure dans la direction donnée
    private bool PeutBouger(Vector3 direction, float distanceDetection)
    {
        Vector3 nouvellePosition = transform.position + (direction * distanceDetection);
        Collider[] objets = Physics.OverlapSphere(nouvellePosition, 0.1f);

        foreach (Collider objet in objets)
        {
            if (objet.CompareTag("Border"))
            {
                return false; 
            }
        }

        return true;
    }
}
