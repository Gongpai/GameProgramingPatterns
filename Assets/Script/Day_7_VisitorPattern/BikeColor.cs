using System;
using UnityEngine;

namespace GDD
{
    public class BikeColor : MonoBehaviour, IVisitableBikeElement
    {
        private Material m_material;
        private Color m_color = new Color(0,0,0,1);
        public int color_current = 0; // Percentage

        public int remove_color(int remove)
        {
            color_current -= remove;
            return color_current;
        }

        public void Accept(IBikeElementVisitor visitor)
        {
            visitor.Visit(this);
        }
        
        void OnGUI()
        {
            GUI.color = Color.green;

            GUI.Label(
                new Rect(125, 80, 350, 20),
                "Color : "+ color_current + "% RED : " + (int)(m_color.r * 100) + "% GREEN : " + (int)(m_color.g * 100) + "% BLUE : " +
                (int)(m_color.b * 100) + "%");
        }

        private void Start()
        {
            m_material = GetComponent<Renderer>().sharedMaterial;
            m_material.color = Color.black;
        }

        private void Update()
        {
            if (((float)color_current / 25.000000f) <= 1)
            {
                m_color = new Color(((float)color_current / 25.000000f), m_color.g, m_color.b, m_color.a);
                print("color = " + (255 * ((float)color_current / 25.000000f)));
                m_material.color = m_color;
            }
            
            float g = (((float)color_current - 25.000000f) / 25.000000f);
            if (g >= 0 && g <= 1)
            {
                print("G : " + g);
                m_color = new Color(1 - g, g, m_color.b, m_color.a);
                m_material.color = m_color;
            }
            
            float b = (((float)color_current - 50.000000f) / 25.000000f);
            if (b >= 0 && b <= 1)
            {
                print("B : " + b);
                m_color = new Color(m_color.r, 1 - b, b, m_color.a);
                m_material.color = m_color;
            }
            
            float w = (((float)color_current - 75.000000f) / 25.000000f);
            if (w >= 0 && w <= 1)
            {
                print("B : " + w);
                m_color = new Color(w, w, m_color.b, m_color.a);
                m_material.color = m_color;
            }
        }
    }
}