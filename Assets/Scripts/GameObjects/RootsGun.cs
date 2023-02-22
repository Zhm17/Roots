using System.Collections;
using UnityEngine;

public class RootsGun : MonoBehaviour
{
    [SerializeField]
    private Transform m_BulletPrefab;
    private Rigidbody m_CurrentBullet;

    public float m_Force = 50f;

    public float m_WaitSeconds = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateBullet();
        StartCoroutine(GunCoroutine());
    }

    IEnumerator GunCoroutine()
    {
        while (true) 
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Shoot
                if (m_CurrentBullet != null)
                {
                    m_CurrentBullet.useGravity = true;
                    m_CurrentBullet
                        .AddRelativeForce(transform.forward * m_Force,
                                            ForceMode.Impulse);
                }

                //Wait
                yield return new WaitForSeconds(m_WaitSeconds);
                CreateBullet();
            }

            yield return null;
        }
    }

    private void CreateBullet()
    {
        m_CurrentBullet = Instantiate(m_BulletPrefab, 
                                        transform.position, 
                                        Quaternion.identity)
                        .GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
