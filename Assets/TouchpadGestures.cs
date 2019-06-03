using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class TouchpadGestures : MonoBehaviour {

    #region Public Variables
    public Text typeText, stateText, directionText;
    public Camera Camera;
    #endregion

    #region Private Variables
    private MLInputController _controller;
    #endregion

    #region Unity Methods
    void Start() {
        MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnDestroy() {
        MLInput.Stop();
    }            

    void Update() {
        updateTransform();
        updateGestureText();

        if (_controller.TouchpadGesture.Type.ToString() != null) {

            switch (_controller.TouchpadGesture.Type.ToString())
        {
            case "Swipe":
                typeText.text = "this works"; 
                break;
            case "RadialScroll":
                typeText.text = "this also works"; 
                break; 
            default:
                break;
        } 
 
           /*  if (_controller.TouchpadGesture.Type.ToString()  == "Swipe") {
                Debug.Log("gets input " + _controller.TouchpadGesture.Type.ToString());        
                 typeText.text = "this works"; 
            }  */ 
        }

    
     /* switch (_controller.TouchpadGesture.Type.ToString())
        {
            case "Swipe":
                typeText.text = "this works"; 
                break;
            case "RadialScroll":
                typeText.text = "this also works"; 
                break; 
            default:
                break;
        }   */ 
                    

            //typeText.text = "A gesture was just made : " +  _controller.TouchpadGesture.Type.ToString(); 

        
    }


    #endregion

    #region Private Methods
    void updateGestureText() {

        string gestureType = _controller.TouchpadGesture.Type.ToString();
        string gestureState = _controller.TouchpadGestureState.ToString();
        string gestureDirection = _controller.TouchpadGesture.Direction.ToString();

       // typeText.text = "Type: " + gestureType;
        stateText.text = "State: " + gestureState;
        directionText.text = "Direction: " + gestureDirection;
    }


    public void TestFunction() {


        
    }
    
    void updateTransform() {
        float speed = Time.deltaTime * 5f;

        Vector3 pos = Camera.transform.position + Camera.transform.forward;
        gameObject.transform.position = Vector3.SlerpUnclamped(gameObject.transform.position, pos, speed);

        Quaternion rot = Quaternion.LookRotation(gameObject.transform.position - Camera.transform.position);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, rot, speed);
    }
    #endregion
}