using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public GameObject m_BallPrefab;
    public Transform m_LaunchTransform;

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ballClone = Instantiate(
                m_BallPrefab,
                m_LaunchTransform.position,
                Quaternion.identity);
        }

        // Havaitaan kosketukset.
        if (Input.touchCount > 0)
        {
            // Kosketuksesta muuttuja.
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                // Luodaan kosketuksen alkuvaiheessa pallo.
                case TouchPhase.Began:
            
                    GameObject ballClone = Instantiate(
                    m_BallPrefab,
                    m_LaunchTransform.position,
                    Quaternion.identity);
                    break;
            }

        }
    }
}
        


