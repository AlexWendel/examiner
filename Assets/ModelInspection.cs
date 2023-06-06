using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ModelInspection : MonoBehaviour
{
    public Button backButton; // Botão de voltar

    private bool isInspecting; // Variável para verificar se está inspecionando o modelo
    public bool canRotate; // Variável para verificar se a rotação é permitida
    private Vector2 previousMousePosition; // Posição anterior do mouse para calcular o movimento
    private InspectorEntity modelEntity; // Instância da classe ModelEntity
    
    public TMP_Text title;
    public TMP_Text description;

    public Camera modelCamera;
    public RawImage renderingArea;
    public EntityScriptable selectedEntity;
    private GameObject inspectedModel;
    public Transform lookPivot;

    void Start()
    {
        // Adicionar evento de clique ao botão de voltar
        backButton.onClick.AddListener(ExitInspector);
        if (selectedEntity != null){
            LoadEntity(selectedEntity);
            UpdateUI();
        }
    }

    void LoadEntity(EntityScriptable entity){
        inspectedModel = Instantiate(entity.model, lookPivot, false);
    }

    void ResetRotation(){

    }

    void Update(){

        if (canRotate){
            // Obter a posição atual do mouse
            Vector2 currentMousePosition = Mouse.current.position.ReadValue();

            // Calcular a diferença entre a posição atual e a última posição do mouse
            Vector2 mouseDelta = currentMousePosition - previousMousePosition;

            // Calcular a velocidade de rotação
            float rotationSpeedx = 3f;
            float rotationSpeedy = 2f;

            // Aplicar a rotação do modelo nos eixos X e Y com base na diferença do mouse
            lookPivot.Rotate(Vector3.up, -mouseDelta.x * rotationSpeedx, Space.World);
            lookPivot.Rotate(Vector3.right, -mouseDelta.y * rotationSpeedy, Space.Self);

            // Atualizar a última posição do mouse
            previousMousePosition = currentMousePosition;                
        }
    }

    void UpdateUI(){
        title.text = selectedEntity.name;
        description.text = selectedEntity.description;
    }

    public void EnterInspector(InspectorEntity model)
    {
        // Ativar modelo
        modelEntity = model;
        inspectedModel.SetActive(true);
        isInspecting = true;
        canRotate = false; // A rotação não é permitida inicialmente
    }

    public void ExitInspector()
    {
        // Desativar modelo
        inspectedModel.SetActive(false);
        isInspecting = false;
        canRotate = false;
    }
}