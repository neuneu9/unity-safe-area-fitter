using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace neuneu9
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class CanvasFitter : UIBehaviour, ILayoutSelfController
    {
        private RectTransform _rectTransform = null;
        private DrivenRectTransformTracker _tracker = new DrivenRectTransformTracker();

        public virtual void SetLayoutHorizontal()
        {
            Refresh();
        }

        public virtual void SetLayoutVertical()
        {
            Refresh();
        }

        protected override void OnRectTransformDimensionsChange()
        {
            SetDirty();
        }

        protected override void OnTransformParentChanged()
        {
            SetDirty();
        }

        protected override void OnEnable()
        {
            _rectTransform = GetComponent<RectTransform>();

            // RectTransform をロックする前にデフォルト状態を確定させておく
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = Vector2.one;
            _rectTransform.pivot = new Vector2(0.5f, 0.5f);
            _rectTransform.anchoredPosition = Vector2.zero;
            _rectTransform.sizeDelta = Vector2.zero;
            _rectTransform.localRotation = Quaternion.identity;
            _rectTransform.localScale = Vector3.one;

            _tracker.Add(this, _rectTransform, DrivenTransformProperties.All);

            SetDirty();
        }

        protected override void OnDisable()
        {
            _tracker.Clear();
        }

        private void Refresh()
        {
            var canvas = _rectTransform.GetComponentInParent<Canvas>(includeInactive: true);
            var canvasRectTransform = canvas.GetComponent<RectTransform>();
            _rectTransform.position = canvasRectTransform.position;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, canvasRectTransform.rect.width);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvasRectTransform.rect.height);
        }

        protected void SetDirty()
        {
            if (!IsActive())
            {
                return;
            }

            LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);
        }
    }
}
