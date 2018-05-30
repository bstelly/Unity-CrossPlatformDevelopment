using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Editor;
using UnityEditor;
using UnityEngine;



public class EditorCharacterCreatorWindow : UnityEditor.EditorWindow
{
    public class StatButton
    {
        public Stat stat;
        Rect buttonRect = new UnityEngine.Rect(75, 75, 150, 150);
        public bool isSelected = false;

        public void Draw()
        {
            var contentRect = new Rect(buttonRect);
            GUI.Box(buttonRect, "stat");

            GUILayout.BeginArea(contentRect, new GUIStyle("flow node 0"));

            GUILayout.Toggle(isSelected, "is Selected");
            buttonRect.width = GUILayout.HorizontalSlider(buttonRect.width, 150, 500, GUILayout.MaxWidth(100));
            buttonRect.height = GUILayout.HorizontalSlider(buttonRect.height, 150, 500, GUILayout.MaxWidth(100));


            GUILayout.EndArea();

        }

        public void PollEvents()
        {
            switch (Event.current.type)
            {
                case EventType.MouseDown:
                    if (Event.current.button == 0)
                    {
                        isSelected = buttonRect.Contains(Event.current.mousePosition);
                        GUI.changed = true;

                    }

                    break;
                case EventType.MouseDrag:

                    if (Event.current.button == 0)
                    {
                        if (isSelected)
                        {
                            buttonRect.position += Event.current.delta;
                            Event.current.Use();
                        }
                    }

                    break;
            }

        }
    }

    public System.Collections.Generic.List<StatButton> statButtons = new System.Collections.Generic.List<StatButton>();

    [UnityEditor.MenuItem("Tools/Button")]
    public static void Init()
    {
        var window = GetWindow(typeof(EditorCharacterCreatorWindow));
        window.Show();
    }

    void CreateButton()
    {
        statButtons.Add(new StatButton());
    }

    Rect buttonRect = new UnityEngine.Rect(75, 75, 150, 150);

    private void OnGUI()
    {
        foreach (var sb in statButtons)
        {
            sb.Draw();
            sb.PollEvents();
        }

        Repaint();

        switch (Event.current.type)
        {
            case EventType.MouseDown:
                if (Event.current.button == 1)
                {
                    var gm = new UnityEditor.GenericMenu();
                    gm.AddItem(new GUIContent("Create Stat"), false, CreateButton);
                    gm.AddItem(new GUIContent("Print Info"), false, () => { Debug.Log("Info Printed"); });
                    gm.ShowAsContext();
                }

                break;

        }
    }
}
