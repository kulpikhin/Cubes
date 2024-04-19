using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion;
    [SerializeField] private float _forceExplosion;

    public void StartExplosion()
    {
        foreach(Cube cube in GetExplodableCubes())
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_forceExplosion, transform.position, _radiusExplosion);
        }
    }

    private List<Cube> GetExplodableCubes()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radiusExplosion);

        List<Cube> cubes = new List<Cube>();

        foreach (Collider hit in hits)
        {
            if(hit.TryGetComponent<Cube>(out Cube cube))
            {
                cubes.Add(cube);
            }
        }

        return cubes;
    }
}
