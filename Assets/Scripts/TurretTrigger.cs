using UnityEngine;

public class TurretTrigger : MonoBehaviour
{
    private GameObject _bulletPrefab;
    [SerializeField] private string _detectTag;
    [SerializeField] private GameObject _turret;
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletForce;
    //private Vector3 _targetDirect = new Vector3(0,1,0);
    //private float _rotationSpeed = 1;

    private void Start()
    {
        _bulletPrefab = GameObject.Find("Bullet");
        _bulletPrefab.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_detectTag) == false) return;

        _turret.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 80.0f);
        //_turret.transform.rotation.SetLookRotation(new Vector3(0,60,0));

        //Quaternion rotation = Quaternion.FromToRotation(transform.forward, _targetDirect);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);

        var newBullet = Instantiate(_bullet, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity, transform);
        newBullet.SetActive(true);
        var newBulletBody = newBullet.GetComponent<Rigidbody>();
        newBulletBody.AddForce((_gun.transform.position + new Vector3(3, -2.5f, 0)) * _bulletForce);
            
    }
}
