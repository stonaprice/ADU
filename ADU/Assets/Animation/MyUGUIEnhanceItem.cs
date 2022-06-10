using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyUGUIEnhanceItem : EnhanceItem, IPointerClickHandler
{
    // クリックされた時に呼び出されます
    public void OnPointerClick( PointerEventData eventData )
    {
        OnClickEnhanceItem();
    }

    // 要素の奥行きを設定する時に呼び出されます
    protected override void SetItemDepth
    ( 
        float depthCurveValue, 
        int   depthFactor    , 
        float itemCount 
    )
    {
        int newDepth = ( int )( depthCurveValue * itemCount );
        transform.SetSiblingIndex( newDepth );
    }

    // 要素が中央に来たかどうか確認する時に呼び出されます
    public override void SetSelectState( bool isCenter )
    {
        var image = GetComponent<Graphic>();
        image.color = isCenter ? Color.white : Color.gray;
    }
}