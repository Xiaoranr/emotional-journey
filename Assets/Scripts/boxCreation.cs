using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCreation : MonoBehaviour
{
    public GameObject boxPrefab;
    public float interval = 5;
    public Transform boxCreationRoot;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBox", 0.1f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBox()
    {
        GameObject node = Instantiate(boxPrefab);
        node.transform.position = boxCreationRoot.position;
        node.transform.parent = transform;
        StartCoroutine(DestroyBox(node, 25f));
    }
    private IEnumerator DestroyBox(GameObject node, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(node);
    }

}
