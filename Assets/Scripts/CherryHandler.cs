using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryHandler : MonoBehaviour
{
    public GameObject CherrySingle;

    public void CherryExplode(Vector3 throwforce)
    {

        StartCoroutine(DestroyThis(throwforce));
    }

    IEnumerator DestroyThis(Vector3 throwforce)
    {
        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(CherrySingle, new Vector3(this.transform.position.x, this.transform.position.y + ((float)i / 2), this.transform.position.z + ((float)i /2)), Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(throwforce * (1 + (i/10)), ForceMode.Impulse);
        }

        Destroy(this.gameObject);
    }

}
