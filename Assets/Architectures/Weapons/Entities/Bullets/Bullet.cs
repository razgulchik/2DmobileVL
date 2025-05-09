using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable() {
        StartCoroutine(BulletDestructionRoutine());
    }

    private IEnumerator BulletDestructionRoutine() {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Enemy>() != null)
        {
            gameObject.SetActive(false);
        }
        
    }
}
