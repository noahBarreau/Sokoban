using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public GameObject spawn;
    public Vector3 spawnPosition = Vector3.zero;
    private MeshCollider meshCollider;

    private void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        meshCollider.enabled = false;
        spawn.GetComponent<Transform>().localPosition = spawnPosition;
    }
}
