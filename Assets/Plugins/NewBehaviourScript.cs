using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void init();

    //[DllImport("__Internal")]
    //private static extern void HelloString(string str);

    //[DllImport("__Internal")]
    //private static extern void PrintFloatArray(float[] array, int size);

    //[DllImport("__Internal")]
    //private static extern int AddNumbers(int x, int y);

    //[DllImport("__Internal")]
    //private static extern string StringReturnValueFunction();

    //[DllImport("__Internal")]
    //private static extern void BindWebGLTexture(int texture);

    void Start() {
        init();
        Debug.Log("init 실행");
    }
}