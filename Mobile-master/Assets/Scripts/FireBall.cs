using UnityEngine;

/// <summary>
/// Logic for fireballs which the ship shoots
/// </summary>
public class FireBall : MonoBehaviour
{
    public float m_Speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
