using UnityEngine;
//Can be removed ???
public class DeleteButton : MonoBehaviour
{
    [SerializeField]
    GameObject objectToDestroy;
   

    public void DestroyGameObject()
    {
        Destroy(objectToDestroy);
        Destroy(this.gameObject);

    }

    
}
