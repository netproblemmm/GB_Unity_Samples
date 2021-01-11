using UnityEngine;

public class MineBomb : MonoBehaviour
{
    [SerializeField] private string _detectTag;
    [SerializeField] private float _delayBeforeDestroy;
    [SerializeField] private float _bombForce = 5000;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private Vector3 _intend;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_detectTag) == false) return;

        var otherBody = other.gameObject.GetComponent<Rigidbody>();
        if (otherBody)
        {
            otherBody.AddExplosionForce(_bombForce, transform.position + _intend, _explosionRadius);
        }

        Destroy(other.gameObject, _delayBeforeDestroy);
        Destroy(gameObject);
    }
}
