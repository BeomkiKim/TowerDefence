using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    bool doMovement = true;

    public float panSpeed = 30f;
    public float panBroderThickness = 10f;

    public float scrollSpeed = 5f;
    float clampZ = 50f;
    float clampY = 10f;

    public float minY = 10f;
    public float maxY = 50f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if(Input.GetKey("w") && transform.position.z <= clampZ || Input.mousePosition.y >= Screen.height-panBroderThickness && transform.position.z <= clampZ)
        { 
            transform.Translate(Vector3.forward*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s") && transform.position.z >= -clampZ + 30f || Input.mousePosition.y <= panBroderThickness && transform.position.z >= -clampZ+30f)
        { 
            transform.Translate(Vector3.back*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d") && transform.position.x < clampY+50f || Input.mousePosition.x >= Screen.width-panBroderThickness && transform.position.x < clampY+50f)
        { 
            transform.Translate(Vector3.right*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a") && transform.position.x > clampY || Input.mousePosition.x <= panBroderThickness && transform.position.x > clampY)
        { 
            transform.Translate(Vector3.left*panSpeed*Time.deltaTime, Space.World);
        }
        if(Input.GetKey("m"))
        {
            AudioListener.volume = 0;
        }
        if (Input.GetKey("n"))
        {
            AudioListener.volume = 1;
        }
        if(Input.GetKey("b"))
        {
            SceneManager.LoadScene("StartScene");
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
