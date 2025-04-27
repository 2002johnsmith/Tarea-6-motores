using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] private string nameScene;
    Button BotonVolver;
    private void Awake()
    {
        BotonVolver = GetComponent<Button>();
    }
    private void Start()
    {
        BotonVolver.onClick.AddListener(()=>ChangeScene(nameScene));
    }
    public void ChangeScene(string volver)
    {
        SceneManager.LoadScene(volver);
    }
}
