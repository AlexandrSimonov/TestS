using UnityEngine;
using System.Collections;

// Вот эту штуку наверное убрать нужно
public class ItemInInventory : ItemInGrid {

    private ItemInInventoryStructure obj;
    // Нужно сделать так чтобы при изменении элемента он кидал ивент, что он изменён и отображение менялось, вызывалась перерисовка
    //
    public void Init(ItemInInventoryStructure obj) {
        this.obj = obj;
    }


}
/*
 А вообще подумать, чтобы при изменении айтема, он кидал ItemChange и объект, и виндов это ловил
 Чтобы объект выбрасывал на ружу свое уничтожении и т.д
 А при измененении массива, чтобы ловил только виндов и менял что-то в массиве.
     */