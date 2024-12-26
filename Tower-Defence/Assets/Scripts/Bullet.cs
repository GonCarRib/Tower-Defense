using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    private int dano = 0;

    public GameObject imapacto;

    public void Seek(Transform _target) { 

        target = _target;
    }

    public void Dano(int _dano) { 
        dano = _dano;
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { 
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;

        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance) {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized*distance, Space.World);

    }

    void HitTarget() {
        target.GetComponent<Enemy>().vida -= dano;
        Instantiate(imapacto,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
