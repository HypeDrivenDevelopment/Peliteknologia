using UnityEngine;

public class OffsetScroller : MonoBehaviour
{
    public float m_ScrollSpeed;

    private Vector2 m_SavedOffset;

    public MeshRenderer m_Renderer;

    void Start()
    {
        m_SavedOffset = m_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        UpdateTextureOffset();
    }

    void OnDisable()
    {
        m_Renderer.sharedMaterial.SetTextureOffset("_MainTex", m_SavedOffset);
    }

    private void UpdateTextureOffset()
    {
        float y = Mathf.Repeat(Time.time * m_ScrollSpeed, 1f);
        Vector2 offset = new Vector2(m_SavedOffset.x, y);
        m_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}