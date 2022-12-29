using UnityEngine;

namespace GiftOrCoal.Other
{
    public sealed class Accuracy : MonoBehaviour
    {
        [SerializeField] private CountViews _countView;
        private int _mistakesCount;
        private int _answersCount;

        public void AddAnswer()
        {
            _answersCount += 1;
            VisualizeInPercents();
        }

        public void AddMistake()
        {
            _mistakesCount += 1;
            VisualizeInPercents();
        }

        private void VisualizeInPercents()
        {
            const float toPercents = 100f;

            if (_mistakesCount == 0)
            {
                _countView.Visualize(100f);
            }
            
            else
            {
                var percents = (float)_mistakesCount / (float)_answersCount * toPercents;
                _countView.Visualize(percents);
            }
        }
    }
}