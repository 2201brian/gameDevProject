using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriteName : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneInfo sceneInfo;
    public TMP_InputField  inputField;
    public TextMeshProUGUI saludoTxtFld;
    private string saludo = "Welcome ... Nice to se you";

    public void OnChangeName() {
        string inputValue = inputField.text;
        sceneInfo.namePlayer = inputValue;
        saludoTxtFld.text = string.Concat(saludo, " ",  sceneInfo.namePlayer);
        Debug.Log(sceneInfo.namePlayer);
    }

    private void Start() {
        if (sceneInfo.namePlayer != "")
        {
            saludoTxtFld.text = string.Concat(saludo, " ",  sceneInfo.namePlayer);
        }
    }

}
