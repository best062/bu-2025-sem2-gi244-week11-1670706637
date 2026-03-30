using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;
    private bool isStunned = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned) return;
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed);
    }
    
    public void StunEnemy()
    {
        // ถ้าไม่ได้โดนสตันอยู่ ถึงจะเริ่มนับเวลา
        if (!isStunned)
        {
            StartCoroutine(StunRoutine());
        }
    }
    
    private IEnumerator StunRoutine()
    {
        isStunned = true;
        
        if (rb != null)
        {
            rb.freezeRotation = true;        
            rb.linearVelocity = Vector3.zero;
        }
        
        yield return new WaitForSeconds(5f);
        
        isStunned = false;
    }
}
