using UnityEngine;

public class raycast : MonoBehaviour {

    public Camera cam;
    [SerializeField]
    float rayMaxDistance = 50;
    LayerMask layerMask = ~((1 << 9) | (1 << 8));

	
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray lastRay = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(lastRay.origin, lastRay.direction * rayMaxDistance, Color.green, 1); //1 = secondi 

            if(Physics.Raycast(lastRay,out hit, rayMaxDistance, layerMask))
            {
                //Debug.Log(hit.collider.gameObject);
                Cube hitCube = hit.collider.gameObject.GetComponent<Cube>();
                if(hitCube)
                {
                    hitCube.OnHitByRaycast();
                }
            }
        }
	}
}
