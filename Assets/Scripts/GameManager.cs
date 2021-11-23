using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;


public class GameManager : MonoBehaviour
{
    private AudioSource gmAudio;
    //Листы со гейм обджектами
    private List<GameObject> allSymbolsGO = new List<GameObject>();
    private List<GameObject> allNumbersGO = new List<GameObject>();
    private List<GameObject> allSignesGO = new List<GameObject>(); 
    private List<GameObject> allGeometryGO = new List<GameObject>(); 
    
    //Листы со списками
    private List<string> allSymbols = new List<string>();
    private List<string> allNumbers = new List<string>();
    private List<string> allSignes = new List<string>();
    private List<string> allGeometry = new List<string>();
    
    //Листы со звуками
    private List<AudioClip> symboolsSound = new List<AudioClip>();
    private List<AudioClip> symboolsName = new List<AudioClip>();
    private List<AudioClip> numbersSound = new List<AudioClip>();
    private List<AudioClip> signesSound = new List<AudioClip>();
    private List<AudioClip> geometrySound = new List<AudioClip>();

    private bool isGameGo = false;

    private int SiblingIndex = 0;

    [SerializeField] private GameObject startScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        gmAudio = GetComponent<AudioSource>();
        //Получаем все GO в раздельные листы
        allSymbolsGO.AddRange(GameObject.FindGameObjectsWithTag("Symbol").OrderBy(o=>o.GetComponent<TextMeshProUGUI>().text));
        allNumbersGO.AddRange(GameObject.FindGameObjectsWithTag("Number").OrderBy(o=>o.GetComponent<TextMeshProUGUI>().text));
        allSignesGO.AddRange(GameObject.FindGameObjectsWithTag("Sign").OrderBy(o=>o.GetComponent<TextMeshProUGUI>().text));
        allGeometryGO.AddRange(GameObject.FindGameObjectsWithTag("Geometry").OrderBy(o=>o.GetComponent<TextMeshProUGUI>().text));
        
        
        //Подгрузка звуков (буквы)
        for (int i = 0; i < allSymbolsGO.Count; i++)
        {
            string symbolName = allSymbolsGO[i].GetComponent<TextMeshProUGUI>().text;
            //Проверка, если символ уже есть в листе
            if (allSymbols.IndexOf(symbolName.ToLower()) == -1)
            {
                symboolsSound.Add( Resources.Load<AudioClip>("sounds(abcya)/"+ symbolName.ToLower()));
                symboolsName.Add( Resources.Load<AudioClip>("name(abcya)/name"+ symbolName.ToUpper()));
                allSymbols.Add(symbolName.ToLower());    
            }
            
            
        }
        //Подгрузка звуков (цифры)      
        for (int i = 0; i < allNumbersGO.Count; i++)
        {
            string numberName = allNumbersGO[i].GetComponent<TextMeshProUGUI>().text;
            
            //Проверка, если символ уже есть в листе
            if (allNumbers.IndexOf(numberName) == -1)
            {
                numbersSound.Add( Resources.Load<AudioClip>("numbers(abcya)/"+numberName));
                allNumbers.Add(numberName);
            };
        }
        
        //Подгрузка звуков (знаки)
        for (int i = 0; i < allSignesGO.Count; i++)
        {
            string signesName = allSignesGO[i].GetComponent<TextMeshProUGUI>().text;
            //Проверка, если символ уже есть в листе
            if (allSignes.IndexOf(signesName) == -1)
            {
                signesSound.Add( Resources.Load<AudioClip>("signes(abcya)/"+signesName));
                allSignes.Add(signesName);
            };
        }

        //Подгрузка звуков (геометрические фигуры)
        for (int i = 0; i < allGeometryGO.Count; i++)
        {
            string geometryName = allGeometryGO[i].GetComponent<TextMeshProUGUI>().text;

            if (allGeometry.IndexOf(geometryName) == -1)
            {
                geometrySound.Add( Resources.Load<AudioClip>("geometry(abcya)/"+geometryName));
                allGeometry.Add(geometryName);    
            }
            
        }

        // StartCoroutine(StartTheGame());
        

        
    }

    public void StartTheGame()
    {
        startScreen.SetActive(false);
        isGameGo = true;
    }

    public void RestartScreen()
    {
        
        GameObject fridge_layer = GameObject.Find("Fridge_layer");
        
        foreach (Transform child in fridge_layer.transform)
        {
            if (child.gameObject.name == "Fridge")
            {
                continue;
            }    
            Destroy(child.gameObject);
        }
        
    }

    

    public void PlaySymbolSound(string symbolText, string tag)
    {
        
        switch (tag)
        {
            case "Symbol":
                gmAudio.PlayOneShot(symboolsName[allSymbols.IndexOf(symbolText)]);
                gmAudio.clip = symboolsSound[allSymbols.IndexOf(symbolText)];
                gmAudio.PlayDelayed(0.5f);
                break;

            case "Number":
                gmAudio.PlayOneShot(numbersSound[allNumbers.IndexOf(symbolText)]);
                break;

            case "Sign":
                gmAudio.PlayOneShot(signesSound[allSignes.IndexOf(symbolText)]);
                break;
            case "Geometry":
                //Приводим название в соответствии с исходными данными масссива
                symbolText = symbolText[0].ToString().ToUpper() + symbolText.Substring(1);
                
                gmAudio.PlayOneShot(geometrySound[allGeometry.IndexOf(symbolText)]);
                break;
            default:
                Debug.Log("no tag");
                break;
        }


    }

    
    
    //Вспомогательные методы для размещения символов на табе
    public bool GetStateOfTheGame()
    {
        return isGameGo;
    }
    public void StopGoGame()
    {
        isGameGo = false;
    }
    public void StartGoGame()
    {
        isGameGo = true;
    }
    
    
    public void PutSiblingIndex(int index)
    {
        SiblingIndex = index;
    }
    public int GetSiblingIndex()
    {
        // SiblingIndex = 4;
        return SiblingIndex;
    }


}
