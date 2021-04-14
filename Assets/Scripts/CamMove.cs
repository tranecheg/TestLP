using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMove : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    void Update()
    {
        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    
   

    
}
