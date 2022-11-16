/// <summary>
/// 可瞄准物体接口
/// </summary>
public interface IAimableObject
{

    /// <summary>
    /// 瞄准进入事件
    /// </summary>
    void OnAimEnter();
    /// <summary>
    /// 瞄准离开事件
    /// </summary>
    void OnAimExit();
    /// <summary>
    /// 瞄准停留事件
    /// </summary>
    void OnAimStay();
    /// <summary>
    /// 鼠标点击事件
    /// </summary>
    void DoInteract();
}