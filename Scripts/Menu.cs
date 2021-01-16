using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private List<MenuItemAction> items = new List<MenuItemAction>();
    private bool menuActive = false;
    [SerializeField]
    private int defaultMenuSelected = 0;
    private int currentPositionItem = 0;
    private int rows = 0;
    private int columns = 0;
    private List<DialogPopupChoiceItem> itemsGenerated = new List<DialogPopupChoiceItem>();
    private float nextClick = 0;
    [SerializeField]
    private float cooldown = .25f;
    private GridLayoutGroup glg;

    void GenerateMenu()
    {
        if (itemPrefab == null) return;
        for(int i = 0; i < items.Count; i += 1)
        {
            DialogPopupChoiceItem popupItem = CreateItem(items[i]);
            itemsGenerated.Add(popupItem);
            if (i == defaultMenuSelected) {
                popupItem.SelectItem();
            }
            else {
                popupItem.UnselectItem();
            }
        }
    }

    DialogPopupChoiceItem CreateItem(MenuItemAction menuItem)
    {
        var obj = Instantiate(itemPrefab, transform);
        DialogPopupChoiceItem item = obj.GetComponent<DialogPopupChoiceItem>();
        item.SetupItem(menuItem.nameItem);
        return item;
    }

    // Start is called before the first frame update
    void Start()
    {
        glg = GetComponent<GridLayoutGroup>();
        GenerateMenu();
        menuActive = true;
    }

    void OnGUI()
    {
        GetColumnAndRow(glg, out columns, out rows);
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuActive) return;
        nextClick -= Time.deltaTime;

        if (nextClick > 0) return;
        Direction direction = InputManager.instance.GetDirection();

        if (direction == Direction.NONE) return;
        nextClick = cooldown;

        itemsGenerated[currentPositionItem].UnselectItem();

        if (direction == Direction.DOWN &&
            currentPositionItem < itemsGenerated.Count - 1) {
            currentPositionItem += 1;
        }

        if (direction == Direction.UP &&
            currentPositionItem > 0) {
            currentPositionItem -= 1;
        }

        itemsGenerated[currentPositionItem].SelectItem();
    }

    // Solution from: https://stackoverflow.com/questions/52353898/get-column-and-row-of-count-from-gridlayoutgroup-programmatically
    void GetColumnAndRow(GridLayoutGroup glg, out int column, out int row)
    {
        column = 0;
        row = 0;

        if (glg.transform.childCount == 0)
            return;

        //Column and row are now 1
        column = 1;
        row = 1;

        //Get the first child GameObject of the GridLayoutGroup
        RectTransform firstChildObj = glg.transform.
            GetChild(0).GetComponent<RectTransform>();

        Vector2 firstChildPos = firstChildObj.anchoredPosition;
        bool stopCountingRow = false;

        //Loop through the rest of the child object
        for (int i = 1; i < glg.transform.childCount; i++)
        {
            //Get the next child
            RectTransform currentChildObj = glg.transform.
                GetChild(i).GetComponent<RectTransform>();

            Vector2 currentChildPos = currentChildObj.anchoredPosition;

            //if first child.x == otherchild.x, it is a column, ele it's a row
            if (firstChildPos.x == currentChildPos.x)
            {
                column++;
                //Stop couting row once we find column
                stopCountingRow = true;
            }
            else
            {
                if (!stopCountingRow)
                    row++;
            }
        }
    }
}
