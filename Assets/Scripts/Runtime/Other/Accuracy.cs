using UnityEngine;

namespace GiftOrCoal.Other
{
    public sealed class Accuracy : MonoBehaviour
    {
        [SerializeField] private AccuracyView _countView;
        private int _successfulAnswers;
        private int _answersCount;

        public void AddAnswer()
        {
            _answersCount += 1;
            VisualizeInPercents();
        }

        public void AddSuccessfulAnswer()
        {
            _successfulAnswers += 1;
            VisualizeInPercents();
        }

        private void VisualizeInPercents()
        {
            const float toPercents = 100f;
            var percents = (float)_successfulAnswers / (float)_answersCount * toPercents;
            _countView.Visualize(percents);
        }
    }
}