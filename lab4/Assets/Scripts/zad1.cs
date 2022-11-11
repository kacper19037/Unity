using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public Material[] materials;
    public int amount = 15;

    void Start()
    {
        Vector3 size = GetComponent<Collider>().bounds.size;
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)(transform.position.x - (size.x * 0.5)), (int)(transform.position.x + (size.x * 0.5))).OrderBy(x => Guid.NewGuid()).Take(amount));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)(transform.position.z - (size.z * 0.5)), (int)(transform.position.z + (size.z * 0.5))).OrderBy(z => Guid.NewGuid()).Take(amount));

        for (int i = 0; i < amount; i++)
        {
            //this.positions.Add(new Vector3(Random.Range(transform.position.x, transform.lossyScale.x), 0.5f, Random.Range(transform.position.z, transform.lossyScale.z)));
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo�ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            int matIndex = UnityEngine.Random.Range(0, materials.Length);
            obj.GetComponent<MeshRenderer>().material = materials[matIndex];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
