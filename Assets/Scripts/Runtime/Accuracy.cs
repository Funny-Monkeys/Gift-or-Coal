using System;
using GiftOrCoal.View;
using UnityEngine;

namespace GiftOrCoal
{
    public sealed class Accuracy : MonoBehaviour
    {
        [SerializeField] private CountView _countView;
        private int _mistakesCount;
        private int _successAnswersCount;

        public void AddSuccess()
        {
            _successAnswersCount += 1;
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
                var percents = _mistakesCount / (float)_successAnswersCount * toPercents;
                _countView.Visualize(percents);
            }
        }
    }
}