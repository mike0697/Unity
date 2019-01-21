using UnityEngine;

public class Option : MonoBehaviour {

	private void OnMouseDown()
    {
        Manager.Instance.Pause();
    }
}
