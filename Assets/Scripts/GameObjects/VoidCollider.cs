using UnityEngine;

public class VoidCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Destroy(other.gameObject);
        }
    }
}
