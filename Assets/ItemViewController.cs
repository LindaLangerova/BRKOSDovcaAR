using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ItemViewController : MonoBehaviour {

    public Text ItemViewText;
    public Image ItemViewImage;
    public GameObject ItemView;

    public ItemsController ItemsController;
    private List<ParametrizedItem> _heldItems;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void HideView() {
        ItemView.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void ShowView(Image image) {
        if (image.sprite != null && ItemViewText.text != null) {
            ItemView.GetComponent<CanvasGroup>().alpha = 1;
            _heldItems = ItemsController.GetHeldItems();

            ParametrizedItem vizualizedItem = _heldItems.Find(item => item.ItemSprite.Equals(image.sprite));
            ItemViewText.text = 
                vizualizedItem.Name == Items.KufrZabaleny.Name ? "Kufr v ochranné folii" :
                vizualizedItem.Name == Items.KufrRozbaleny.Name ? "To je ale těžký kufr!" : vizualizedItem.Name;
            ItemViewImage.sprite = _heldItems.Find(item => item.ItemSprite.Equals(image.sprite)).ItemSprite;
        }
        
    }
}

