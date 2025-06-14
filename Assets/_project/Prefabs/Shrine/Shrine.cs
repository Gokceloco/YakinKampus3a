using UnityEngine;
using UnityEngine.Rendering;

public class Shrine : MonoBehaviour
{
    public MeshRenderer mr;

    public Material inactiveMaterial;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShrineInteracted();
        }
    }

    public void ShrineInteracted()
    {
        mr.material = inactiveMaterial;
    }
}
