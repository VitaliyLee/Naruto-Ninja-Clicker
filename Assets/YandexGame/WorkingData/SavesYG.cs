
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;
        
        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public double allMoney = 0;
        public float moneyInSecond = 0;
        public float moneyClick = 0;
        public int bossIndex = 0;
        public int level = 0;
        public float levelProgress = 0;
        public ShopSlotStats shopSlot = null;
        public int[] backCost = new int[8];

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            backCost[0] = 0;
            backCost[1] = 10000;
            backCost[2] = 50000;
            backCost[3] = 200000;

            backCost[4] = 1000000;
            backCost[5] = 10000000;
            backCost[6] = 500000000;
            backCost[7] = 2000000000;
        }
    }
}
