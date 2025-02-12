using UnityEngine;

public class GetSpeedPlayer : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetSpeed();
        }
    }

    void GetSpeed()
    {
        GameObject Player;
        Player = GameObject.Find("Player");
        Player.GetComponent<Movement>().speed = 0;

        // La même chose
        GameObject.Find("Player").GetComponent<Movement>().speed = 0;
    }
}
