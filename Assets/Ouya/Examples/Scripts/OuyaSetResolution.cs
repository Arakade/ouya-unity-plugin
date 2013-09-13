/*
 * Copyright (C) 2012, 2013 OUYA, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;

[ExecuteInEditMode]
public class OuyaSetResolution : MonoBehaviour
{
    private bool m_fullScreen = true;
    
    private Matrix4x4 m_textWarningMatrix = Matrix4x4.Scale(new Vector3(1.5f, 1.2f, 1f));
    
    public void OnGUI()
    {
        GUILayout.Label(string.Empty);
        GUILayout.Label(string.Empty);
        GUILayout.Label(string.Empty);
        
        GUILayout.BeginHorizontal();
        GUILayout.Space(130);
        GUI.matrix = m_textWarningMatrix;
        GUI.contentColor = new Color(0.8f, 0f, 0f);
        GUILayout.Label("Warning: Selecting anything other than \"Set Both\"\n will likely make mouse aiming inaccurate!");
        GUI.contentColor = Color.black;
        GUI.matrix = Matrix4x4.identity;
        GUILayout.EndHorizontal();
        
        GUILayout.Label(string.Empty);
        GUILayout.Label(string.Empty);
        
        GUILayout.BeginHorizontal();
        GUILayout.Space(300);
        m_fullScreen = GUILayout.Toggle(m_fullScreen, "FullScreen?", GUILayout.Height(40));
        GUILayout.EndHorizontal();
        
        buildResolutionOption(640, 480);
        buildResolutionOption(1280, 720);
        buildResolutionOption(1920, 1080);
    }
    
    private void buildResolutionOption(int width, int height)
    {
        GUILayout.Label(string.Empty);
        GUILayout.BeginHorizontal();
        GUILayout.Space(200);
        GUILayout.Label(string.Format(" {0} : ", height));
        if (GUILayout.Button("Set Unity Resolution"))
        {
            Screen.SetResolution(width, height, m_fullScreen);
        }
        if (GUILayout.Button("Set Java Resolution"))
        {
            OuyaSDK.OuyaJava.JavaSetResolution(string.Format("{0}x{1}", width, height));
        }
        if (GUILayout.Button("Set Both"))
        {
            Screen.SetResolution(width, height, m_fullScreen);
            OuyaSDK.OuyaJava.JavaSetResolution(string.Format("{0}x{1}", width, height));
        }
        GUILayout.EndHorizontal();
    }
    
}