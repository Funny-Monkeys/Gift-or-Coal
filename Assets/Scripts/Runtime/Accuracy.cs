using System;
using GiftOrCoal.View;
using UnityEngine;

namespace GiftOrCoal
{
    public sealed class Accuracy : MonoBehaviour
    {
        [SerializeField] private CountView _countView;
        private int _mistakesCount;
        private int _totalAnswersCount;

        public void AddAnswers(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _totalAnswersCount += count;
            VisualizeInPercents();
        }

        public void AddMistakes(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            _mistakesCount += count;
            VisualizeInPercents();
        }

        private void VisualizeInPercents()
        {
            const float toPercents = 100f;
            var percents = _mistakesCount / (float)_totalAnswersCount * toPercents;
            _countView.Visualize(percents);
        }
    }
}