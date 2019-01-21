using UnityEngine;

public class Trash : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.GetComponent<Bottle>())
        {
            AudioManager.Instance.PlayTrashSound();
            Manager.Instance.spawnBottle();
        }
    }


}
