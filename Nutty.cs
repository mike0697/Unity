using UnityEngine;

public class Nutty : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bottle>())
        {
            Manager.Instance.Score(collision.gameObject.GetComponent<Bottle>().bottleIndex);
            Destroy(collision.gameObject);
            Manager.Instance.spawnBottle();
        }
    }
}
