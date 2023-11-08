using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 0.1f;
    int objectCounter = 0;
    public GameObject block;

    public int numberOfObjects = 10;

    public List<Material> materials = new List<Material>();

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            Bounds bounds = meshRenderer.bounds;
            float minX = bounds.min.x;
            float maxX = bounds.max.x;
            float minZ = bounds.min.z;
            float maxZ = bounds.max.z;

            List<int> pozycje_x = new List<int>(Enumerable.Range((int)minX, 2 * (int)maxX + 1).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
            List<int> pozycje_z = new List<int>(Enumerable.Range((int)minZ, 2 * (int)maxZ + 1).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));

            for (int i = 0; i < numberOfObjects; i++)
            {
                this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
            }
            foreach (Vector3 elem in positions)
            {
                Debug.Log(elem);
            }

            StartCoroutine(GenerujObiekt());
        }
        else
        {
            Debug.LogWarning("Obiekt nie posiada komponentu MeshRenderer.");
        }
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject spawnBlock = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);

            Renderer renderer = spawnBlock.GetComponent<Renderer>();

            int randomMaterialIndex = Random.Range(0, materials.Count);
            Material selectedMaterial = materials[randomMaterialIndex];

            renderer.material = selectedMaterial;

            yield return new WaitForSeconds(this.delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
