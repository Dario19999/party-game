using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    #region Componentes de diálogo
    [Header("Panel de diálogos")]
    #pragma warning disable 0649    //desactivar mensaje de warning
    [SerializeField]                //Para ponerlo desde otro objeto (Asignado en inspector)
    private GameObject _dialoguePnl;
    #pragma warning restore 0649    //activar mensaje de warning
    #endregion

    #region Componentes dentro del panel
    private TextMeshProUGUI _dialogueTMP, _nameTMP, _nextTMP;
    private Button _NextBttn;
    #endregion

    #region Componentes del NPC
    private string _name;
    private List<string> _dialogueList;
    private int _dialogueIdx;
    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        #region Comprobar asignación de panel de diálogo
        if(_dialoguePnl==null)
        {
            Debug.LogError("No se asigno el panel de diálogos al DialogoPnl (Script)");
        }
        #endregion

        #region Obtener texto de diálogo
        _dialogueTMP = _dialoguePnl.GetComponentInChildren<TextMeshProUGUI>();
        //_dialogueTMP = _dialoguePnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (_dialogueTMP!=null)
        {
            _dialogueTMP.text = "Obtenido dialogueTMP";
        }
        else //es igual a nulo
        {
            Debug.LogWarning("No se encontro un TMP como hijo del padre");
        }
        #endregion

        #region Obtener texto de nombre
        //Obtener el hijo del segundo hijo del panel
        _nameTMP = _dialoguePnl.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        if (_nameTMP!=null)
        {
            _nameTMP.text = "Obtenido NameTMP";
        }
        else //es igual a nulo
        {
            Debug.LogWarning("No se encontro un TMP como hijo del segundo hijo del panel");
        }
        #endregion

        #region Obtener botón
        _NextBttn = _dialoguePnl.transform.GetChild(3).GetComponent<Button>();
        if (_NextBttn!=null)
        {
            //Debug.Log("Obtenido Botón, pero no hace nada");
            _NextBttn.onClick.AddListener(delegate { ContinueDialogue(); });
            //Obtener hijo del botón
            _nextTMP = _NextBttn.GetComponentInChildren<TextMeshProUGUI>();
            if (_nextTMP!=null)
            {
                _nextTMP.text = "Obtenido nextBttn";
            }
            else //es igual a nulo
            {
                Debug.LogWarning("No se encontro un TMP como hijo del botopn");
            }
        }
        else //es igual a nulo
        {
            Debug.LogWarning("No se encontró un botón cini tercer hijo en el panel de dialogos");
        }
        #endregion
        _dialoguePnl.SetActive(false);
    }

    public void setDialogue(string name, string[] dialogue)
    {
        #region Inicializar variables
        _name = name;
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _dialogueIdx = 0;
        #endregion

        #region Primer contacto
        _nameTMP.text = _name;
        _dialogueTMP.text = _dialogueList[_dialogueIdx];
        _nextTMP.text = "Continuar";
        _dialoguePnl.SetActive(true);
        #endregion
    }

    public void ContinueDialogue()
    {
        if(_dialogueIdx == _dialogueList.Count - 1)
        {
            Debug.Log("Se termina el diálogo con " + _name);
            _dialoguePnl.SetActive(false);
        }
        else if(_dialogueIdx == _dialogueList.Count - 2)
        {
            _dialogueIdx++;
            ShowDialogue();
            _nextTMP.text = "Salir";
        }
        else 
        {
            _dialogueIdx++;
            ShowDialogue();
        }
    }
    public void ShowDialogue()
    {
        _dialogueTMP.text = _dialogueList[_dialogueIdx];
        Debug.Log("Idx:" + _dialogueIdx); ;
    }
}
