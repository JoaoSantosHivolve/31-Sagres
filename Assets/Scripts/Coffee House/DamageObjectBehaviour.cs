using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectBehaviour : MonoBehaviour
{
    public GoodsState state;

    [Range(0, 100)]
    public int damageChance;

    [Header("Materials")]
    public Material goodMaterial;
    public List<Material> damagedMaterials;

    public List<MeshRenderer> objects;

    private void Start()
    {
        if(Random.Range(0, 100) <= damageChance)
        {
            state = GoodsState.Damaged;

            for (int i = 0; i < transform.childCount; i++)
            {
                objects.Add(transform.GetChild(i).GetComponent<MeshRenderer>());
            }

            var objectCount = Random.Range(0, transform.childCount -1);

            StartCoroutine(DamageGoods(0, objectCount));
        }
        else
        {
            state = GoodsState.Good;
        }
    }

    private IEnumerator DamageGoods(int index, int objectCount)
    {
        yield return null;

        if (index != objectCount)
        {
            var objectIndex = Random.Range(0, transform.childCount - 1);
            int matIndex = 0;
            for (int i = 0; i < objects[objectIndex].materials.Length; i++)
            {
                if (objects[objectIndex].materials[i].name.Contains(goodMaterial.name))
                    matIndex = i;
            }
            var newMats = objects[objectIndex].materials;
            newMats[matIndex] = GetDamagedMaterial();
            objects[objectIndex].materials = newMats;

            //objects[Random.Range(0, transform.childCount - 1)].material = GetDamagedMaterial();

            index += 1;
            StartCoroutine(DamageGoods(index, objectCount));
        }
    }

    private Material GetDamagedMaterial()
    {
        return damagedMaterials[Random.Range(0, damagedMaterials.Count -1)];
    }
}