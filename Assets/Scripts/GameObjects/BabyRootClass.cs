using UnityEngine;

public class BabyRootClass : MonoBehaviour
{
    delegate void HitTarget();
    HitTarget Hit;

    [SerializeField]
    private BabyRoot_SO m_config;

    [SerializeField]
    private BabyRootType m_Type;

    private SpriteRenderer m_spriteImage => GetComponent<SpriteRenderer>();

    private void OnEnable()
    {
        Hit += LogHit;
    }

    private void OnDisable()
    {
        Hit -= LogHit;
    }

    private void OnDestroy()
    {
        Hit -= LogHit;
    }

    private void Initiaize()
    {
        m_Type = m_config.Type;
        m_spriteImage.sprite = m_config.Sprite;
    }

    public void setType(BabyRootType type)
    {
        m_Type = type;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            //TODO Score
            
            Hit();

            Destroy(gameObject);
        }
    }

    private void LogHit()
    {
        Debug.Log("Hit Target!");
    }
}
