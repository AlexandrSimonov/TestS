using UnityEngine.UI;

public class UserSlider : Slider {
    public void MySet(float value, bool callback) {
        Set(value, callback);
    }
}