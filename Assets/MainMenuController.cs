using UnityEngine;
using UnityEngine.UIElements;

// Todo @GA create Abstract controller
public class MainMenuController : MonoBehaviour
{
    private VisualElement _root;

    // Coucou

    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;

        Debug.Log(_root, this);

        var playButton = _root.Q<Button>("play-button");

        playButton.RegisterCallback<ClickEvent>(ShowContextMenu);
    }

    private void OnDestroy()
    {
        foreach (var visualElement in _root.Children())
        {
            visualElement.UnregisterCallback<ClickEvent>(ShowContextMenu);
            visualElement.UnregisterCallback<ClickEvent>(LoadScene);
        }
    }

    private static void ShowContextMenu(ClickEvent e)
    {
        if (!(e.currentTarget is VisualElement button)) return;

        if (button.parent.childCount == 1) return;

        var contextMenu = button.parent.Q("mode-selection-context-menu");
        
        contextMenu.visible = !contextMenu.visible;
        
        foreach (var subMenuButton in contextMenu.Children())
        {
            subMenuButton.RegisterCallback<ClickEvent>(LoadScene);
        }
    }

    private static void LoadScene(ClickEvent e)
    {
        if (!(e.currentTarget is VisualElement button)) return;
        
        // TODO GA Go to Scene
    }
}