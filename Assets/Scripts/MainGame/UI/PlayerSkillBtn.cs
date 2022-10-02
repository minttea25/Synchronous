using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KWY
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class PlayerSkillBtn : MonoBehaviour
    {
        [SerializeField]
        TMP_Text costLabel;

        [SerializeField]
        Image icon;

        PlayerSkillBase psb;

        [Tooltip("Info 띄우는데 필요한 최소 클릭 시간; move 일 경우 없음")]
        public float minClickTime = 1;


        #region Private Fields

        private float clickTime;
        private bool isClick;

        #endregion

        public void SetData(PlayerSkillBase psb)
        {
            costLabel.text = psb.cost.ToString();
            icon.sprite = psb.icon;

            this.psb = psb;
        }

        public void OnClickUseSkill()
        {
            GameObject o = GameObject.Find("MainGameData");
            if (!o)
            {
                Debug.LogError($"Can not find gameobject: 'MainGameData'");
                return;
            }

            MainGameData data = o.GetComponent<MainGameData>();
            if (!data)
            {
                Debug.LogError($"Can not find component: 'MainGameData' in gameobject named 'MainGameData'");
                return;
            }

            if (data.MyPlayer.Mp >= psb.cost)
            {
                data.MyPlayer.SubMp(psb.cost);

                Debug.Log("스킬 발동");
            }
            else 
            {
                Debug.Log("마나 부족");
            }
        }

        public void ButtonUp()
        {
            isClick = false;

            if (clickTime >= minClickTime)
            {
                GameObject canvas = GameObject.Find("UICanvas");
                PanelBuilder.ShowPlayerSkillInfoPanel(canvas.transform, psb);
            }
            else
            {
                OnClickUseSkill();
            }
        }

        public void ButtonDown()
        {
            isClick = true;
        }

        #region MonoBehaviour CallBacks
        private void Update()
        {
            if (isClick)
                clickTime += Time.deltaTime;
            else
                clickTime = 0;
        }
        #endregion

    }
}
