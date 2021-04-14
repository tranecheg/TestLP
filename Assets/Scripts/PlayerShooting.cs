using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform leftArm, mousePos, firePoint;
    [SerializeField]
    private GameObject bulletPref;
    private float mouseX, mouseXMin = -15f, mouseXMax = 15f;
    private float fireTimer = 10.0f;
    [SerializeField]
    private GameSettings gameSettings;
    
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0) && fireTimer >= 10)
        {
            GameObject bullletGameObject = Instantiate(bulletPref, firePoint.position, Quaternion.identity);
            bullletGameObject.transform.LookAt(hit.point);
            
            fireTimer = 0.0f;
        }

    }

    void Update()
    {
        MouseTransform();

        if (fireTimer < 10)
            fireTimer += Time.deltaTime * gameSettings.shootSpeed;
        else if (fireTimer > 10f)
            fireTimer = 10f;

    }
    void MouseTransform()
    {
        mouseX += Input.GetAxis("Mouse X");
        mousePos.localPosition = new Vector3(Mathf.Clamp(mouseX, mouseXMin, mouseXMax), 60, 20);
        leftArm.transform.LookAt(mousePos);

        float horPos = Input.GetAxis("Horizontal");
        if (horPos!=0)
            transform.rotation *= Quaternion.Euler(Vector3.up * horPos);
        
       
    }
}
