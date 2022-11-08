using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    LaserBeam beam;

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Laser Beam-"+gameObject.name));
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material, gameObject.name);
        
    }
}
