using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float range;

    private Player _player;    
    private Transform _transform;

    private void Start()
    {
        _player = GameDirector.instance.player;
        _transform = transform;
    }

    private void Update()
    {
        _transform.position += _transform.forward * speed * Time.deltaTime;
        if ((_transform.position - _player.transform.position).magnitude > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameDirector.instance.fXManager.PlayBulletImpactFX(_transform.position, _transform.forward, Color.red);
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetHit(1);
            }
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            GameDirector.instance.fXManager.PlayBulletImpactFX(_transform.position, _transform.forward, new Color(1, .6f, 0, 1));
            Destroy(gameObject);
        }
    }
}
