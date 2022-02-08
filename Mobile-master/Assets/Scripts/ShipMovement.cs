using UnityEngine;

/// <summary>
/// Handles the ship's movement
/// </summary>
public class ShipMovement : MonoBehaviour
{
    public const string HorizontalAxis = "Horizontal";

    public float m_Speed = 10f;

    public GameObject m_Flame;

    /** Restrictions so the ship stays inside the camera */
    private float m_RightRestriciton;
    private float m_LeftRestrcition;

    private void Start()
    {
        SetRestrictions();
    }

    private void Update()
    {
        MoveX(Input.GetAxis(HorizontalAxis));
    }

    private void SetRestrictions()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        float shipHalfSize = GetComponent<SpriteRenderer>().size.x / 2;

        m_RightRestriciton = (cameraWidth / 2) - shipHalfSize;
        m_LeftRestrcition = -m_RightRestriciton;
    }

    /** Ship movement in X axis */
    private void MoveX(float input)
    {
        if (input == 0)
        {
            m_Flame.SetActive(false);
            return;
        }

        float x = transform.position.x;

        if (x > m_RightRestriciton && input > 0)
        {
            return;
        }

        if (x < m_LeftRestrcition && input < 0)
        {
            return;
        }

        m_Flame.SetActive(true);

        Vector2 translation = new Vector2(input * m_Speed * Time.deltaTime, 0);
        transform.Translate(translation, Space.World);
    }
}
