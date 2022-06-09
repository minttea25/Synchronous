using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KWY
{
    public class ManageShowingSkills : MonoBehaviour
    {
        [SerializeField]
        GameObject[] selSkillPanels = new GameObject[3];

        private bool seletable = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nth">0 ~ 2</param>
        public void ShowSkillPanel(int nth)
        {
            if (!seletable)
            {
                for (int i = 0; i < selSkillPanels.Length; i++)
                {
                    selSkillPanels[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < selSkillPanels.Length; i++)
                {
                    selSkillPanels[i].SetActive(nth == i);
                }
            }
        }

        public void SetSeletable(bool state)
        {
            seletable = state;

            if (!seletable)
            {
                for (int i = 0; i < selSkillPanels.Length; i++)
                {
                    selSkillPanels[i].SetActive(false);
                }
            }
        }
    }
}
